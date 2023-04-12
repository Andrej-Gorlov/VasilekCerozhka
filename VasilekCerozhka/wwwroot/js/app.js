function assignIdModal(idModal, idCoupon) {
    if (document.getElementById("IdModal").children[0].id !== idModal) {
        document.getElementById("IdModal").children[0].id = idModal;
        document.getElementById("idModalBtnDelete").ariaValueText = idCoupon;
    }
}
function deleteCoupon() {
    var id = document.getElementById("idModalBtnDelete").ariaValueText;
    window.location.href = "/Coupon/CouponDelete?couponId=" + id;
}
function TextareaChangesStyle() {
    document.getElementById("id_label_textarea").classList.add("label_textarea_focus");
}
function TextareaEmpty() {
    if (document.getElementById("id_textarea").value.length === 0) {
        document.getElementById("id_label_textarea").classList.remove("label_textarea_focus");
        document.getElementById("id_label_textarea").classList.add("label_textarea");
    }
}
function LoadTextarea() {
    if (document.getElementById("id_textarea").value.length > 0) {
        document.getElementById("id_label_textarea").classList.add("label_textarea_focus");
    }
    else {
        document.getElementById("id_label_textarea").classList.add("label_textarea");
        document.getElementById("id_label_textarea").style.transition = "";
    }
}
document.addEventListener('DOMContentLoaded', function () {
    LoadTextarea();
});
//# sourceMappingURL=app.js.map