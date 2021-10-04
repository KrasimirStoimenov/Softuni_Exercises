function encodeAndDecodeMessages() {
    const [encodeArea, decodeArea] = document.getElementsByTagName('textarea');
    document.getElementsByTagName('button')[0].addEventListener('click', encode);
    document.getElementsByTagName('button')[1].addEventListener('click', decode);

    function encode(ev) {
        const text = encodeArea.value;
        let encodedText = '';
        for (let i = 0; i < text.length; i++) {
            let charAscii = text.charCodeAt(i);
            charAscii++;
            let charAsString = String.fromCharCode(charAscii);
            encodedText += charAsString;
        }

        encodeArea.value = '';
        decodeArea.value = encodedText;
    }

    function decode(ev) {
        const text = decodeArea.value;
        let decodedText = '';
        for (let i = 0; i < text.length; i++) {
            let charAscii = text.charCodeAt(i);
            charAscii--;
            let charAsString = String.fromCharCode(charAscii);
            decodedText += charAsString;
        }

        decodeArea.value = decodedText;
    }

}