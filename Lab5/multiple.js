var keyROW = 'смялова'
var keyCOLUMN = 'валерыя'
const Alphabet = ['а','б','в','г','д','е','ё','ж','з','і',
'й','к','л','м','н','о','п','р','с',
'т','у','ў','ф','х','ц','ч','ш','ы','ь','э','ю','я']
var message = "міхасьлынькоўміколкапаравозхатанакалёсахвынебачыл"   //49
var coded = ''
var decoded = ''


function MultipleSH() {
    console.log(message.length)
    //формируем ключи
    let keyROW_sorted = [], keyCOLUMN_sorted = []
    for(let i =0; i< keyROW.length; i++)    keyROW_sorted.push(keyROW.charAt(i))
    for(let i =0; i< keyCOLUMN.length; i++)  keyCOLUMN_sorted.push(keyCOLUMN.charAt(i))
    
    keyROW_sorted.sort()
    keyCOLUMN_sorted.sort()
    
    let numkeyROW = [], numkeyCOLUMN = []
    for(let i =0; i< keyROW.length; i++)    numkeyROW.push(keyROW_sorted.indexOf(keyROW.charAt(i)))
    for(let i =0; i< keyCOLUMN.length; i++) numkeyCOLUMN.push(keyCOLUMN_sorted.indexOf(keyCOLUMN.charAt(i)))
    
    console.log('ключ горизонтальный ',numkeyROW)
    console.log('ключ вертикальный ',numkeyCOLUMN)

    // исходная таблица - пока без перестановок
    let table = new Array(numkeyCOLUMN.length)
    //для перестановок по строкам
    let table1 = new Array(numkeyCOLUMN.length)
    // для перестановок по столбцам
    let table2 = new Array(numkeyCOLUMN.length)
    for(let i =0; i< numkeyCOLUMN.length; i++) {
        table[i] = new Array(numkeyROW.length)
        table1[i] = new Array(numkeyROW.length)
        table2[i] = new Array(numkeyROW.length)
    }
    
    console.log(table)
    for(let i =0; i< numkeyCOLUMN.length; i++) {
        for(let j =0; j< numkeyROW.length; j++) {
            table[i][j] = message.charAt(i*numkeyCOLUMN.length + j)
        }
    }
    console.log("исходная таблица ",table)
    
    //перестановка по строкам
    let row_num = 0
    numkeyCOLUMN.forEach(ind => {   // по вертикальному ключу
        for(let j=0; j< numkeyROW.length; j++) {
            table1[row_num][j] = table[ind][j]
        }
        row_num++
    })
    console.log("перестановка по строкам ",table1)

    //перестановка по столбцам
    let col_num = 0
    numkeyROW.forEach(ind => {
        for(let i=0; i< numkeyCOLUMN.length; i++) {
            table2[i][col_num] = table1[i][ind]
        }
        col_num++
    })
    console.log("перестановка по столбцам ",table2)

    //считываем шифр
    for(let i =0; i< numkeyCOLUMN.length; i++) {
        for(let j=0; j< numkeyROW.length; j++) {
            coded+=table2[i][j]
        }
    }

    document.getElementById('message').innerHTML = message
    document.getElementById('coded').innerHTML = coded
}

function MultipleDSH() {
    //формируем ключи
    let keyROW_sorted = [], keyCOLUMN_sorted = []
    for(let i =0; i< keyROW.length; i++)    keyROW_sorted.push(keyROW.charAt(i))
    for(let i =0; i< keyCOLUMN.length; i++)  keyCOLUMN_sorted.push(keyCOLUMN.charAt(i))

    keyROW_sorted.sort()
    keyCOLUMN_sorted.sort()

    let numkeyROW = [], numkeyCOLUMN = []
    for(let i =0; i< keyROW.length; i++)    numkeyROW.push(keyROW_sorted.indexOf(keyROW.charAt(i)))
    for(let i =0; i< keyCOLUMN.length; i++) numkeyCOLUMN.push(keyCOLUMN_sorted.indexOf(keyCOLUMN.charAt(i)))

    // восстанавливаем таблицу
    let table2 = new Array(numkeyCOLUMN.length)
    let table1 = new Array(numkeyCOLUMN.length)
    let table = new Array(numkeyCOLUMN.length)
    for(let i =0; i< numkeyCOLUMN.length; i++) {
        table2[i] = new Array(numkeyROW.length)
        table1[i] = new Array(numkeyROW.length)
        table[i] = new Array(numkeyROW.length)
    }
    for(let i=0; i< numkeyCOLUMN.length; i++) {
        for(let j=0; j<numkeyROW.length; j++) {
            table2[i][j] = coded.charAt(i* numkeyCOLUMN.length + j)
        }
    }
    console.log('восстановленная table2 ', table2)

    //переставляем обратно столбцы
    let col_num = 0
    numkeyROW.forEach(ind => {
        for(let i=0; i< numkeyCOLUMN.length; i++) {
            table1[i][ind] = table2[i][col_num]
        }
        col_num++
    })
    console.log('восстановленная table1 ', table1)

    //переставляем обратно строки - восстанавливаем исходную таблицу
    let row_num = 0
    numkeyCOLUMN.forEach(ind => {
        for(let j=0; j<numkeyROW.length; j++) {
            table[row_num][j] = table1[ind][j]
        }
        row_num++
    })
    console.log('восстановленная table ', table)

    //восстанавливаем сообщение
    for(let i=0; i< numkeyCOLUMN.length; i++) {
        for(let j=0; j<numkeyROW.length; j++) {
            decoded += table[i][j]
        }
    }
    document.getElementById('decoded').innerHTML = decoded
}
