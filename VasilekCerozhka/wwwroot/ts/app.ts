
function assignIdModal(idModal: string, idCoupon: string) {

    if (document.getElementById("IdModal").children[0].id !== idModal) {
        
        document.getElementById("IdModal").children[0].id = idModal;
        document.getElementById("idModalBtnDelete").ariaValueText = idCoupon;
    }
}
function CallControllers(src) {

    const id = document.getElementById("idModalBtnDelete").ariaValueText;
    window.location.href = src + id;
}






function TextareaChangesStyle() {
    document.getElementById("id_label_textarea").classList.add("label_textarea_focus");
    document.getElementById("id_textarea").setAttribute('style', 'height:150px;background: #ebf3ff;');
    document.getElementById("borderId").classList.add("border_textarea_custom");
    document.getElementById("id_span_label").classList.remove("span_label_textarea");
}
function TextareaEmpty() {
    if ((document.getElementById("id_textarea") as HTMLInputElement).value.length === 0) {

        document.getElementById("id_label_textarea").classList.remove("label_textarea_focus");
        document.getElementById("id_label_textarea").classList.add("label_textarea");
        document.getElementById("id_textarea").setAttribute('style', 'height:35px;');
        document.getElementById("borderId").classList.remove("border_textarea_custom");
        document.getElementById("id_span_label").classList.add("span_label_textarea");
    } 
}
function LoadTextarea() {
    if ((document.getElementById("id_textarea") as HTMLInputElement).value.length > 0) {
        document.getElementById("id_textarea").setAttribute('style', 'height:150px;background: #ebf3ff;');
        if (document.getElementById("id_span_label") !== null) {
            document.getElementById("id_span_label").classList.remove("span_label_textarea");
        }
        document.getElementById("borderId").classList.add("border_textarea_custom");
        document.getElementById("id_label_textarea").classList.add("label_textarea_focus");
    } else {
        document.getElementById("id_label_textarea").classList.add("label_textarea");
        document.getElementById("id_label_textarea").style.transition = "";
    }
}
document.addEventListener('DOMContentLoaded', function () {
    LoadTextarea();

    setTimeout(function () {
        document.getElementById("Idloader")?.setAttribute("hidden", "true");
        document.getElementById("IdForm").removeAttribute("hidden");
    }, 1000);

});