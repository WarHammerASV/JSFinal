function IntegerValidation(txb) {

    if ((txb.value.startsWith("-"))) {
        if ((!isNaN(txb.value.charAt(1))) && (txb.value.charAt(1) >= 1)) {
            txb.value = txb.value.replace(/[^\d]/ig, "");
            txb.value = "-" + txb.value;
            txb.style.border = ""
        }
        else {
            txb.value = txb.value.replace(/[^1-9]/ig, "");
            txb.value = "-" + txb.value;
            txb.style.border = ""
        }
    }
    else if (txb.value.startsWith("0")) {
        txb.value = "0";
    }
    else {
        txb.value = txb.value.replace(/[^\d]/ig, "");
        txb.style.border = ""
    }
    if (txb.value > 2147483647) {
        alert("Значение должно быть меньше 2147483647")
        txb.style.border = "2px solid red";
    }
    if (txb.value < -2147483647) {
        alert("Значение должно быть больше -2147483647")
        txb.style.border = "2px solid red";
    }

    //var value = input.value;
    //var Reg = new RegExp("(^([+-]?)([1-9]+?)[0-9]*)|^0$");
    //if (Reg.test(value) && value <= 2147483647 && value >= -2147483647) {
    //    input.style.borderColor = '';
    //}
    //else
    //input.style.borderColor = 'red';
}

