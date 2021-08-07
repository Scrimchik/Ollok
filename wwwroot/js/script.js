makeColorFilter();
makeColorActiveAjax();
getUrlCorrect();
makePriceActiveAjax();
makeSizeActiveAjax();
getWishlistCount();
getCartCount();
/*wish-list*/
$(document).on('click', '.product-item__heart', function (e) {
	e.preventDefault();
	if ($(this).children('.heart').attr('class') == 'heart-notfull heart') {
		$(this).children('.heart').children().attr('d', 'M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314z');
		$(this).children('.heart').attr('class', 'heart-full heart');
		$(this).children('.product-item__heart-quantity').text(parseInt($(this).children('.product-item__heart-quantity').text()) + 1);
	}
	else {
		$(this).children('.heart').children().attr('d', 'm8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z');
		$(this).children('.heart').attr('class', 'heart-notfull heart');
		$(this).children('.product-item__heart-quantity').text(parseInt($(this).children('.product-item__heart-quantity').text()) - 1);
	}
	$.ajax({
		type: "Post",
		url: "/Wishlist/AddProductToWishList",
		data: { productId: parseInt($(this).children('.heart').attr('data-id')) },
	}).done(function () {
		getWishlistCount();
	});
});

$('.wishlist-button').click(function () {
	$.ajax({
		type: "Post",
		url: "/Wishlist/GetWishlist"
	}).done(function (html) {
		$('.wishlist-ajax').html(html);
		$('.wishlist, .wishlist-mask').css('display', 'block');
	})
});
$('.wishlist-ajax').on('click', '.basket__close, .wishlist-mask', function () {
	$('.wishlist').css('display', 'none');
	$('.wishlist, .wishlist-mask').css('display', 'none');
});
$('#addToWishlist').click(function () {
	$.ajax({
		type: "Post",
		url: "/Wishlist/AddProductToWishList",
		data: { productId: parseInt($(this).attr('data-id')) },
	}).done(function () {
		getWishlistCount();
	})
});

$('.wishlist-ajax').on('click', '.wishlist-product__size', function () {
	$(this).parent().children('.wishlist-product__size').removeClass('wishlist-product__size_active');
	$(this).addClass('wishlist-product__size_active');
});

$('.wishlist-ajax').on('click', '.wishlist-product__button', function () {
	if ($(this).parent().children('.wishlist-product__sizes').children('.wishlist-product__sizes-block').children('.wishlist-product__size').hasClass('wishlist-product__size_active')) {
		$.ajax({
			type: "Post",
			url: "/Cart/AddProductToCart",
			data: { productId: $(this).attr('data-id'), sizeValue: $(this).parent().children('.wishlist-product__sizes').children('.wishlist-product__sizes-block').children('.wishlist-product__size_active').text() }
		}).done(function (html) {
			$.ajax({
				type: "Post",
				url: "/Cart/GetCart"
			}).done(function (html) {
				$('.basket-ajax').html(html);
				getCartCount();
			}).always(function () {
				$('.basket, .basket__mask').css('display', 'block');
			})
		});
	}
	else {
		$('.cart-notice_none').removeClass('cart-notice_none').addClass('cart-notice');
		setInterval(function () {
			$('.cart-notice').removeClass('cart-notice').addClass('cart-notice_none');
		}, 3000)
	}
});
/*wish-list*/
/*basket*/
$('.basket-button').click(function () {
	$.ajax({
		type: "Get",
		url: "/Cart/GetCart"
	}).done(function (html) {
		$('.basket-ajax').html(html);
	}).always(function () {
		$('.basket, .basket__mask').css('display', 'block');
    })
	
});

$('.basket-ajax').on('click', '.basket__close, .basket__mask, .basket-footer__cont',function () {
	$('.basket, .basket__mask').css({ 'display': 'none' });
});

$('.basket-ajax').on('click', '.basket-product__delete', function () {
	$.ajax({
		type: "Post",
		url: "/Cart/DeleteProductFromCart",
		data: { cartLineId: $(this).attr('data-id') }
	}).done(function (html) {
		$('.basket-ajax').html(html);
		getCartCount();
	}).always(function () {
		$('.basket, .basket__mask').css('display', 'block');
	})
});

