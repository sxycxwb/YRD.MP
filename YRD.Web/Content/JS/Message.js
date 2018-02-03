/************提示***********************/
function alert1(title) {
    var json = {
        "type": "success",
        "mainMsg": title,
        "detailMsg": "",
        "close": true,
        "btnText": ["确定"]
    }
    $.jhNotifyBar(json)
}
function alert2(title, content) {
    var json = {
        "type": "success",
        "mainMsg": title,
        "detailMsg": content,
        "close": true,
        "btnText": ["确定"]
    }
    $.jhNotifyBar(json)
}
function alert3(title, content, onClickOk) {
    var json = {
        "type": "success",
        "mainMsg": title,
        "detailMsg": content,
        "close": true,
        "btnText": ["确定"],
        "onClickOk": onClickOk
    }
    $.jhNotifyBar(json)
}
function alert(a1, a2, a3) {
    if (arguments.length == 1) {
        alert1(a1);
    } else if (arguments.length == 2) {
        alert2(a1, a2);
    } else if (arguments.length == 3) {
        alert3(a1, a2, a3);
    }
}

/************错误提示***********************/
function alertError1(title) {
    var json = {
        "type": "error",
        "mainMsg": title,
        "detailMsg": "",
        "close": true,
        "btnText": ["确定"]
    }
    $.jhNotifyBar(json)
}
function alertError2(title, content) {
    var json = {
        "type": "error",
        "mainMsg": title,
        "detailMsg": content,
        "close": true,
        "btnText": ["确定"]
    }
    $.jhNotifyBar(json)
}
function alertError3(title, content, onClickOk) {
    var json = {
        "type": "error",
        "mainMsg": title,
        "detailMsg": content,
        "close": true,
        "btnText": ["确定"],
        "onClickOk": onClickOk
    }
    $.jhNotifyBar(json)
}
function alertError(a1, a2, a3) {
    if (arguments.length == 1) {
        alertError1(a1);
    } else if (arguments.length == 2) {
        alertError2(a1, a2);
    } else if (arguments.length == 3) {
        alertError3(a1, a2, a3);
    }
}

/************警告提示***********************/
function alertWarn1(title) {
    var json = {
        "type": "warning",
        "mainMsg": title,
        "detailMsg": "",
        "close": true,
        "btnText": ["确定"]
    }
    $.jhNotifyBar(json)
}
function alertWarn2(title, content) {
    var json = {
        "type": "warning",
        "mainMsg": title,
        "detailMsg": content,
        "close": true,
        "btnText": ["确定"]
    }
    $.jhNotifyBar(json)
}
function alertWarn3(title, content, onClickOk) {
    var json = {
        "type": "warning",
        "mainMsg": title,
        "detailMsg": content,
        "close": true,
        "btnText": ["确定"],
        "onClickOk": onClickOk
    }
    $.jhNotifyBar(json)
}
function alertWarn(a1, a2, a3) {
    if (arguments.length == 1) {
        alertWarn1(a1);
    } else if (arguments.length == 2) {
        alertWarn2(a1, a2);
    } else if (arguments.length == 3) {
        alertWarn3(a1, a2, a3);
    }
}

/************询问提示***********************/
function confirm1(title) {
    var json = {
        "type": "warning",
        "mainMsg": title,
        "detailMsg": "",
        "close": true,
        "btnText": ["确定", "取消"]
    }
    $.jhNotifyBar(json)
}
function confirm2(title, content) {
    var json = {
        "type": "warning",
        "mainMsg": title,
        "detailMsg": content,
        "close": true,
        "btnText": ["确定", "取消"]
    }
    $.jhNotifyBar(json)
}
function confirm3(title, content, onClickOk) {
    var json = {
        "type": "warning",
        "mainMsg": title,
        "detailMsg": content,
        "close": true,
        "btnText": ["确定", "取消"],
        "onClickOk": onClickOk
    }
    $.jhNotifyBar(json)
}
function confirm(a1, a2, a3) {
    if (arguments.length == 1) {
        confirm1(a1);
    } else if (arguments.length == 2) {
        confirm2(a1, a2);
    } else if (arguments.length == 3) {
        confirm3(a1, a2, a3);
    }
}

