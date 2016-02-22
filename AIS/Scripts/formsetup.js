$.datepicker.setDefaults($.datepicker.regional["ru"]);
$.datepicker.setDefaults({
    minDate: new Date(2015, 0, 1),
    maxDate: $.datepicker.parseDate("dd.mm.yy", Today),
    dateFormat: "dd.mm.yy",
    showWeek: true,
    gotoCurrent: true,
    //setDate: new Date(2015, 0, 1),
    firstDay: 1
});
$.validator.addMethod('daterange', function(value, element, arg) {
    var startDate = $.datepicker.parseDate("dd.mm.yy", arg[0]),
            endDate = $.datepicker.parseDate("dd.mm.yy", arg[1]),
            enteredDate;
    try {
        enteredDate = $.datepicker.parseDate("dd.mm.yy", value);
    } catch (e) {
        return false;
    }
    return ((startDate <= enteredDate) && (enteredDate <= endDate));
});
$.validator.addMethod('regex', function(value, element, regexp) {
    var reg = new RegExp(regexp);
    return reg.test(value);
});

$.validator.methods.number = function(value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:,\d{3})+)?(?:\,\d+)?$/.test(value);
};
$.validator.methods.range = function (value, element, param) {
    value = parseFloat(value.replace(",", "."));
    return this.optional(element) || (value >= param[0] && value <= param[1]);
};

var FidINNRules = {
    required: true,
    regex: /^\d{12}$/,
    messages: {
        required: "Необходимо ввести ИНН индивидуального предпринимателя",
        regex: "ИНН должен состоять из 12 цифр"
    }
};
var FidAdressRules = {
    required: true,
    minlength: 6,
    messages: {
        required: "Необходимо ввести адрес торгового объекта",
        minlength: "Длинна адреса должна быть больше 6 символов"
    }
};
var FidAreaRules = {
    required: true,
    //number: true,
    range: [0.01, 1000],
    messages: {
        required: "Необходимо ввести площадь торгового объекта",
        range: "Площадь должна быть положительным целым числом не превышающим 1000"
    }
};
var FidSumRules = {
    required: true,
    //number: true,
    range: [0.01, 1000000000],
    messages: {
        required: "Необходимо ввести сумму уплаченного сбора",
        range: "Сумма должна быть положительным целым числом не превышающим 1000000000"
    }
};
var FidDateRules = {
    required: true,
    daterange: ["01.01.2015", Today],
    messages: {
        required: "Необходимо ввести дату платежа",
        daterange: "Дата должна находится между 01.01.2015 и " + Today
    }
};
function createInput(props) {
    var fg = document.createElement("div");
    fg.setAttribute('class', "form-group");
    fg.innerHTML = '<label class="col-sm-4 control-label">' + props['lbName'] + '</label><div class="col-sm-8"><input class="form-control" name="' + props['inName'] + '"' + props['attr'] + ' placeholder="' + props['inPholder'] + '" type="text" value="" /></div>';
    return fg;
}
function createSelect(props) {
    var select = $('<select/>', { 'name': props['inName'], 'class': "form-control" });
    for (var i = 2015; i < 2021; i++)
        for (var j = 1; j < 5; j++) {
            $('<option/>', {
                val: i + "-" + j,
                text: j + " квартал " + i + " год"
            }).appendTo(select);
        }
    var fg = document.createElement("div");
    fg.setAttribute('class', "form-group");
    fg.innerHTML = '<label class="col-sm-4 control-label">' + props['lbName'] + '</label><div class="col-sm-8">' + select[0].outerHTML + '</div>';
    return fg;
}
function createRules(c) {
    $("input[name='[" + c + "].FidINN']").rules('add', FidINNRules);
    $("input[name='[" + c + "].FidINN']").numberMask({ beforePoint: 12 });

    $("input[name='[" + c + "].FidAdress']").rules('add', FidAdressRules);

    $("input[name='[" + c + "].FidArea']").rules('add', FidAreaRules);
    $("input[name='[" + c + "].FidArea']").numberMask({ type: 'float', beforePoint: 10, afterPoint: 2, decimalMark: ',' });

    $("input[name='[" + c + "].FidSum']").rules('add', FidSumRules);
    $("input[name='[" + c + "].FidSum']").numberMask({ type: 'float', beforePoint: 10, afterPoint: 2, decimalMark: ',' });

    $("select[name='[" + c + "].FidPeriods']").select2();

    $("input[name='[" + c + "].FidDate']").rules('add', FidDateRules);
    $("input[name='[" + c + "].FidDate']").datepicker();//.val(Today);
    if ($("input[name='[" + c + "].FidDate']").val() == "")
        $("input[name='[" + c + "].FidDate']").val(Today);

    if (c != 0) {
        if ($("input[name='[" + (c - 1) + "].FidINN']").valid()) {
            $("input[name='[" + (c) + "].FidINN']").val($("input[name='[" + (c - 1) + "].FidINN']").val());
        }
        if ($("input[name='[" + (c - 1) + "].FidAdress']").valid()) {
            $("input[name='[" + (c) + "].FidAdress']").val($("input[name='[" + (c - 1) + "].FidAdress']").val());
        }
    }
}
function addForm(c) {
    var FidINN = createInput({ lbName: "ИНН индивидуального предпринимателя", inName: "[" + c + "].FidINN", inPholder: "ИНН", attr: "" });
    var FidAdress = createInput({ lbName: "Адрес торгового объекта", inName: "[" + c + "].FidAdress", inPholder: "Адрес", attr: "maxlength='100'" });
    var FidArea = createInput({ lbName: "Площадь торгового объекта", inName: "[" + c + "].FidArea", inPholder: "Площадь", attr: "" });
    var FidSum = createInput({ lbName: "Сумма уплаченного сбора", inName: "[" + c + "].FidSum", inPholder: "Сумма", attr: "" });
    var FidPeriods = createSelect({ lbName: "Период произведения оплаты", inName: "[" + c + "].FidPeriods" });
    var FidDate = createInput({ lbName: "Дата осуществления платежа", inName: "[" + c + "].FidDate", inPholder: "Дата", attr: "" });
    var FidIsUse = $('<input/>', {
        name: "[" + c + "].IsUse",
        type: "hidden",
        value: "true"
    });
    var form = $('<div/>', {
        id: 'form' + c,
        'class': "panel-body"
    });

    form.append(FidINN).append(FidAdress).append(FidArea).append(FidSum).append(FidPeriods).append(FidDate).append(FidIsUse);
    $("#form" + (c - 1)).after(form);
    createRules(c);
}

function remForm(c) {
    $("#form" + c).remove();
}