$('#addToCart').click(function () {
	if ($('.product-sizes__size').hasClass('product-sizes__size_active')) {
		$.ajax({
			type: "Post",
			url: "/Cart/AddProductToCart",
			data: { productId: $(this).attr('data-id'), sizeValue: $('.product-sizes__size_active').text() }
		}).done(function (html) {
			$.ajax({
				type: "Get",
				url: "/Cart/GetCart"
			}).done(function (html) {
				$('.basket-ajax').html(html);
				getCartCount();
			}).always(function () {
				$('.basket, .basket__mask').css('display', 'block');
			})
		});
	}
	else {
		$('.cart-notice_none').removeClass('cart-notice_none').addClass('cart-notice');
		setInterval(function () {
			$('.cart-notice').removeClass('cart-notice').addClass('cart-notice_none');
        }, 3000)
    }
});
$('.product-sizes__size').click(function () {
	$('.product-sizes__size').removeClass('product-sizes__size_active');
	$(this).addClass('product-sizes__size_active');
});

$('.basket-ajax').on('click', '.product-quantity__plus', function () {
	$.ajax({
		type: "Get",
		url: "/Cart/AddProductCount",
		data: { cartLineId: $(this).attr('data-id') }
	}).done(function (html) {
		$('.basket-ajax').html(html);
	}).always(function () {
		$('.basket, .basket__mask').css('display', 'block');
	})
})

$('.basket-ajax').on('click', '.product-quantity__minus', function () {
	$.ajax({
		type: "Get",
		url: "/Cart/RemoveProductCount",
		data: { cartLineId: $(this).attr('data-id') }
	}).done(function (html) {
		$('.basket-ajax').html(html);
		getCartCount()
	}).always(function () {
		$('.basket, .basket__mask').css('display', 'block');
	})
})
function getCartCount() {
	$.ajax({
		type: "Get",
		url: "/Cart/GetCartCount"
	}).done(function (cartCount) {
		if (cartCount != 0)
			$('#cartCount').css('display', 'flex').text(cartCount);
		else
			$('#cartCount').css('display', 'none').text(cartCount);
	})
}
/*basket*/
/*product-selector*/
/*sorting*/
$(document).on("click", "#sorting .product-selecter__button", function () {
	if ($('#sorting').children('.selecter-choice').hasClass('selecter-choice_visible'))
		closeSelector($('#sorting'));
	else
		openSelector($('#sorting'));
});

$(document).on("click", '#sorting .selecter-choice .selecter-choice__item', function () {
	$('#sorting').children('.selecter-choice').children('.selecter-choice__item').removeClass('selecter-choice__item_active');
	$(this).addClass('selecter-choice__item_active');
	$('#sorting').children('.product-selecter__button').children('.product-selecter__title').text($(this).text());
	closeSelectorAndMakeButtonSelected($('#sorting'));
});
$(document).click(function (e) {
	if (!$('#sorting').is(e.target) &&
		$('#sorting').has(e.target).length === 0 &&
		$('#sorting').children('.selecter-choice').hasClass('selecter-choice_visible')) {
		closeSelectorAndMakeButtonSelected($('#sorting'));
	}
});
/*sorting*/
/*size*/
$(document).on("click", '#size-selecter .product-selecter__button', function () {
	if ($('#size-selecter').children('.selecter-choice').hasClass('selecter-choice_visible'))
		addProductSizeToButton();
	else
		openSelector($('#size-selecter'));
});

$(document).on('click', '#size .selecter-choice__item', function () {
	if ($(this).hasClass('selecter-choice__item_check-box'))
		$(this).removeClass('selecter-choice__item_check-box').addClass('selecter-choice__item_active-check-box');
	else
		$(this).removeClass('selecter-choice__item_active-check-box').addClass('selecter-choice__item_check-box');
});

