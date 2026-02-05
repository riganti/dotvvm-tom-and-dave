(function(){
    // Ensure Knockout is available
    function ensureKo() {
        return typeof ko !== 'undefined' ? ko : null;
    }

    function escapeRegExp(string) {
        return string.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
    }

    function escapeHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }

    function initBinding(ko) {
        if (!ko || ko.bindingHandlers.highlight) return;

        ko.bindingHandlers.highlight = {
            init: function(element) {
                // allow the element to contain only our generated HTML
                element.style.whiteSpace = 'pre-wrap';
            },
            update: function(element, valueAccessor) {
                var params = ko.unwrap(valueAccessor()) || {};
                var text = ko.unwrap(params.text);
                var highlighted = ko.unwrap(params.highlightedText);

                if (text === null || text === undefined) text = '';
                if (!highlighted) {
                    // no highlight; just set escaped text
                    element.innerText = text;
                    return;
                }

                try {
                    var safeText = escapeHtml(text);
                    var pattern = escapeRegExp(String(highlighted));
                    var regex = new RegExp(pattern, 'gi');

                    var highlightedHtml = safeText.replace(regex, function(match){
                        return '<span class="bg-yellow-100 text-black rounded px-0.5">' + escapeHtml(match) + '</span>';
                    });

                    element.innerHTML = highlightedHtml;
                } catch (e) {
                    // fallback
                    element.innerText = text;
                }
            }
        };
    }

    // If ko is already loaded, initialize immediately; otherwise wait for DOMContentLoaded and try again
    var koRef = ensureKo();
    if (koRef) {
        initBinding(koRef);
    } else {
        document.addEventListener('DOMContentLoaded', function(){
            var k = ensureKo();
            initBinding(k);
        });
    }
})();
