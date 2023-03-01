// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//import AddImages from './AddImages';
//import deleteImages from './DeleteImages';
//window.addEventListener('DOMContentLoaded', () => {

    //AddImages();
   // DeleteImages(idInput, idBtn);

//});

//window.Images = new Object();

//window.Images.addImages = function () {

function addImages() {

    // определяем контейнер для хранения полей
    let container = document.getElementById("second_images");
    let fieldCount = container.getElementsByTagName("input").length;
    let nextFieldId = fieldCount + 1;

    // здесь добавляем элемент, который будет хранить input
    let div = document.createElement("div");
    div.setAttribute("class", "form-group pb-2");

    // создаем новое поле с новым id
    let field = document.createElement("input");
    field.setAttribute("class", "form-control");
    field.setAttribute("id", "Images[" + nextFieldId + "]");
    field.setAttribute("name", "Images");
    field.setAttribute("type", "text");
    field.setAttribute("placeholder", "Введите url изображения");

    // добавляем поле в <div class="form-group"></div>
    div.appendChild(field);
    // добавляем <div class="form-group"><input ... /></div> в главный контейнер
    container.appendChild(div);

    let containerBtn = document.getElementById("delete_url");
    let divBtn = document.createElement("div");
    divBtn.setAttribute("class", "col-1 pb-2");

    let fieldBtn = document.createElement("div");
    fieldBtn.setAttribute("id", "Btn[" + nextFieldId + "]");
    fieldBtn.setAttribute("class", "btn btn-outline-primary");
    fieldBtn.setAttribute("onclick", "deleteImages('Images[" + nextFieldId + "]','Btn[" + nextFieldId + "]')");

    let i = document.createElement("i");
    i.setAttribute("class", "fas fa-trash");

    fieldBtn.appendChild(i);
    divBtn.appendChild(fieldBtn);
    containerBtn.appendChild(divBtn);
}

function deleteImages(idInput, idBtn) {
    document.getElementById(idInput).remove();
    document.getElementById(idBtn).remove();
}

function onclickhandler(value) {

    let container = document.getElementById("new_product");
    let divCount = container.getElementsByTagName("div").length;

    if (divCount === 0) {
        let div = document.createElement("div");
        div.setAttribute("class", "pb-2");

        let label = document.createElement("label");
        label.setAttribute("class", "control-label pt-2");
        label.setAttribute("style", "font-size:20px;");
        label.textContent = 'Новое изображение';

        div.appendChild(label);
        container.prepend(div);
    }

    document.getElementById("new_product_img").src = value.value;
}

