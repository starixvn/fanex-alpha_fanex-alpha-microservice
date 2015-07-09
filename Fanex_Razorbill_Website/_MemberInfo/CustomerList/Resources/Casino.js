//Edit Casino's Positontaking
function EditRnGCasino(custId, uplineId, username, actionOn, isMultipleEdit) {
    var url = "../../../CustomerSetting/Casino/";

    if (isMultipleEdit == 0) {
        $("arrayCustID").value = custId;
        $("arrayUserName").value = "";
    }
    else {
        custId = GetCustID("chkid");
    }

    if ($("arrayCustID").value.indexOf('^') == -1) {
        isMultipleEdit = 0;
    }

    switch (_page.roleid) {
        case 4: // Super
            if (actionOn == "Master") {
                url += "Master/EditMaster/" + custId + "/" + uplineId + "?username=" + username;
            }
            else if (actionOn == "ViewAgent") {
                url += "Agent/ViewAgentBySuper/" + custId + "/" + uplineId + "?username=" + username;
            }
            else if(actionOn == "Member") {
                url += "Member/EditMemberBySuper/" + custId + "/" + uplineId + "?username=" + username;
            }
             else {
                return;
            }
            break;
        case 3: // Master
            if (actionOn == "Agent") {
                url += "Agent/EditAgent/" + custId + "/" + uplineId + "?username=" + username;
            }
            else if(actionOn == "Member") {
                url += "Member/EditMemberByMaster/" + custId + "/" + uplineId + "?username=" + username;
            }
             else {
                return;
            }
            break;
        case 2: // Agent
            if (actionOn == "Member") {
                url += "Member/EditMember/" + custId + "/" + uplineId + "?username=" + username;
            }
            else {
                return;
            }
            break;
    }

    var popH = 600, popW = 980;
     //url, title, left, top, width, height
    ageWnd.open(url, '', 0, 10, 1050, 700);
}