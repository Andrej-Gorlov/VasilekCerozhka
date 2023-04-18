"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function deleteImages(idInput, idBtn, idImg) {
    if (idImg === void 0) { idImg = null; }
    document.getElementById(idInput).remove();
    document.getElementById(idBtn).remove();
    if (document.getElementById(idImg).previousSibling === null) {
        document.getElementById("imges_lebel_name").remove();
        document.getElementById("gloss_div").remove();
        return;
    }
    if (document.getElementById(idImg).classList.contains('active')) {
        document.getElementById(idImg).firstElementChild.classList.add("active");
    }
    document.getElementById(idImg).remove();
}
exports.default = deleteImages;
//# sourceMappingURL=del.js.map