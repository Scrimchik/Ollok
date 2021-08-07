$('.product-editing').on('change', '#input__file',function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            var addImgBlock = $('.product-editing__add-img');
            $('.product-editing__add-img').remove();
            reader.onload = function (e) {
            	$('.product-editing__img-block').append('<div class="product-editing__img"><img src="' + e.target.result + '" alt=""></div>');
            	$('.product-editing__img-block').append(addImgBlock);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });