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

// slider

function lerp({ x, y }, { x: targetX, y: targetY }) {
    const fraction = 0.2;
    x += (targetX - x) * fraction;
    y += (targetY - y) * fraction;
    return { x, y };
}
class Slider {
    constructor(el) {
        const imgClass = this.IMG_CLASS = 'slider__images-item';
        const textClass = this.TEXT_CLASS = 'slider__text-item';
        const activeImgClass = this.ACTIVE_IMG_CLASS = `${imgClass}--active`;
        const activeTextClass = this.ACTIVE_TEXT_CLASS = `${textClass}--active`;

        this.el = el;
        this.contentEl = document.getElementById('slider-content');
        this.onMouseMove = this.onMouseMove.bind(this);

        this.activeImg = el.getElementsByClassName(activeImgClass);
        this.activeText = el.getElementsByClassName(activeTextClass);
        this.images = el.getElementsByTagName('img');

        document.getElementById('slider-dots')
            .addEventListener('click', this.onDotClick.bind(this));

        document.getElementById('left')
            .addEventListener('click', this.prev.bind(this));

        document.getElementById('right')
            .addEventListener('click', this.next.bind(this));

        window.addEventListener('resize', this.onResize.bind(this));

        this.onResize();

        this.length = this.images.length;
        this.lastX = this.lastY = this.targetX = this.targetY = 0;
    }
    onResize() {
        const htmlStyles = getComputedStyle(document.documentElement);
        const mobileBreakpoint = htmlStyles.getPropertyValue('--mobile-bkp');

        const isMobile = this.isMobile = matchMedia(
            `only screen and (max-width: ${mobileBreakpoint})`
        ).matches;

        this.halfWidth = innerWidth / 2;
        this.halfHeight = innerHeight / 2;
        this.zDistance = htmlStyles.getPropertyValue('--z-distance');

        if (!isMobile && !this.mouseWatched) {
            this.mouseWatched = true;
            this.el.addEventListener('mousemove', this.onMouseMove);
            this.el.style.setProperty(
                '--img-prev',
                `url(${this.images[+this.activeImg[0].dataset.id - 1].src})`
            );
            this.contentEl.style.setProperty('transform', `translateZ(${this.zDistance})`);
        } else if (isMobile && this.mouseWatched) {
            this.mouseWatched = false;
            this.el.removeEventListener('mousemove', this.onMouseMove);
            this.contentEl.style.setProperty('transform', 'none');
        }
    }
    getMouseCoefficients({ pageX, pageY } = {}) {
        const halfWidth = this.halfWidth;
        const halfHeight = this.halfHeight;
        const xCoeff = ((pageX || this.targetX) - halfWidth) / halfWidth;
        const yCoeff = (halfHeight - (pageY || this.targetY)) / halfHeight;

        return { xCoeff, yCoeff }
    }
    onMouseMove({ pageX, pageY }) {
        this.targetX = pageX;
        this.targetY = pageY;

        if (!this.animationRunning) {
            this.animationRunning = true;
            this.runAnimation();
        }
    }
    runAnimation() {
        if (this.animationStopped) {
            this.animationRunning = false;
            return;
        }

        const maxX = 10;
        const maxY = 10;

        const newPos = lerp({
            x: this.lastX,
            y: this.lastY
        }, {
            x: this.targetX,
            y: this.targetY
        });

        const { xCoeff, yCoeff } = this.getMouseCoefficients({
            pageX: newPos.x,
            pageY: newPos.y
        });

        this.lastX = newPos.x;
        this.lastY = newPos.y;

        this.positionImage({ xCoeff, yCoeff });

        this.contentEl.style.setProperty('transform', `
        translateZ(${this.zDistance})
        rotateX(${maxY * yCoeff}deg)
        rotateY(${maxX * xCoeff}deg)
      `);

        if (this.reachedFinalPoint) {
            this.animationRunning = false;
        } else {
            requestAnimationFrame(this.runAnimation.bind(this));
        }
    }
    get reachedFinalPoint() {
        const lastX = ~~this.lastX;
        const lastY = ~~this.lastY;
        const targetX = this.targetX;
        const targetY = this.targetY;

        return (lastX == targetX || lastX - 1 == targetX || lastX + 1 == targetX)
            && (lastY == targetY || lastY - 1 == targetY || lastY + 1 == targetY);
    }
    positionImage({ xCoeff, yCoeff }) {
        const maxImgOffset = 1;
        const currentImage = this.activeImg[0].children[0];

        currentImage.style.setProperty('transform', `
        translateX(${maxImgOffset * -xCoeff}em)
        translateY(${maxImgOffset * yCoeff}em)
      `);
    }
    onDotClick({ target }) {
        if (this.inTransit) return;

        const dot = target.closest('.slider__nav-dot');

        if (!dot) return;

        const nextId = dot.dataset.id;
        const currentId = this.activeImg[0].dataset.id;

        if (currentId == nextId) return;

        this.startTransition(nextId);

        clearTimeout(timer);
        setTimeout(autoSlide, 5000);
    }
    transitionItem(nextId) {
        function onImageTransitionEnd(e) {
            e.stopPropagation();

            nextImg.classList.remove(transitClass);

            self.inTransit = false;

            this.className = imgClass;
            this.removeEventListener('transitionend', onImageTransitionEnd);
        }

        const self = this;
        const el = this.el;
        const currentImg = this.activeImg[0];
        const currentId = currentImg.dataset.id;
        const imgClass = this.IMG_CLASS;
        const textClass = this.TEXT_CLASS;
        const activeImgClass = this.ACTIVE_IMG_CLASS;
        const activeTextClass = this.ACTIVE_TEXT_CLASS;
        const subActiveClass = `${imgClass}--subactive`;
        const transitClass = `${imgClass}--transit`;
        const nextImg = el.querySelector(`.${imgClass}[data-id='${nextId}']`);
        const nextText = el.querySelector(`.${textClass}[data-id='${nextId}']`);

        let outClass = '';
        let inClass = '';

        this.animationStopped = true;

        nextText.classList.add(activeTextClass);

        el.style.setProperty('--from-left', nextId);

        currentImg.classList.remove(activeImgClass);
        currentImg.classList.add(subActiveClass);

        if (currentId < nextId) {
            outClass = `${imgClass}--next`;
            inClass = `${imgClass}--prev`;
        } else {
            outClass = `${imgClass}--prev`;
            inClass = `${imgClass}--next`;
        }

        nextImg.classList.add(outClass);

        requestAnimationFrame(() => {
            nextImg.classList.add(transitClass, activeImgClass);
            nextImg.classList.remove(outClass);

            this.animationStopped = false;
            this.positionImage(this.getMouseCoefficients());

            currentImg.classList.add(transitClass, inClass);
            currentImg.addEventListener('transitionend', onImageTransitionEnd);
        });

        if (!this.isMobile)
            this.switchBackgroundImage(nextId);
    }
    startTransition(nextId) {
        function onTextTransitionEnd(e) {
            if (!e.pseudoElement) {
                e.stopPropagation();

                requestAnimationFrame(() => {
                    self.transitionItem(nextId);
                });

                this.removeEventListener('transitionend', onTextTransitionEnd);
            }
        }

        if (this.inTransit) return;

        const activeText = this.activeText[0];
        const backwardsClass = `${this.TEXT_CLASS}--backwards`;
        const self = this;

        this.inTransit = true;

        activeText.classList.add(backwardsClass);
        activeText.classList.remove(this.ACTIVE_TEXT_CLASS);
        activeText.addEventListener('transitionend', onTextTransitionEnd);

        requestAnimationFrame(() => {
            activeText.classList.remove(backwardsClass);
        });
    }
    next() {
        if (this.inTransit) return;

        let nextId = +this.activeImg[0].dataset.id + 1;

        if (nextId > this.length)
            nextId = 1;

        this.startTransition(nextId);
    }
    prev() {
        if (this.inTransit) return;

        let nextId = +this.activeImg[0].dataset.id - 1;

        if (nextId < 1)
            nextId = this.length;

        this.startTransition(nextId);
    }
    switchBackgroundImage(nextId) {
        function onBackgroundTransitionEnd(e) {
            if (e.target === this) {
                this.style.setProperty('--img-prev', imageUrl);
                this.classList.remove(bgClass);
                this.removeEventListener('transitionend', onBackgroundTransitionEnd);
            }
        }

        const bgClass = 'slider--bg-next';
        const el = this.el;
        const imageUrl = `url(${this.images[+nextId - 1].src})`;

        el.style.setProperty('--img-next', imageUrl);
        el.addEventListener('transitionend', onBackgroundTransitionEnd);
        el.classList.add(bgClass);
    }
}

const sliderEl = document.getElementById('slider');
const slider = new Slider(sliderEl);

let timer = 0;
function autoSlide() {
    requestAnimationFrame(() => {
        slider.next();
    });
    timer = setTimeout(autoSlide, 5000);
}
timer = setTimeout(autoSlide, 5000); 