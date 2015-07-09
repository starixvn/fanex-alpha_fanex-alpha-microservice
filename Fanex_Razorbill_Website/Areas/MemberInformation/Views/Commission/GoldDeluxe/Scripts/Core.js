// Detect browser
function isIE() {
	return /msie/i.test(navigator.userAgent) && !/opera/i.test(navigator.userAgent);
}

IE = isIE();

// Prototype of AGE
function AGE()
{ };
AGE.prototype.RemoveBookmarksInUrl = function (url) {
    if (typeof url != 'string') return null;
    var i = url.indexOf('#');
    if (i == -1) return url;
    return url.substr(0, i);
}
// Calculate view area
AGE.prototype.CalculateViewport = function () {
	this.viewport = { width: 0, height: 0 };
	if (!IE) {
		// in standards compliant mode (i.e. with a valid doctype as the first line in the document)
		if (typeof document.documentElement !== 'undefined' && typeof document.documentElement.scrollWidth !== 'undefined' && document.documentElement.scrollWidth !== 0) {
			this.viewport.width = document.documentElement.scrollWidth;
			this.viewport.height = document.documentElement.scrollHeight;
		}
		this.viewport.width = Math.max(this.viewport.width, (Math.max(document.body.scrollWidth, document.body.clientWidth)));
		this.viewport.height = Math.max(this.viewport.height, (Math.max(document.body.scrollHeight, document.body.clientHeight)));
	}
	else {
		// in standards compliant mode (i.e. with a valid doctype as the first line in the document)
		if (typeof document.documentElement !== 'undefined' && typeof document.documentElement.clientWidth !== 'undefined' && document.documentElement.clientWidth !== 0) {
			this.viewport.width = document.documentElement.clientWidth;
			this.viewport.height = document.documentElement.clientHeight;
		}
		this.viewport.width = Math.max(document.body.scrollWidth, this.viewport.width);
		this.viewport.height = Math.max(document.body.scrollHeight, this.viewport.height);
	}
}
// Create a mask div will cover whole page
AGE.prototype.CreateMaskDiv = function () {
    this.divMaskLoading = $('<div style="background-color:#fff;position:absolute;top:0;left:0;filter:alpha(opacity=50);opacity:0.5;display:none;">\
            <div style="position:relative;width:100px;height:100px;"></div>\
        </div>').appendTo('body');
    return this.divMaskLoading;
}
// Show a mask div cover whole page
AGE.prototype.ShowMaskDiv = function (withIcon) {
    if (!this.divMaskLoading) return;

    this.CalculateViewport();

    var divIcon = this.divMaskLoading.children().first();
    divIcon.css({
        left: Math.floor(this.viewport.width / 2) + 'px',
        top: document.documentElement.scrollTop + 'px'
    });

    if (withIcon) {
        divIcon.addClass('MaskLoadingDiv');
    }
    else {
        divIcon.removeClass('MaskLoadingDiv');
    }

    this.divMaskLoading.css({
        width: (this.viewport.width - 2) + 'px',
        height: (this.viewport.height - 2) + 'px',
        display: 'block'
    });
}
// Hide showed mask div
AGE.prototype.HideMaskDiv = function () {
	if (!this.divMaskLoading) return;
	this.divMaskLoading.css({ display: 'none' });
}
// Reload page with provided url and delay time
AGE.prototype.DelayReloadPage = function (url, time) {
	this.ShowMaskDiv(true);
	var delay = time ? time : 2000;
	if (!url) {
		location.nextUrl = this.RemoveBookmarksInUrl(location.href);
		this.delayTimer = setTimeout("location = location.nextUrl", delay);
	}
	else {
		this.delayTimer = setTimeout("location = '" + url + "'", delay);
	}
}
AGE.prototype.Lock = function (withIcon) {
	this.ShowMaskDiv(withIcon);
	this.locked = true;
}
AGE.prototype.UnLock = function () {
	this.HideMaskDiv();
	this.locked = false;
}

// Delay init object to window.onload event to boots up performance
age = null;
function initialize() {
	age = new AGE();
	age.CreateMaskDiv();
	age.CalculateViewport();
	window.loaded = true;
}

initialize();
