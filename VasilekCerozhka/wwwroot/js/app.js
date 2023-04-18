function assignIdModal(idModal, idCoupon) {
    if (document.getElementById("IdModal").children[0].id !== idModal) {
        document.getElementById("IdModal").children[0].id = idModal;
        document.getElementById("idModalBtnDelete").ariaValueText = idCoupon;
    }
}
function CallControllers(src) {
    var id = document.getElementById("idModalBtnDelete").ariaValueText;
    window.location.href = src + id;
}
function TextareaChangesStyle() {
    document.getElementById("id_label_textarea").classList.add("label_textarea_focus");
    document.getElementById("id_textarea").setAttribute('style', 'height:150px;background: #ebf3ff;');
    document.getElementById("borderId").classList.add("border_textarea_custom");
    document.getElementById("id_span_label").classList.remove("span_label_textarea");
}
function TextareaEmpty() {
    if (document.getElementById("id_textarea").value.length === 0) {
        document.getElementById("id_label_textarea").classList.remove("label_textarea_focus");
        document.getElementById("id_label_textarea").classList.add("label_textarea");
        document.getElementById("id_textarea").setAttribute('style', 'height:35px;');
        document.getElementById("borderId").classList.remove("border_textarea_custom");
        document.getElementById("id_span_label").classList.add("span_label_textarea");
    }
}
function LoadTextarea() {
    if (document.getElementById("id_textarea").value.length > 0) {
        document.getElementById("id_textarea").setAttribute('style', 'height:150px;background: #ebf3ff;');
        if (document.getElementById("id_span_label") !== null) {
            document.getElementById("id_span_label").classList.remove("span_label_textarea");
        }
        document.getElementById("borderId").classList.add("border_textarea_custom");
        document.getElementById("id_label_textarea").classList.add("label_textarea_focus");
    }
    else {
        document.getElementById("id_label_textarea").classList.add("label_textarea");
        document.getElementById("id_label_textarea").style.transition = "";
    }
}
document.addEventListener('DOMContentLoaded', function () {
    LoadTextarea();
    setTimeout(function () {
        var _a;
        (_a = document.getElementById("Idloader")) === null || _a === void 0 ? void 0 : _a.setAttribute("hidden", "true");
        document.getElementById("IdForm").removeAttribute("hidden");
    }, 1000);
});
//# sourceMappingURL=app.js.map