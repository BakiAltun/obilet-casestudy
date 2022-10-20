
var $select = (function () {

    searchSelect = function (el) {

        var elValue = el.querySelector("[data-select-value]");
        var elText = el.querySelector("[data-select-text]");
        var elResults = el.querySelector("[data-results]");

        var prevValue = "";
        var prevText = "";

        //select açıldıında 
        elText.addEventListener("click", function () {
            if (el.classList.contains("visible")) return;

            prevValue = elValue.value
            prevText = elText.value;
            elText.setAttribute("placeholder", prevText);
            elText.value = "";

            el.classList.add("visible");
            elText.removeAttribute("readonly");
        })

        var timer; // arama yapılmak istendiğinde
        elText.addEventListener("keyup", function () {
            clearTimeout(timer);
            var ms = 500; // milliseconds
            timer = setTimeout(function () {
                get("/location/GetSelectList?search=" + elText.value, "get", {}, function (responseText) {
                    elResults.innerHTML = "";
                    var items = JSON.parse(responseText);

                    for (var i = 0; i < items.length; i++) {
                        var e = document.createElement('div');
                        e.setAttribute("data-id", items[i].value);
                        e.innerHTML = items[i].text;
                        e.addEventListener("click", function () {
                            setSelected(this, elValue, elText, el);
                        })
                        elResults.appendChild(e);
                    }
                });
            }, ms);
        })

        // select kapatılmak istendiğinde
        window.addEventListener('click', function (e) {
            if (el.classList.contains("visible") === false) return;

            if (el.contains(e.target)) {
                // Clicked in box
            } else {
                // Clicked outside the box
                closeSelect(el, elValue, elText);
                //el.classList.remove("visible");
                //elText.setAttribute("readonly", "readonly");
                elText.value = prevText;
                elValue.value = prevValue;
                ////prevValue = "";
                ////prevText = "";
            }
        });
    }

    function closeSelect(el, elValue, elText) {
        el.classList.remove("visible");
        elText.setAttribute("readonly", "readonly");
    }

    function setSelected(el, elValue, elText, elSelect) {
        var id = el.dataset.id;
        var text = el.innerText;

        elValue.value = id;
        elText.value = text;
        elValue.dispatchEvent(new Event("change"));
        elText.dispatchEvent(new Event("change"));
        closeSelect(elSelect, elValue, elText)
    }

    function get(url, method, data, success, error) {
        var xmlhttp = new XMLHttpRequest();
        //xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState != XMLHttpRequest.DONE) return;    // XMLHttpRequest.DONE == 4

            if (xmlhttp.status == 200) {
                success(xmlhttp.responseText);
                return;
            }

            alert('Yolunda olmayan bişey var!');

            if (error)
                error(xmlhttp.responseText);

        };

        xmlhttp.open(method, url, true);
        xmlhttp.send(JSON.stringify(data));
    }
     
    return {
        init: function () {
            var selects = document.querySelectorAll("[data-select]");
            for (var i = 0; i < selects.length; i++) {
                var el = selects[i];
                searchSelect(el);

                // default seçilene göre listeyi doldurma
                var elText = el.querySelector("[data-select-text]");
                elText.dispatchEvent(new Event("keyup")); 
            }
        }
    }
})();

$select.init();