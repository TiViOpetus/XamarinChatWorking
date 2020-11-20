# XamarinChatClient

Tässä tehtävässä toteutat yksinkertaisen Chat-sovelluksen käyttöliittymän. Tässä kohtaa ei tarvitse miettiä vielä miten lopullinen sovellus toimii, vaan voit toteuttaa vain alta löytyvien kuvankaappausten mukaiset näkymät.

Voit käyttää tässä pohjana jo aiemmin tekemääsi **Xamarin HelloWorld**-sovellusta.

Näkymiä on 2. Ensimmäinen näistä tulee esiin heti kun sovellus käynnistyy. Ensimmäisessä näkymässä nappia **Login** painamalla käyttäjä kirjautuu sisään olemassa olevilla tunnuksilla. Nappia **Register** käyttäjä voi rekisteröidä uuden tunnuksen ja salasanan.

![Login](/Images/1.PNG?raw=true)

Kun käyttäjä rekisteröi uuden tunnuksen ja salasanan, tulee nappien alle teksti jossa kerrotaan että käyttäjä on nyt lisätty.

![Register](/Images/2.PNG?raw=true)

Jos käyttäjä yrittää kirjautua tunnuksilla joita ei vielä ole, tulee ensimmäisessä näkymässä ao. mukainen herja nappien alapuolelle.

![LoginFail](/Images/3.PNG?raw=true)

Kun olemassa olevilla tunnuksilla kirjaudutaan sisään, siirtyy sovellus suoraan chat-näkymään, missä käyttäjä vastaanottaa kaikkien muiden käyttäjien viestit ja voi myös itse lähettää viestit palvelimelle.

![Login](/Images/4.PNG?raw=true)

Voit sovelluksen tässä vaiheessa hyväksyä **Login**-napin painalluksessa mitkä tahansa tunnukset ja siirtyä suoraan seuraavaan näkymään.

Ensimmäisessä näkymässä tekstikentät ovat **Entry**-tyyppisiä ja infotekstit taas **Label**-tyyppejä. Chat-ikkunassa on **ListView**.

Kun olet saanut näkymäsi valmiiksi, käytä jälleen Git commit & push -komentoja ja päivitä omat koodisi repoon.
