# I Dictionary

I dictionary sono una classe C# del namespace System.Collections.Generic e quindi sarà necessaria la relativa using per usarli

    using System.Collections.Generic;

Questo tipo di dati rappresenta una coppia chiave valore, i tipi della chiave e del valore sono definiti nella instanziazione dell'oggetto

    var dictionary = new Dictionary<string, int>();

Come si vede dal codice sopra inserito, durante la creazione gli passiamo due tipi, nel nostro caso string e int, il primo tipo rappresenta il tipo della chiave del dictionary, mentre il secondo rappresenta il valore correlato alla chiave

# Questi sono i principali metodi dei Dictionary

-   ### Add

-   ### Clear

-   ### Remove

-   ### ContainsKey

-   ### ContainsValue

-   ### TryGetValue

## Add

Add come suggerisce il nome ci permette di inserire un elemento nel nostro dictionary, la sua firma è la seguente

    public void Add(TKey key, TValue value)

Dove key, rappresenta la nostra chiave e value il nostro valore, il metodo Add nel momento in cui proviamo ad aggiungere una coppia chiave-valore già presente va in Eccezzione, quindi è importante effettuare i rispettivi controlli, ad esempio utilizzando il metodo ContainsKey prima di inserire una coppia chiave-valore

## Remove

Remove ci permette di rimuovere una chiave e il rispettivo valore dal nostro dictionary, riporto anche in questo caso la sua firma

    public bool Remove(TKey key)

A diffferenza di prima questa funzione ritorna un booleano rappresentante la corretta rimozione della chiave, key ovviamente è la chiave da rimouovere dal dictionary

## Clear

Clear ci permette di rimuovere tutte le coppie chiave-valore e "azzerare" il nostro dictionary, la sua firma è

    public void Clear()

## ContainsKey e ContainsValue

Come ci suggerisce il nome questi due metodi ci fanno sapere se il nostro dictonary contiene o una chiave o un valore al suo interno, le rispettive firme sono le seguenti

    public bool ContainsKey(TKey key)

    public bool ContainsValue(TValue value)

## TryGetValue

Questo metodo ci permette di sapere se una chiave e presente e di prendere il rispettivo valore, la sua firma è la seguente

    public bool TryGetValue(TKey key, out TValue value)

come si nota ritorna un booleano True nel caso in cui la chiave sia presente e in quel caso assegna tramite la keyword out il valore rispettivo alla variabile passata alla funzione

L'utilizzo di questa funzione è sicuramente il modo più sicuro per accedere ai valori del dictionary ma esiste anche una notazione con l'uso della parentesi quadre come nei vettori, ci bastera scrivere

    dictionary[key]

in questo modo possiamo ottenere il valore però perdiamo il controllo fornito dal TryGetValue
