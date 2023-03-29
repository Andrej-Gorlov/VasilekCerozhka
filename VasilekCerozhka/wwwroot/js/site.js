// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//import ddImages from './AddImages.js';
//import eleteImages from './DeleteImages.js';
//window.addEventListener('DOMContentLoaded', () => {
//    AddImages();
//    DeleteImages(idInput, idBtn);   
//    const x = await import ('./AddImages.js');
//    let btn = document.getElementById('xxx');
//    btn.addEventListener('click', (idInput, idBtn, idImg) => {
//        eleteImages(idInput, idBtn, idImg);
//    });
//});


// add new input
function addImages() {

    // определяем контейнер для хранения полей
    let container = document.getElementById("second_images");
    let fieldCount = container.getElementsByTagName("input").length;
    let nextFieldId = fieldCount + 1;

    // здесь добавляем элемент, который будет хранить input
    let div = document.createElement("div");
    div.setAttribute("class", "form_input_secondary_custom mt-3");
    div.setAttribute("id", "Images[" + nextFieldId + "]");

    // создаем новое поле с новым id
    let input = document.createElement("input");
    input.setAttribute("name", "Images");
    input.setAttribute("type", "text");
    input.setAttribute("required", "required");
    input.setAttribute("autocomplete", "off");
    input.setAttribute("id", "img[" + nextFieldId + "]")
    input.setAttribute("oninput", "newimgproducts(this)");
    input.setAttribute("placeholder", "Введите url изображения");

    let leb = document.createElement("label");
    leb.setAttribute("for", "name");
    leb.setAttribute("class", "label_name_input_secondary");

    let span = document.createElement("span");
    span.setAttribute("class", "content_name_input_secondary");
    leb.appendChild(span);

    // добавляем поле в <div class="form-group"></div>
    div.appendChild(input);
    div.appendChild(leb);
    // добавляем <div class="form-group"><input ... /></div> в главный контейнер
    container.appendChild(div);

    let containerBtn = document.getElementById("delete_url");
    let divBtn = document.createElement("div");
    divBtn.setAttribute("class", "pb-1 container_btn_custom mt-3");
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

// delete input, btn, img
function deleteImages(idInput, idBtn, idImg) {

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

// add new img
function newimgproduct(value) {

    let container = document.getElementById("new_product");
    let divCount = container.getElementsByTagName("div").length;

    if (divCount === 0) {
        let div = document.createElement("div");
        div.setAttribute("class", "pb-2");
        div.setAttribute("id", "img_lebel_name");

        let label = document.createElement("label");
        label.setAttribute("class", "control-label pt-2");
        label.setAttribute("style", "font-size:20px;");
        label.textContent = 'Новое изображение';

        div.appendChild(label);
        container.prepend(div);
    }
    if (value.value === "") {
        document.getElementById("img_lebel_name").remove();
    }
    if (document.getElementById("new_product_img") === null && value.value != "") {

        let divImg = document.createElement("div");
        divImg.setAttribute("class", "effect_gloss_img");
        divImg.setAttribute("id", "div_effect_gloss_img");
        let img = document.createElement("img");
        img.setAttribute("src", value.value);
        img.setAttribute("id", "new_product_img");
        divImg.appendChild(img);
        container.appendChild(divImg);
    }
    else if (document.getElementById("new_product_img") != null && value.value != ""){
        document.getElementById("new_product_img").src = value.value;
    }
    if (value.value === "") {
        document.getElementById("div_effect_gloss_img").remove();
    }
}

// add new imges to carousel
function newimgproducts(value) {

    let containerEG = document.getElementById("new_products");

    if (document.getElementById("gloss_div") === null) {
        
        let divEG = document.createElement("div");
        divEG.setAttribute("id", "gloss_div");
        divEG.setAttribute("class", "effect_gloss_div");
        containerEG.appendChild(divEG);
    }

    let container = document.getElementById("gloss_div");

    let imgCount = container.getElementsByTagName("img").length;
    let nextImgId = imgCount + 1;

    let idImg = document.getElementById("elem_" + value.id);

    if (idImg === null) {

        let div = document.createElement("div");
        div.setAttribute("id", "elem_" + value.id);
        div.setAttribute("class", "carousel-item " + (nextImgId === 1 ? "active" : ""));
        div.setAttribute("data-bs-interval", "3900");

        let img = document.createElement("img")
        img.setAttribute("src", value.value);
        img.setAttribute("id", "new_" + value.id);
        img.setAttribute("alt", "Image" + value.id + "");
        img.setAttribute("class", "d-block w-100 h-100");

        div.appendChild(img);
        container.appendChild(div);
    }
    else {
        document.getElementById("new_" + value.id).src = value.value; 
    }

    if (imgCount === 0) {
        let div = document.createElement("div");
        div.setAttribute("class", "pb-2");
        div.setAttribute("id", "imges_lebel_name");

        let label = document.createElement("label");
        label.setAttribute("class", "control-label pt-2");
        label.setAttribute("style", "font-size:20px;");
        label.textContent = 'Новый список изображений';

        div.appendChild(label);
        containerEG.prepend(div);
    }
}

// custom selector
function editSelect() {
  if (document.getElementById("deleteInput") !== null) {
    let div = document.getElementById("select_custom");
    div.classList.remove("form_input_custom");

    document.getElementById("deleteInput").remove();

    document.getElementById("select-category").removeAttribute("hidden");
    document.getElementById("cuctom_opt").removeAttribute("hidden");

    let label = document.getElementById("lebel_custom");
    label.classList.remove("label_name_input");
    label.classList.add("label_name_select");

    let span = document.getElementById("span_custom");
    span.classList.remove("content_name_input");
    span.classList.add("content_name_select");

    setTimeout(deleteHidden, 300);
  }
}

function deleteHidden() {
  document.getElementById("select_custom").style.overflow = "";
}

$(".sel").each(function () {
  let reg;
  if (document.getElementById("select-category") != null) {
    reg = /form_input_custom sel/g;
  } else {
    reg = /sel/g;
  }

  $(this).children("select").css("display", "none");

  var $current = $(this);

  $(this)
    .find("option")
    .each(function (i) {
      if (i == 0) {
        $current.prepend(
          $("<div>", {
            class: $current.attr("class").replace(reg, "sel__box"),
          })
        );

        var placeholder = $(this).text();
        $current.prepend(
          $("<span>", {
            class: $current.attr("class").replace(reg, "sel__placeholder"),
            text: placeholder,
            "data-placeholder": placeholder,
          })
        );

        return;
      }

      $current.children("div").append(
        $("<span>", {
          class: $current.attr("class").replace(reg, "sel__box__options"),
          text: $(this).text(),
        })
      );
    });
});

// Toggling the `.active` state on the `.sel`.
$(".sel").click(function () {
  $(this).toggleClass("active");
});

// Toggling the `.selected` state on the options.
$(".sel__box__options").click(function () {
  var txt = $(this).text();
  var index = $(this).index();

  $(this).siblings(".sel__box__options").removeClass("selected");
  $(this).addClass("selected");

  var $currentSel = $(this).closest(".sel");
  $currentSel.children(".sel__placeholder").text(txt);
  $currentSel.children("select").prop("selectedIndex", index + 1);
});