$(document).on('click', '#size-selecter-button', function () {
	addProductSizeToButton();
});
$(document).click(function (e) {
	if (!$('#size-selecter').is(e.target) &&
		$('#size-selecter').has(e.target).length === 0 &&
		$('#size-selecter').children('.selecter-choice').hasClass('selecter-choice_visible')) {
		addProductSizeToButton();
	}
});
/*size*/
/*price*/
$(document).on('click', '#price-selecter .product-selecter__button', function () {
	if ($('#price-selecter').children('.selecter-choice').hasClass('selecter-choice_visible'))
		addProductPriceToButton();
	else
		openSelector($('#price-selecter'));
});

$(document).on('click', '#price-selecter-button',function () {
	addProductPriceToButton();
});

$(document).mousedown(function (e) {
	if (!$('#price-selecter').is(e.target) &&
		$('#price-selecter').has(e.target).length === 0 &&
		$('#price-selecter').children('.selecter-choice').hasClass('selecter-choice_visible')) {
		addProductPriceToButton();
	}
});
/*slider*/
makeSlider();
/*slider*/
/*price*/
/*color-selecter*/
$(document).on("click", "#color-selecter .product-selecter__button", function () {
	if ($('#color-selecter').children('.selecter-choice').hasClass('selecter-choice_visible')) {
		addColorActiveToButton();
	}
	else {
		openSelector($('#color-selecter'));
	}
});

$(document).on('click', '.selecter-choice__color',function () {
	makeColorActive($(this));
});

$(document).on('click', '#color-selecter-button',function () {
	addColorActiveToButton();
});

$(document).mousedown(function (e) {
	if (!$('#color-selecter').is(e.target) &&
		$('#color-selecter').has(e.target).length === 0 &&
		$('#color-selecter').children('.selecter-choice').hasClass('selecter-choice_visible')) {
		addColorActiveToButton();
	}
});
/*color-selecter*/
/*product-selector*/
/*slider-photo*/
$('#next').click(function () {
	let indexOfselectedPhoto = $('.slider__img_selected').index();
	let image = $('.slider__img');
	image.eq(indexOfselectedPhoto).removeClass('slider__img_selected');
	if (indexOfselectedPhoto + 1 == image.length) {
		image.eq(0).addClass('slider__img_selected');
	}
	else {
		image.eq(indexOfselectedPhoto + 1).addClass('slider__img_selected');
	}
});
$('#previous').click(function () {
	let indexOfselectedPhoto = $('.slider__img_selected').index();
	let image = $('.slider__img');
	image.eq(indexOfselectedPhoto).removeClass('slider__img_selected');
	if (indexOfselectedPhoto - 1 == image.length) {
		image.eq(0).addClass('slider__img_selected');
	}
	else {
		image.eq(indexOfselectedPhoto - 1).addClass('slider__img_selected');
	}
});

