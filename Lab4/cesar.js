const Alphabet = ['а','б','в','г','д','е','ё','ж','з','і',
'й','к','л','м','н','о','п','р','с',
'т','у','ў','ф','х','ц','ч','ш','ы','ь','э','ю','я']

function CesarSH(key, offset) {
    let tab = new Array(Alphabet.length)
    offset -=1
    let insert_start = offset
    for(let i=0; i< key.length; i++) {  // записали лозунг со смещением
        if(!tab.includes(key.charAt(i))) {
            tab[insert_start] = key.charAt(i)
            insert_start++
        }
    }
    Alphabet.forEach(element => {
        if(insert_start < Alphabet.length) {    // заполняем до конца
            if(!tab.includes(element)) {
                tab[insert_start] = element
                insert_start++
            }
        } else {    // переход на начало
            insert_start = 0
            tab[insert_start] = element
            insert_start++
        }
    })

    for(let i =0; i< message.length; i++) { // по всем буквам сообщения
        coded += tab[Alphabet.indexOf(message[i])]
    }
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
    })
    console.log(insert_start)
    console.log(tab)
}

function CesarDSH(key, offset) {
    let tab = new Array(Alphabet.length)
    offset -=1
    let insert_start = offset
    for(let i=0; i< key.length; i++) {  // записали лозунг со смещением
        if(!tab.includes(key.charAt(i))) {
            tab[insert_start] = key.charAt(i)
            insert_start++
        }
    }
    Alphabet.forEach(element => {
        if(insert_start < Alphabet.length) {    // заполняем до конца
            if(!tab.includes(element)) {
                tab[insert_start] = element
                insert_start++
            }
        } else {    // переход на начало
            insert_start = 0
            tab[insert_start] = element
            insert_start++
        }
    })
    for(let i =0; i< coded.length; i++) { // по всем буквам сообщения
        decoded += Alphabet[tab.indexOf(coded[i])]
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
}

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