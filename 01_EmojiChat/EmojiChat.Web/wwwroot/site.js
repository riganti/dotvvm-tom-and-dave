showdown.extension('codehighlight', function () {
    function htmlunencode(text) {
        return (
            text
                .replace(/&amp;/g, '&')
                .replace(/&lt;/g, '<')
                .replace(/&gt;/g, '>')
        );
    }
    return [
        {
            type: 'output',
            filter: function (text, converter, options) {
                // use new shodown's regexp engine to conditionally parse codeblocks
                var left = '<pre><code\\b[^>]*>',
                    right = '</code></pre>',
                    flags = 'g',
                    replacement = function (wholeMatch, match, left, right) {
                        // unescape match to prevent double escaping
                        match = htmlunencode(match);
                        return left + hljs.highlightAuto(match).value + right;
                    };
                return showdown.helper.replaceRecursiveRegExp(text, replacement, left, right, flags);
            }
        }
    ];
});

const converter = new showdown.Converter({
    smoothLivePreview: true,
    tables: true,
    ghCodeBlocks: true,
    extensions: ['codehighlight']
});

ko.bindingHandlers["markdown"] = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        let text = ko.unwrap(valueAccessor());
        if (ko.unwrap(allBindingsAccessor.get("markdown-enabled"))) {
            text = converter.makeHtml(text);
        }
        element.innerHTML = text;
    }
}