/*slider-photo*/
function openSelector(id) {
	id.children('.product-selecter__button').removeClass('product-selecter__button_non-active').removeClass('product-selecter__button_selected').removeClass('product-selecter__button_selected-ajax').addClass('product-selecter__button_active')
		.children('.product-selecter__icon').attr('viewBox', '0 0 284.929 284.929').children().attr('d', 'M282.082,195.285L149.028,62.24c-1.901-1.903-4.088-2.856-6.562-2.856s-4.665,0.953-6.567,2.856L2.856,195.285   C0.95,197.191,0,199.378,0,201.853c0,2.474,0.953,4.664,2.856,6.566l14.272,14.271c1.903,1.903,4.093,2.854,6.567,2.854   c2.474,0,4.664-0.951,6.567-2.854l112.204-112.202l112.208,112.209c1.902,1.903,4.093,2.848,6.563,2.848   c2.478,0,4.668-0.951,6.57-2.848l14.274-14.277c1.902-1.902,2.847-4.093,2.847-6.566   C284.929,199.378,283.984,197.188,282.082,195.285z');
	id.children('.selecter-choice').removeClass('selecter-choice_non-visible').removeClass('selecter-choice_non-visible-ajax').addClass('selecter-choice_visible');
}
function openFilterSelecter(id) {
	id.children('.filter-selecter').css({ 'display': 'block' });
	id.children('.filter__button').children('.filter__icon').children().children().attr('d', 'M282.082,195.285L149.028,62.24c-1.901-1.903-4.088-2.856-6.562-2.856s-4.665,0.953-6.567,2.856L2.856,195.285   C0.95,197.191,0,199.378,0,201.853c0,2.474,0.953,4.664,2.856,6.566l14.272,14.271c1.903,1.903,4.093,2.854,6.567,2.854   c2.474,0,4.664-0.951,6.567-2.854l112.204-112.202l112.208,112.209c1.902,1.903,4.093,2.848,6.563,2.848   c2.478,0,4.668-0.951,6.57-2.848l14.274-14.277c1.902-1.902,2.847-4.093,2.847-6.566   C284.929,199.378,283.984,197.188,282.082,195.285z');
}
function closeFilterSelecter(id) {
	id.children('.filter-selecter').css({ 'display': 'none' });
	id.children('.filter__button').children('.filter__icon').children().children().attr('d', 'M282.082,76.511l-14.274-14.273c-1.902-1.906-4.093-2.856-6.57-2.856c-2.471,0-4.661,0.95-6.563,2.856L142.466,174.441   L30.262,62.241c-1.903-1.906-4.093-2.856-6.567-2.856c-2.475,0-4.665,0.95-6.567,2.856L2.856,76.515C0.95,78.417,0,80.607,0,83.082   c0,2.473,0.953,4.663,2.856,6.565l133.043,133.046c1.902,1.903,4.093,2.854,6.567,2.854s4.661-0.951,6.562-2.854L282.082,89.647   c1.902-1.903,2.847-4.093,2.847-6.565C284.929,80.607,283.984,78.417,282.082,76.511z');
}
function closeSelector(id) {
	id.children('.product-selecter__button').removeClass('product-selecter__button_selected').removeClass('product-selecter__button_active').addClass('product-selecter__button_non-active')
		.children('.product-selecter__icon').attr('viewBox', '0 0 284.929 284.929').children().attr('d', 'M282.082,76.511l-14.274-14.273c-1.902-1.906-4.093-2.856-6.57-2.856c-2.471,0-4.661,0.95-6.563,2.856L142.466,174.441   L30.262,62.241c-1.903-1.906-4.093-2.856-6.567-2.856c-2.475,0-4.665,0.95-6.567,2.856L2.856,76.515C0.95,78.417,0,80.607,0,83.082   c0,2.473,0.953,4.663,2.856,6.565l133.043,133.046c1.902,1.903,4.093,2.854,6.567,2.854s4.661-0.951,6.562-2.854L282.082,89.647   c1.902-1.903,2.847-4.093,2.847-6.565C284.929,80.607,283.984,78.417,282.082,76.511z');
	id.children('.selecter-choice').removeClass('selecter-choice_visible').addClass('selecter-choice_non-visible');
}

