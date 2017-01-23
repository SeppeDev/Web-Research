********************************
**********Web Research**********
********************************


New Technology
{
	19/09/2016
	{
		Ideeën:
			Xamarin
			AngularJS2
			Django
			Vue
	}

	29/09/2016
	{
		Visual Studio opnieuw geïnstalleerd met Xamarin erin, en vervolgens gechecked of het werkte door een kleine tutorial te maken van Xamarin zelf, waarin je een kleine app maakt die letters vertaalt naar cijfers, waarna je kan bellen naar het bekomen nummer.

		https://developer.xamarin.com/guides/android/getting_started/hello,android/hello,android_quickstart/
	}

	01/10/2016
	{
		Probleem oplossen met Hyper-V (moet afstaan om VirtualBox te kunnen draaien, anders krijg ik BSOD, maar moet aanstaan voor de VS Emulator), door mijn smartphone aan mijn pc te hangen en te zorgen dan ik daarop kan debuggen.
		Daarna de "Deep Dive" tutorial gedaan, die eigelijk uitlegt wat er nu net allemaal gebeurt in de vorige tutorial (die eigelijk alleen maar dient om te kijken of alles wel deftig werkt, achteraf gezien).

		https://developer.xamarin.com/guides/android/getting_started/hello,android/hello,android_deepdive/
	}

	03/10/2016
	{
		De app verder uitbouwen tot een multiscreen app.

		https://developer.xamarin.com/guides/android/getting_started/hello,android_multiscreen/hello,android_multiscreen_quickstart/


		Deep Dive bekijken van de multiscreen app.

		https://developer.xamarin.com/guides/android/getting_started/hello,android_multiscreen/hello,android_multiscreen_deepdive/
	}

	08/10/2016
	{
		Zelf wat zitten uittesten en uiteindelijk een kleine app gemaakt die je toestaat je Wifi aan en af te zetten. Vrij nutteloos, maar het werkt wel (juiste permissions etc.)


		Gezocht naar verschillende tutorials of informatie, maar ofwel zeer basic dingen gevonden, ofwel zeer geavanceerd. Een todo-tutorial is niet te vinden, maar wel een premade example van een todo app, dat Xplatform is. Dit bekijk ik grondig met de uitleg van Xplatform ernaast, om waarschijnlijk daarna zelf een Xplatform todo te maken.

		https://developer.xamarin.com/guides/cross-platform/application_fundamentals/building_cross_platform_applications/
	}

	10/10/2016
	{
		Meer Xplatform Todo lezen en snappen.

		Ik besef dat de beste manier om er gewoon aante beginnen, en dan te zien hoe haalbaar het is, want de documentatie voor ebginners is zeer beperkt. Eens begonnen zal ik wel zien hoe het loopt en waar ik vast mee kom te zitten.
	}

	12/10/2016
	{
		Gestart aan mijn eigen Research Xplatform todo app --(Native Portable)--

		Main.axml opmaken en daarna Busines Layer, DataLayer en DataAccessLayer maken.
		MainActivity.cs van Android schrijven, waarin de DB gemaakt wordt en de interface met de BL verbonden wordt.
		SQLIte toevoegen.
	}

	16/10/2016
	{
		BL en DAL schrijven.

		Blijkt nu dat ik de "foute" BlankApp gebruikt heb bij het maken van een nieuw project. Blank App (Native Portable) zorgt voor veel miserie met SQLite (meer info komt later nog wel), dus ik kan beter Blank App (Native Shared) gebruiken. Opnieuw!
	}

	17/10/2016
	{
		App hermaakt/copy-paste met Native Shared. Alles werkt hierin, maar de app is zeer ruw. Later komt er misschien nog wat verfijnend werk, maar voorlopig blijft het as is.
	}

	19/10/2016
	{
		Native Portable kan wel gebruikt worden, ik vond gewoon niet hoe, maar dit kan dus wel.
	}

	11/11/2016
	{
		Powerpoint beginnen maken en ook hiervoor codesnippers maken. Ook wat algemene info over Xamarin lezen, had ik misschien beter in het begin gedaan.
	}
}


