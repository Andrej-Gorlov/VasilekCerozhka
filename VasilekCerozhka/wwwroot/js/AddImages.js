function AddImages() {

    let container = document.getElementById("second_images");
    let fieldCount = container.getElementsByTagName("input").length;
    let nextFieldId = fieldCount + 1;

    // здесь добавляем элемент, который будет хранить input
    let div = document.createElement("div");
    div.setAttribute("class", "form-group pb-2");
    div.setAttribute("id", "Images[" + nextFieldId + "]");

    // создаем новое поле с новым id
    let field = document.createElement("input");
    field.setAttribute("class", "form-control");
    field.setAttribute("name", "Images");
    field.setAttribute("type", "text");
    field.setAttribute("id", "img[" + nextFieldId + "]")
    field.setAttribute("oninput", "newimgproducts(this)");
    field.setAttribute("placeholder", "Введите url изображения");

    // добавляем поле в <div class="form-group"></div>
    div.appendChild(field);
    // добавляем <div class="form-group"><input ... /></div> в главный контейнер
    container.appendChild(div);

    let containerBtn = document.getElementById("delete_url");
    let divBtn = document.createElement("div");
    divBtn.setAttribute("class", "pb-2 container_btn_custom");
    divBtn.setAttribute("id", "Btn[" + nextFieldId + "]");

    let fieldBtn = document.createElement("div");
    fieldBtn.setAttribute("class", "btn_custom i_custom");
    fieldBtn.setAttribute("onclick", "deleteImages('Images[" + nextFieldId + "]','Btn[" + nextFieldId + "]','elem_img[" + nextFieldId + "]')");

    let i = document.createElement("i");
    i.setAttribute("class", "fas fa-trash");

    fieldBtn.appendChild(i);
    divBtn.appendChild(fieldBtn);
    containerBtn.appendChild(divBtn);
}

export default AddImages;