function closeSelectorAndMakeButtonSelected(id) {
	id.children('.product-selecter__button').removeClass('product-selecter__button_active').addClass('product-selecter__button_selected')
		.children('.product-selecter__icon').attr('viewBox', '0 0 284.929 284.929').children().attr('d', 'M282.082,76.511l-14.274-14.273c-1.902-1.906-4.093-2.856-6.57-2.856c-2.471,0-4.661,0.95-6.563,2.856L142.466,174.441   L30.262,62.241c-1.903-1.906-4.093-2.856-6.567-2.856c-2.475,0-4.665,0.95-6.567,2.856L2.856,76.515C0.95,78.417,0,80.607,0,83.082   c0,2.473,0.953,4.663,2.856,6.565l133.043,133.046c1.902,1.903,4.093,2.854,6.567,2.854s4.661-0.951,6.562-2.854L282.082,89.647   c1.902-1.903,2.847-4.093,2.847-6.565C284.929,80.607,283.984,78.417,282.082,76.511z');
	id.children('.selecter-choice').removeClass('selecter-choice_visible').addClass('selecter-choice_non-visible');
}
function closeSelectorAndMakeButtonSelectedAjax(id) {
	id.children('.product-selecter__button').removeClass('product-selecter__button_active').addClass('product-selecter__button_selected-ajax')
		.children('.product-selecter__icon').attr('viewBox', '0 0 284.929 284.929').children().attr('d', 'M282.082,76.511l-14.274-14.273c-1.902-1.906-4.093-2.856-6.57-2.856c-2.471,0-4.661,0.95-6.563,2.856L142.466,174.441   L30.262,62.241c-1.903-1.906-4.093-2.856-6.567-2.856c-2.475,0-4.665,0.95-6.567,2.856L2.856,76.515C0.95,78.417,0,80.607,0,83.082   c0,2.473,0.953,4.663,2.856,6.565l133.043,133.046c1.902,1.903,4.093,2.854,6.567,2.854s4.661-0.951,6.562-2.854L282.082,89.647   c1.902-1.903,2.847-4.093,2.847-6.565C284.929,80.607,283.984,78.417,282.082,76.511z');
	id.children('.selecter-choice').removeClass('selecter-choice_visible').addClass('selecter-choice_non-visible-ajax');
}
function addProductSizeToButton() {
	let sizes = [];

	$('.selecter-choice__item_active-check-box').each(function () {
		sizes.push($(this).text());
	});
	if (sizes.length != 0) {
		$('#size-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Размер: ' + sizes.join(','));
		closeSelectorAndMakeButtonSelected($('#size-selecter'));
		setAjax(getUrlVars()["Colors"] || null, sizes.join('_'), getUrlVars()["Price"] || null);
	}
	else {
		$('#size-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Размер');
		closeSelector($('#size-selecter'));
		setAjax(getUrlVars()["Colors"] || null, null, getUrlVars()["Price"] || null);
	}
}
function addProductSizeToButtonWithoutAjax() {
	let sizes = [];

	$('.selecter-choice__item_active-check-box').each(function () {
		sizes.push($(this).text());
	});
	if (sizes.length != 0) {
		$('#size-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Размер: ' + sizes.join(','));
		closeSelectorAndMakeButtonSelectedAjax($('#size-selecter'));
	}
	else {
		$('#size-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Размер');
		closeSelector($('#size-selecter'));
	}
}
function addProductPriceToButton() {
	if ($('#from').val() == $('#from').attr('data-min') && $('#to').val() == $('#to').attr('data-max')) {
		$('#price-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Цена');
		closeSelector($('#price-selecter'));
		setAjax(getUrlVars()["Colors"] || null, getUrlVars()["Sizes"] || null, null);
	}
	else {
		$('#price-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Цена: ' + $('#from').val() + ' — ' + $('#to').val());
		closeSelectorAndMakeButtonSelected($('#price-selecter'));
		setAjax(getUrlVars()["Colors"] || null, getUrlVars()["Sizes"] || null, $('#from').val() + '-' + $('#to').val());
	}
}
function addProductPriceToButtonWithoutAjax() {
	$('#price-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Цена: ' + getUrlVars()["Price"]);
	closeSelectorAndMakeButtonSelectedAjax($('#price-selecter'));
}
function makeColorFilter() {
	$('.selecter-choice__color').each(function () {
		$(this).css({ 'background-color': $(this).attr('data-color') })
	});
}
function makeColorActive(color) {
	if (color.hasClass('selecter-choice__color_active'))
		color.removeClass('selecter-choice__color_active');
	else
		color.addClass('selecter-choice__color_active');
}
function addColorActiveToButton() {
	let colors = 0;
	let Colors = [];

	$('.selecter-choice__color').each(function () {
		if ($(this).hasClass('selecter-choice__color_active')) {
			colors += 1;
			Colors.push($(this).attr('data-color'));
		}
	});
	if (colors != 0) {
		$('#color-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Цвет: ' + colors);
		closeSelectorAndMakeButtonSelected($('#color-selecter'));
		setAjax(Colors.join('_'), getUrlVars()["Sizes"] || null, getUrlVars()["Price"] || null);
	}
	else {
		$('#color-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Цвет');
		closeSelector($('#color-selecter'));
		setAjax(null, getUrlVars()["Sizes"] || null, getUrlVars()["Price"] || null);
	}
}
function addColorActiveToButtonWithoutAjax() {
	let colors = 0;
	let Colors = [];

	$('.selecter-choice__color').each(function () {
		if ($(this).hasClass('selecter-choice__color_active')) {
			colors += 1;
			Colors.push($(this).attr('data-color'));
		}
	});
	if (colors != 0) {
		$('#color-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Цвет: ' + colors);
		closeSelectorAndMakeButtonSelectedAjax($('#color-selecter'));
	}
	else {
		$('#color-selecter').children('.product-selecter__button').children('.product-selecter__title').text('Цвет');
		closeSelector($('#color-selecter'));
	}
}
function makeSlider() {
	let priceUrl = getUrlVars()["Price"] || "";
	let priceArr = priceUrl.split('-');
	var inputFrom = $('.ajax-product #from');
	var inputTo = $('.ajax-product #to');
	var inputFromFilter = $('#from-filter')
	var inputToFilter = $('#to-filter');
	var from = 0;
	var to = 0;
	let fromInput = parseInt(priceArr[0]);
	let toInput = parseInt(priceArr[1]);
	var min = parseInt(inputFrom.attr('data-min'));
	var max = parseInt(inputTo.attr('data-max'));
	var instance;
	var instanceFilter;
	$('.ajax-product .js-range-slider').ionRangeSlider({
		type: "double",
		skin: 'big',
		grid: false,
		hide_min_max: true,
		hide_from_to: true,
		min: min,
		max: max,
		from: fromInput,
		to: toInput,
		onStart: updateInputs,
		onChange: updateInputs,
		onFinish: updateInputs
	});
	$('.js-range-slider-filter').ionRangeSlider({
		type: "double",
		skin: 'big',
		grid: false,
		hide_min_max: true,
		hide_from_to: true,
		min: min,
		max: max,
		from: fromInput,
		to: toInput,
		onStart: updateFilterInputs,
		onChange: updateFilterInputs,
		onFinish: updateInputs
	});
	instance = $(".js-range-slider").data("ionRangeSlider");
	instanceFilter = $('.js-range-slider-filter').data("ionRangeSlider");

	function updateInputs(data) {
		from = data.from;
		to = data.to;

		inputFrom.prop("value", from);
		inputTo.prop("value", to);
	}

	function updateFilterInputs(data) {
		from = data.from;
		to = data.to;

		inputFromFilter.prop("value", from);
		inputToFilter.prop("value", to);
	}

	inputFrom.keyup(function () {
		var val = $(this).prop("value");

		if (val > to) {
			val = to;
		}

		instance.update({
			from: val
		});

		$(this).prop("value", val);
	});

	inputTo.keyup(function () {
		var val = $(this).prop("value");

		if (val > max) {
			val = max;
		}

		instance.update({
			to: val
		});

		$(this).prop("value", val);
	});

	inputFromFilter.keyup(function () {
		var val = $(this).prop("value");

		if (val > to) {
			val = to;
		}

		instanceFilter.update({
			from: val
		});

		$(this).prop("value", val);
	});
	inputToFilter.keyup(function () {
		var val = $(this).prop("value");

		if (val > max) {
			val = max;
		}

		instanceFilter.update({
			to: val
		});

		$(this).prop("value", val);
	});
};
function setAjax(Colors, Sizes, Price) {
	var baseUrl = window.location.protocol + "//" + window.location.host + window.location.pathname + '?';
	let colorsString = Colors != null ? 'Colors=' + Colors : null;
	let sizeString = Sizes != null ? 'Sizes=' + Sizes : null;
	let priceString = Price != null ? 'Price=' + Price : null

	var newUrl = baseUrl + (colorsString || '');
	$.ajax({
		type: "Get",
		url: "/Product/List",
		data: { Colors: Colors, Sizes: Sizes, Price: Price, categoryName: $('.category').attr('data-category-select'), isAjax: true, productPage : 1 },
	}).done(function (html) {
		$('.ajax-product').html(html);
		makeSlider();
		makeColorFilter();
		makeColorActiveAjax();
		makeSizeActiveAjax();
		getUrlCorrect();
		makePriceActiveAjax()
	});

	if (colorsString != null && sizeString != null)
		newUrl += '&' + (sizeString || '');
	else
		newUrl += sizeString || '';

	if ((colorsString != null || sizeString != null) && priceString != null)
		newUrl += '&' + (priceString || '');
	else
		newUrl += (priceString || '');

	history.pushState(null, null, newUrl);
}
function getUrlVars() {
	var vars = {};
	var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
		vars[key] = value;
	});
	return vars;
}
function makeColorActiveAjax() {
	let colors = getUrlVars()["Colors"];
	if (colors != undefined) {
		let colorsArray = colors.split('_');

		for (let i = 0; i < colorsArray.length; i++) {
			$('.ajax-product .selecter-choice__color').each(function () {
				if ($(this).attr('data-color') == colorsArray[i])
					$(this).addClass('selecter-choice__color_active');
			});
			$('.mobile-selecter-choice__color').each(function () {
				if ($(this).attr('data-color') == colorsArray[i])
					$(this).addClass('mobile-selecter-choice__color_active');
			});
		}
		addColorActiveToButtonWithoutAjax();
	}
}
function makeSizeActiveAjax() {
	let sizes = getUrlVars()["Sizes"];
	if (sizes != undefined) {
		let sizesArray = sizes.split('_');

		for (let i = 0; i < sizesArray.length; i++) {
			$('.ajax-product .selecter-choice__item_check-box').each(function () {
				if ($(this).text() == sizesArray[i])
					$(this).removeClass('selecter-choice__item_check-box').addClass('selecter-choice__item_active-check-box');
			});
			$('.mobile-selecter-choice__item_check-box').each(function () {
				if ($(this).text() == sizesArray[i])
					$(this).removeClass('mobile-selecter-choice__item_check-box').addClass('mobile-selecter-choice__item_active-check-box');
			});
		}
		addProductSizeToButtonWithoutAjax();
	}
}
function makePriceActiveAjax() {
	let price = getUrlVars()["Price"];
	if (price != undefined) {
		addProductPriceToButtonWithoutAjax();
	}
}
function getUrlCorrect() {
	let colorString = getUrlVars()["Colors"] != null ? 'Colors=' + getUrlVars()["Colors"] : null;
	let sizeString = getUrlVars()["Sizes"] != null ? 'Sizes=' + getUrlVars()["Sizes"] : null;
	let priceString = getUrlVars()["Price"] != null ? 'Price=' + getUrlVars()["Price"] : null;
	let newUrl = '?' + (colorString || ''); 

	if (colorString != null && sizeString != null)
		newUrl += '&' + (sizeString || '');
	else
		newUrl += sizeString || '';

	if ((colorString != null || sizeString != null) && priceString != null)
		newUrl += '&' + (priceString || '');
	else
		newUrl += (priceString || '');
	$('.ajax-product .product-pages a').each(function () {
		let oldUrl = $(this).attr('href');
		let urlArray = oldUrl.split('/');
		if (urlArray[1] == $('.category').attr('data-category-select'))
			$(this).attr('href', oldUrl + newUrl);
		else if ($('.category').attr('data-category-select') != '')
			$(this).attr('href', "/" + $('.category').attr('data-category-select') + oldUrl + newUrl);
		else
			$(this).attr('href',$('.category').attr('data-category-select') + oldUrl + newUrl);
	});
}
function getWishlistCount() {
	$.ajax({
		type: "Get",
		url: "/Wishlist/CheckWishlistCount"
	}).done(function (result) {
		if (result != 0) {
			$('#wishlistCount').css('display', 'flex').text(result);
		}
		else {
			$('#wishlistCount').css('display', 'none').text(result);
        }
	});
}
$('#poshta').click(function () {
	$('.order__poshta').css('display', 'block');
});
$('#pickup').click(function () {
	$('.order__poshta').css('display', 'none');
});
/*venobox*/
$('.venobox').click(function (e) {
	e.preventDefault;
});
$('.venobox').venobox(); 
/*venobox*/