function IsRightEmail(event) {
    if (event.length > 1) {
        var helper = document.getElementById("check-email-helper");
        if (helper !== null) {
            helper.remove();
        }
        let regexp = /\b[A-Za-zА-ЯёЁ0-9]{1}\S+[A-Za-zА-ЯёЁ0-9]{1}\b@[A-Za-zА-ЯёЁ]{2,6}(\.[A-Za-zА-ЯёЁ0-9-]+)+/gm;
        let matches = event.match(regexp);
        if (matches === null || matches.length !== 1) {
            document.getElementById("email").value = "";
            var p = document.createElement('p');
            p.innerHTML = "<strong id='check-email-helper'>Некорректный Email!</strong>";
            document.getElementById("check-email").appendChild(p);
        }
    }
}

function isEqual(event) {
    var helper = document.getElementById("check-password-helper");
    if (helper !== null) {
        helper.remove();
    }
    var password = document.getElementById("password").value;
    if (event !== password) {
        document.getElementById("confirm-password").value = "";
        var p = document.createElement('p');
        p.innerHTML = "<strong id='check-password-helper'>Пароли не совпадают!</strong>";
        document.getElementById("check-password").appendChild(p);
    }
}

function isRightNumber(event, idTag, idNameMain, idNameHelper) {
    var helper = document.getElementById(idNameHelper);
    if (helper !== null) {
        helper.remove();
    }
    if (event <= 0) {
        document.getElementById(idTag).value = "";
        var p = document.createElement('p');
        p.innerHTML = "<strong id=" + idNameHelper + ">Поле должно быть больше нуля!</strong>";
        document.getElementById(idNameMain).appendChild(p);
    }
}