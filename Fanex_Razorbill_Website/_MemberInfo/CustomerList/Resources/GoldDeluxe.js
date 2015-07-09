function EditGoldDeluxe(custid, uplineId, subAccId) {
    var URL = "../../../GoldDeluxeSetting/GoldDeluxe/EditSetting?uplineId=" + uplineId + "&upLineLevel=" + _page.roleid + "&formType=1&actorId=" + uplineId + "&custId=" + custid + "&level=" + _page.roleidLiveCasino + "&subAccId=" + subAccId + "&language=" + _page.langKey;
    ageWnd.open(URL, '', 0, 10, 880, 580);
}

function EditMultiGoldDeluxe(directUplineId, uplineId, subAccId) {
    var SelCID = "";
    var SelUser = "";
    var arCID = document.getElementsByName("chkid");
    var checkboxesChecked = [];

    if (!arCID) return;

    for (var i = 0; i < arCID.length; i++) {
        if (arCID[i].checked) {
            checkboxesChecked.push(arCID[i]);       
        }
    }

    var lengthOfArray = checkboxesChecked.length;
    for (var i = 0; i < lengthOfArray; i++) {
        var linkChar = i == lengthOfArray - 1 ? "" : ", ";
        SelCID += checkboxesChecked[i].id.split('_')[1] + linkChar;
        SelUser += checkboxesChecked[i].value.substring(arCID[i].value.indexOf(";") + 1) + linkChar;
    }

    document.getElementById('uplineId').value = uplineId;
    document.getElementById('customerIds').value = SelCID;
    document.getElementById('usernames').value = SelUser;
    document.getElementById('uplineLevel').value = _page.roleid;
    document.getElementById('customerLevel').value = _page.roleidLiveCasino;
    document.getElementById('actorId').value = uplineId;
    document.getElementById('subAccId').value = subAccId;
    document.getElementById('language').value = _page.langKey;

    ageWnd.open('', '', 0, 10, 880, 580);

    document.getElementById("target").action = "../../../GoldDeluxeSetting/GoldDeluxe/EditSettingMultiple";
    document.getElementById("target").submit();
}

window.actionAfterUpdatedLiveCasinoSettingMultiple = function (isUpdatePartial) {
        window.top.frames["main"].location.reload();
};

    window.actionAfterUpdatedLiveCasinoSettingSingle = function (isUpdatePartial) {
        window.top.frames["main"].location.reload();
};
