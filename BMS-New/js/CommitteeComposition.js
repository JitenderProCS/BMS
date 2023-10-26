function fnOpenNew() {
    $("span[id*='spnCommitteComposition']").html("New Committe Composition");
}
function fnRemoveClass(obj, val) {
    $("#lbl" + val + "").removeClass('requied');
}