Vergelijkende Studie
{
	19/09/2016
	{
		Ideeën:
			Phinegap - Xamarin
	}

	19/10/2016
	{
		Vergelijkende artikels lezen over Xamarin en Phonegap, meningen van experten verzamelen. Wat me overal opvalt is dat de moeilijkheidsgraad van beiden overal als grootste verschil wordt aangegeven, daarna pas dat Xamarin veel dichter staat bij Native (want het is geen native, daarmee zou ik tegen veel mensen hun schenen schoppen). Ook de herbruikbaarheid van code over verschillende platformen is groot, maar dit wordt in recentere artikels hard gecounterd door Xamarin Forms, wat voor +95% shared code kan leiden, naar gelang hoeveel native functionaliteit van elk platform gebruikt wordt, wat in de meeste gevallen vrij beperkt zou zijn.
	}

	25/10/2016
	{
		Enkele Phonegap projecten van voorbije jaren bekijken.

		Zoeken naar een Phonegap todo app om deze te vergelijken met de Xamarin versie.

		Wat verdiepen in Phonegap en de werking met plugins.
	}

	26/10/2016
	{
		Artikels zoeken over Phonegap en Xamarin, los van elkaar, om objectieve data over beide te verkrijgen, en om meningen, frustraties en dergelijke te kunnen vergelijken met elkaar, om komende week te kunnen lezen en verwerken, want ik heb geen internet.
	}

	31/10/2016
	{
		Artikels lezen en "samenvatten".
	}

	02/11/2016
	{
		Meer artikels lezen en samenvatten en beginnen schrijven aan een degelijke paper.
	}

	10/11/2016
	{
		Meer leeswerk en paperschrijfwerk.
	}

	11/11/2016
	{
		Conclusie schrijven en beginnen aan een powerpoint. Hiervoor codesnippets maken.
	}
}


Proof Of Concept
{
	19/09/2016
	{
		Ideeën:
			App in Xamarin -> heuuuuuh, ni zo simpel, dus scratch this.
	}

	30/11/2016
	{
		Xamarin app die via QR code android settings kan aanpassen.
			- QR code die toegang geeft tot wifi netwerk

		Daarna eventueel
			- cross platform
			- QR code die naar spotofylijst linkt
	}

	17/12/2016
	{
		Wat zoeken over QR-codes en hoe die te lezen vallen met Xamarin. Een makkelijke plugin gevonden die dit voor me kan doen.

		Gezocht met het toevoegen van een nieuw netwerk in de settings. Wat liggen prutsen, maar uiteindelijk lukt dit ook. Vrij gelijkaardig met hoe ik in de eerste periode mijn Wifi app gemaakt had.

		Probleem ontdekt, waarbij het netwerk niet altijd toegevoegd wordt. Wat tests doen om te zien hoe dit komt.
	}

	18/12/2016
	{
		Probleem waarschijnlijk gevonden. De wifi van het apparaat moet eerst opstaan voordat er een netwerk aan toe kan worden gevoegd. Volgorde verandert in code, zodat eerst de wifi aangezet wordt, en vervolgens pas een netwerk toegevoegd wordt, en dat lijkt te werken.
	}

	21/01/2017
	{
		Zoeken naar hoe ik QR-codes kan genereren zelf. Niet zoveel over te vinden als over het lezen. Enkele opties gevonden en voorbeelden, maar tot nu toe werkt er nog geen enkele.
	}

	22/01/2017
	{
		Een van de voorbeelden aan de praat gekregen. Nu is het plan te proberen de code af te printen (opslaan als PDF/doorsturen naar een netwerk printer/...)

		Ik kan alleen een WebView printen, geen imageview. Zien of ik de QRCode ook in een webview kan steken.

		ImageView in WebView steken is niet gelukt, dus printen zit er ook niet in
	}

	23/01/2017
	{
		Had het idee omde optie te geven de QRcode in te stellen als achtergrond van je lockscreen, zodat je makkelijk de code aan mensen kan laten scannen. (meer native functionaliteit accessen)

		https://forums.xamarin.com/discussion/52230/set-image-as-backgroundto-lock-screen-and-regular-screen
		https://components.xamarin.com/view/lock-screen
		https://developer.android.com/reference/android/app/WallpaperManager.html
		http://android-er.blogspot.be/2011/03/set-wallpaper-using-wallpapermanager.html

		Wallpaper er van maken is gelukt. Nu nog zien of ik enkel de lockscreen an veranderen.
	}
}