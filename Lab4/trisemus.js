const Alphabet = ['а','б','в','г','д','е','ё','ж','з','і',
'й','к','л','м','н','о','п','р','с',
'т','у','ў','ф','х','ц','ч','ш','ы','ь','э','ю','я']

function TrisemysSH(key) {
    let table = new Array(Math.ceil(Alphabet.length / key.length))//.fill(new Array(key.length).fill(0))
    for(let i = 0; i < Math.ceil(Alphabet.length / key.length); i++) {
        table[i] = new Array(key.length)
    }

    let tab = []    // таблица одномерная
    for(let i =0; i< key.length; i++) tab.push(key[i])
    Alphabet.forEach(element => {
        if(!tab.includes(element)) tab.push(element)
    })
    //формируем двумерную
    for(let i =0; i< Math.ceil(Alphabet.length / key.length); i++) {    // по строкам
        for(let j=0; j< key.length; j++) {  // по столбцам
            table[i][j] = tab[i*key.length+j]
            let k =0
        }
    }
    console.log(tab)
    console.log(table)
    //coding
    for(let i =0; i< message.length; i++) { // по всем буквам сообщения
        let letter = message.charAt(i)
        let last_index = Math.ceil(Alphabet.length / key.length) * 7
        let tab_index = tab.indexOf(letter)
        if(tab_index + key.length <= last_index) {// можем на строчку ниже прыгать, но нужна проверка 
            if(tab[tab_index+key.length] != undefined) {
                coded+=tab[tab_index+key.length]
            } else {
                coded +=tab[key.length - ((last_index-key.length) - tab_index)]
            }
        } else {    // переход на первую
            coded += tab[key.length - (last_index-tab_index)]
        }
    }
    console.log(getFrequency(message))
    document.getElementById('message').innerHTML = message
    document.getElementById('coded').innerHTML = coded
    let ghystogram1 = getFrequency(message)
    let ghystogram2 = getFrequency(coded)
    let ghysto1 = document.getElementById('ghysto1')
    let ghysto2 = document.getElementById('ghysto2')
    ghysto1.innerHTML = '';
    ghysto2.innerHTML = '';
    
    Alphabet.forEach(element => {
        let percent = (ghystogram1[element]/message.length);
        DrowGhysto(ghysto1, percent, element)
        percent = (ghystogram2[element]/coded.length);
        DrowGhysto(ghysto2, percent, element)
    });
}

function TrisemysDSH(key) {
    let tab = []    // таблица одномерная
    for(let i =0; i< key.length; i++) tab.push(key[i])
    Alphabet.forEach(element => {
        if(!tab.includes(element)) tab.push(element)
    })
    for(let i =0; i< coded.length; i++) {   // по всем буквам шифра
        let letter = coded.charAt(i)
        let last_index = Math.ceil(Alphabet.length / key.length) * 7
        let coded_index = tab.indexOf(letter)
        if(coded_index >= key.length) { // не первая строка все ок
            decoded += tab[coded_index-key.length]
        } else {
            if(tab[last_index-(key.length-coded_index)] != undefined) decoded += tab[last_index-(key.length-coded_index)]
            else decoded += tab[last_index-(key.length-coded_index)-key.length]
        }
    }
    document.getElementById('decoded').innerHTML = decoded
}

function DrowGhysto(ghysto, percent, letter){
    let h = 400 * percent;
    let line = document.createElement('div');
    line.innerHTML = `
    <div style="width: 50px; height: ${h}px; background-color: coral;">
        ${Math.floor(percent*100)}%
    </div>
    <p>${letter}</p>`
    ghysto.append(line);
}
function getFrequency(string) {
    let freq = {};
    for (let i=0; i<string.length;i++) {
        let character = string.charAt(i);
        if (freq[character]) {
           freq[character]++;
        } else {
           freq[character] = 1;
        }
    }
    
    return freq;
};

var coded = ''
var decoded = ''
//var message = 'дрюц'
var message = "міхасьлынькоў"+
"міколкапаравозхатанакалёсахвынебачыліміколкавайхаты"+
"янавуньусамымтупікудзеканчаюццастанцыённыялініідзебезлічстрэлакдзестаяцьнедалёкапрыгожыясемафорыдзеўбязмежныяпрасторыпрацягнулісяпабеглібліскучыярэйкі"+
"парэйкахтыхбягуцьцягнікібягуцьіднёміноччуішэраюраніцайкаліяшчэсонцанеўзыходзіцькаліяшчэміколкаспіцькаліспяцьусезвычайныялюдзіякіяноччунеўмашыністахнеўкандуктарахнеўр"+
"бочыхдэпонеўабходчыкахпуцявыхацягнікібягуцьзімойілетамувосеньіўвеснуічымхаладнейтымгучнейгудуцьпаравозыуглядаючысясваіміпукатымібліскучымівачымаўдалёкіяагеньчыкісемафораўагеньчыкібелыязялёныячырвоныяікожныпарав"+
"озкрычыцьпасвоймуадзінтакгудзіцьштошыбытрасуццаўвокнахудругогахрыпатыгол"+
"аснібыпрастудзіўсяпаравозбегаючыўзольныхтуманахізавеяхатрэціякаянебудзькукушканегудзіцьапростапасвістваегаласкомтакімтонк"+
"імпранізлівыміпаголасупазнаеміколкакожныпаравозцітотаварныцітопасажырскіічасамноччупачуўшыголасдалёкагапаравозаміколкабудзіцьматку"+
"уставаймамасамаварстаўбацькаедзезпасажырскімягопаравозгудзіць"
"самтыпаравоздражніцьматкаміколкувосьспацьнедаештолькіпасажырскіяшчэдалёка"
"алематкаўставаластавіласамаварраздзьмухваючыягостаройхаляўкайадботаўміколкапрыслухоўваўсяякпрабягаўзшумамігрукатампастукваючынастрэлкахцягнікякзацішаўёнхадуапотымізусімстанавіўсянастанцыітутзменьвалісяпараво"
"зызменьвалісяімашыністыізаўсёдыакуратнапразякіянебудзьхвіліндзесяцьдахатызяўляеццаміколкаўбацька"+
"атыпрачнуўсяўжокурерскігаварыўёндаміколкіізаўсёдынамерваўсяўхапіцьягозаноссваёйчорнайпрамазучанайрукойміколкахаваўсяпадкоўдруіпаказваючыадтультолькікончыкносапачынаўчохкацьяксапраўдныпаравоз"+
"чшычшычшычшычшычшы"