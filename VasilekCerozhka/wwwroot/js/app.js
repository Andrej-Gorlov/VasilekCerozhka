//function deleteImages() {
//    import('./del')
//        .then(module => {
//            module.default("","","");
//        })
//}
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