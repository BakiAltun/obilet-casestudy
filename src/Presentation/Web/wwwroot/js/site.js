
var $p = (function () {
    var options = $.extend(true, $.datepicker.regional["tr"], {
        dateFormat: "dd MM yy DD",
        minDate: new Date()
    });

    searchDatePicker = function () {
        $("[data-search-datepicker]").each(function (i, el) {
            var $btnToday = $(el).find("[data-today]");
            var $btnTomorrow = $(el).find("[data-tomorrow]");
            var $btnPicker = $(el).find("[data-picker]");
            var $btnInput = $(el).find("[data-input]");

            // bugun butonu tıklanması
            $btnToday.click(function () {
                var today = new Date();
                $btnPicker.datepicker("setDate", today);

                $btnToday.addClass("active");
                $btnTomorrow.removeClass("active");
                $btnPicker.trigger("change");
            });

            // yarın butonu tıklanması
            $btnTomorrow.click(function () {
                var tomorrow = new Date();
                tomorrow.setDate(tomorrow.getDate() + 1);
                $btnPicker.datepicker("setDate", tomorrow);

                $btnTomorrow.addClass("active");
                $btnToday.removeClass("active");
                $btnPicker.trigger("change");
            });

            // tarih seçim yapılması
            $btnPicker.change(function () {
                var date = $btnPicker.datepicker("getDate");
                date.setDate(date.getDate() + 1);
                $btnInput.val(date.toISOString().split('T')[0])
            });
            $btnPicker.datepicker(options);
        });
    }

    function switchSelects() {
        $("[data-search-location]").each(function (i, el) {
            var $inpToValue = $(el).find("[data-to] [data-select-value]");
            var $inpToText = $(el).find("[data-to] [data-select-text]");

            var $inpFromValue = $(el).find("[data-from] [data-select-value]");
            var $inpFromText = $(el).find("[data-from] [data-select-text]");

            var prevToValue = "";
            var prevToText = "";
            var prevFromText = "";
            var prevFromValue = "";

            $(el).find("[data-from] [data-select-text],[data-to] [data-select-text]")
                .focus(function () { // önceki değerleri almak için

                    prevToValue = $inpToValue.val();
                    prevToText = $inpToText.val();

                    prevFromValue = $inpFromValue.val();
                    prevFromText = $inpFromText.val();
                    console.log("fov");
                })
                .change(function (el) {
                    var toText = $inpToText.val();
                    var fromText = $inpFromText.val();

                    console.log(toText + " ---- " + fromText);

                    if (toText != fromText) {
                        console.log("asdf");
                        return;
                    }

                    // aynı lokasyon seçiliyorsa yer değiştirme
                    if ($inpToText[0].name == el.currentTarget.name) { 
                        $inpFromValue.val(prevToValue);
                        $inpFromText.val(prevToText);
                    }
                    else { 
                        $inpToValue.val(prevFromValue);
                        $inpToText.val(prevFromText);
                    }
                })

            // lokasyon switch etme
            $(el).find("[data-switch]").click(function () {
                var toValue = $inpToValue.val();
                var toText = $inpToText.val();

                var fromValue = $inpFromValue.val();
                var fromText = $inpFromText.val();

                $inpFromValue.val(toValue);
                $inpFromText.val(toText);

                $inpToValue.val(fromValue);
                $inpToText.val(fromText);
            });

        })
    }
    return {
        init: function () {
            searchDatePicker();
            switchSelects();
        }
    }
})();

$p.init();