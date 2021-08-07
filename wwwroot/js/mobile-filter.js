/*mobile-filter*/
$(document).on('click', '.filter-button', function () {
	$('.filter').css({ 'display': 'block' });
});

$(document).on('click', '.filter-header__close', function () {
	$('.filter').css({ 'display': 'none' });
});

/*sorting-filter*/
$(document).on('click', '#filter-sorting > .filter__button', function () {
	if ($('#filter-sorting').children('.filter-selecter').css('display') == 'none')
		openFilterSelecter($('#filter-sorting'));
	else
		closeFilterSelecter($('#filter-sorting'));
});

$(document).on('click', '.filter-selecter__item', function () {
	$('#filter-sorting').children('.filter-selecter').children('.filter-selecter__item').removeClass('selecter-choice__item_active');
	$(this).addClass('selecter-choice__item_active');

});
/*sorting-filter*/
/*size-filter*/
$(document).on('click', '#filter-size > .filter__button',function () {
	if ($('#filter-size').children('.filter-selecter').css('display') == 'none')
		openFilterSelecter($('#filter-size'));
	else
		closeFilterSelecter($('#filter-size'));
});
$(document).on('click', '#size-filter-button',function () {
	closeFilterSelecter($('#filter-size'));
	setSizeAjax();
	$('.filter').css({ 'display': 'none' });
});
$(document).on('click', '.mobile-selecter-choice__item_check-box',function () {
	if ($(this).hasClass('mobile-selecter-choice__item_check-box'))
		$(this).removeClass('mobile-selecter-choice__item_check-box').addClass('mobile-selecter-choice__item_active-check-box');
	else
		$(this).removeClass('mobile-selecter-choice__item_active-check-box').addClass('mobile-selecter-choice__item_check-box');
})

function setSizeAjax() {
	let sizes = [];

	$('.mobile-selecter-choice__item_active-check-box').each(function () {
		sizes.push($(this).text());
	});
	if(sizes.length != 0)
		setAjax(getUrlVars()["Colors"] || null, sizes.join('_'), getUrlVars()["Price"] || null);
	else
		setAjax(getUrlVars()["Colors"] || null, null, getUrlVars()["Price"] || null);
}
/*size-filter*/
/*price-filter*/
$(document).on('click', '#filter-price > .filter__button',function () {
	if ($('#filter-price').children('.filter-selecter').css('display') == 'none')
		openFilterSelecter($('#filter-price'));
	else
		closeFilterSelecter($('#filter-price'));
});

$(document).on('click', '#price-filter-button', function () {
	closeFilterSelecter($('#filter-price'));
	setPriceAjax();
	$('.filter').css({ 'display': 'none' });
});

function setPriceAjax() {
	if ($('#from-filter').val() == $('#from-filter').attr('data-min') && $('#to-filter').val() == $('#to-filter').attr('data-max')) {
		setAjax(getUrlVars()["Colors"] || null, getUrlVars()["Sizes"] || null, null);
	}
	else {
		setAjax(getUrlVars()["Colors"] || null, getUrlVars()["Sizes"] || null, $('#from-filter').val() + '-' + $('#to-filter').val());
	}
}
/*price-filter*/
/*color-filter*/
$(document).on('click', '#filter-color > .filter__button',function () {
	if ($('#filter-color').children('.filter-selecter').css('display') == 'none')
		openFilterSelecter($('#filter-color'));
	else
		closeFilterSelecter($('#filter-color'));
});

$(document).on('click', '.selecter-choice__color-div > .mobile-selecter-choice__color',function () {
	if ($(this).hasClass('mobile-selecter-choice__color_active'))
		$(this).removeClass('mobile-selecter-choice__color_active');
	else
		$(this).addClass('mobile-selecter-choice__color_active');
});

$(document).on('click', '#color-filter-button',function () {
	closeFilterSelecter($('#filter-color'));
	setColorsAjax();
	$('.filter').css({ 'display': 'none' });
});

function setColorsAjax() {
	let colors = [];

	$('.mobile-selecter-choice__color').each(function () {
		if ($(this).hasClass('mobile-selecter-choice__color_active')) {
			colors.push($(this).attr('data-color'));
		}
	});
	if (colors != 0)
		setAjax(colors.join('_'), getUrlVars()["Sizes"] || null, getUrlVars()["Price"] || null);
	else
		setAjax(null, getUrlVars()["Sizes"] || null, getUrlVars()["Price"] || null);
}
/*color-filter*/
/*mobile-filter*/