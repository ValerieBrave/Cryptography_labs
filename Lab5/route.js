const Alphabet = ['а','б','в','г','д','е','ё','ж','з','і',
'й','к','л','м','н','о','п','р','с',
'т','у','ў','ф','х','ц','ч','ш','ы','ь','э','ю','я']
var message = "міхасьлынькоў"+
"міколкапаравозхатанакалёсахвынебачыліміколкавайхаты"+
"янавуньусамымтупікудзеканчаюццастанцыённыялініідзебезлічстрэлакдзестаяцьнедалёкапрыгожыясемафорыдзеўбязмежныяпрасторыпрацягнулісяпабеглібліскучыярэйкі"+
"парэйкахтыхбягуцьцягнікібягуцьіднёміноччуішэраюраніцайкаліяшчэсонцанеўзыходзіцькаліяшчэміколкаспіцькаліспяцьусезвычайныялюдзіякіяноччунеўмашыністахнеўкандуктарахнеўр"+
"бочыхдэпонеўабходчыкахпуцявыхацягнікібягуцьзімойілетамувосеньіўвеснуічымхаладнейтымгучнейгудуцьпаравозыуглядаючысясваіміпукатымібліскучымівачымаўдалёкіяагеньчыкісемафораўагеньчыкібелыязялёныячырвоныяікожныпарав"+
"озкрычыцьпасвоймуадзінтакгудзіцьштошыбытрасуццаўвокнахудругогахрыпатыгол"+
"аснібыпрастудзіўсяпаравозбегаючыўзольныхтуманахізавеяхатрэціякаянебудзькукушканегудзіцьапростапасвістваегаласкомтакімтонк"
var coded = ''
var decoded = ''


function RouteSH() {
    //console.log(message.length)
    let columns = Number.parseInt( document.getElementById('columns').value)
    let rows = Math.floor(message.length / columns)
    let table = new Array(rows)
    for(let i =0; i< rows; i++) {
        table[i] = new Array(columns)
    }
    
    for(let i =0; i< rows; i++) {
        for(let j=0; j< columns; j++) {
            table[i][j] = message.charAt(i*columns + j)
        }
    }
    console.log(table)
    //coding
    for(let i =0; i< columns; i++) {    // по колонкам
        for(let r =0; r< rows; r++) {
            coded += table[r][i]
        }
    }
    document.getElementById('message').innerHTML = message
    document.getElementById('coded').innerHTML=coded
}

function RouteDSH() {
    let columns = Number.parseInt( document.getElementById('columns').value)
    let rows = Math.floor(message.length / columns)
    let table = new Array(rows)
    for(let i =0; i< rows; i++) {
        table[i] = new Array(columns)
    }
    //восстанавливаем таблицу
    for(let i =0; i< columns; i++) {    
        for(let r =0; r< rows; r++) {   //строки
            table[r][i] = coded.charAt(i*rows + r)
        }
    }
    console.log(table)

    for(let i =0; i< rows; i++) {
        for(let j=0; j< columns; j++) {
            decoded += table[i][j]
        }
    }

    document.getElementById('decoded').innerHTML = decoded
}