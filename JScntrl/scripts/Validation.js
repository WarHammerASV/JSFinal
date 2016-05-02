function IntegerValidation(input) {
    var value = input.value;
    var Reg = new RegExp("(^([+-]?)([1-9]+?)[0-9]*)|^0$");
    if (Reg.test(value) && value <= 2147483647 && value >= -2147483647) {
        input.style.borderColor = '';
        return true;
    }
    input.style.borderColor = 'red';
    return false;
}

