const { parseJSON } = require("jquery");

var $p = (function () {
     
    function get(url, method, data, success, error) {
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState != XMLHttpRequest.DONE) return;    // XMLHttpRequest.DONE == 4

            if (xmlhttp.status == 200) {
                success(xmlhttp.responseText);
                return;
            }

            alert('Yolunda olmayan bişey var!');
            error(xmlhttp.responseText);

        };

        xmlhttp.open(method, url, true);
        xmlhttp.send(JSON.stringify(data));
    } 

    return {
        init = function () {
            document.querySelectorAll("select[data-load-from-url]").forEach(function (el, key, parent) {
                el.innerHTML = "";

                var url = el.getAttribute("data-load-from-url").value;
                $p.getData(url, function (d) {
                    var data = parseJSON(d);

                    for (var i = 0; i < data.length; i++) {
                        var elOption = document.createElement("option");
                        elOption.setAttribute("value", data[i].value);
                        elOption.textContent = data[i].text; 
                        el.appendChild(elOption);
                    }

                    el.value = el.value;
                })

                el.removeAttribute("data-load-from-url"); 
            });
        },
        get = get,
        getData = function (url, success) {
            get(url, "GET", {}, success, function () { })
        }
    }
})();

$p.init();