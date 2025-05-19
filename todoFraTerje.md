
1. Når man signer up, så er det tre mulige statuser man kan ha fra før: SignedUp, Verified og Unsubscribed. Sørg først
   for at dere har unit tester som sjekker om dette oppfører seg som det skal. Om det finnes en Subscription fra før, 
   og at status endres, så test at det ikke lages ny Subscription, men at den som returneres er den gamle - og at status
   er endret, om det er det riktige. 

1. Skriv koden i SubscriptionService.SignUp med så lite gjentakelse av kode som mulig. Og gjør den så lesbar som mulig. 
   Målet er at det er lett å lese hva som skjer ved hvert av de fire forskjellige utgangspunktene (ingen Subscription
   fra før - eller SignedUp, Verified eller Unsubscribed).

1. Oppsummere i tekst hva dere har lært så langt 
+ skrive det som en tekst til en tenkt ny utvikler som skal inn på prosjektet. 
M�let med dette er at den nye utvikleren før en enklere onboarding enn dere har føtt, 
og at den nye utvikleren får med seg alle de viktige poengene. Det betyr at dere må 
oppsummere hva de viktigste poengene er i denne arkitekturen og måten å jobbe på. 

Skriv litt om hvor i koden man måtte endret hvis man ville bruke database til persistens og hvis man ville sende e-post 
på ekte. Ikke forklar hvordan man bruker database og sender e-post på ekte - bare hvor i koden man ville ha koblet seg på.

1. Så gør vi litt mer detaljert til verks. Lag et sekvensdiagram som viser hele 
prosessen fra api-endpointet mottar en request til det returnerer et svar - for:
	A: Det å tegne abonnement (subscribe/)
	B: Det å bekrefte abonnement
	Eksempel - ikke kvalitetssikret og ikke n�dvendigvis komplett: 
	https://mermaid.live/edit#pako:eNptklFvmzAUhf_KlZ9SiVIDSxr8UGkJlRZNWqKS7WHKiwM31BLYzDbTuij_vXagHWnGC_jynXPvPXAkhSqRMGLwV4eywEzwSvNmJ8FdLddWFKLl0sKyFijtdf3zZgXcwEYrrwsLA5NHWbZKSHtzTX_hsqxRe0Xe7U2hRWuFkkP5mn_CVn2Efc0Iq_TLNZ8tPJ1xy_fc4E72RD_77cODG5bBZp1v4c70jnuEI2DDRR2A5A3CqZc40vHDXAyWvK6H4cej5KKS39vJSD_sPAjHFj94LUpuse8GrnwWfOT9dgxy_vui0X9aeNDx2YLB6lv--LR1t-36IinTk9ni9t14JQ1qCxpNV9uR0cWySh6Ebri3uBzvLcK8Kwo0xtu0rg3CBMMqhJhSWH-9-Zeg4_vs2fAO7qAYuUPjXHjlQiABqbQoCbO6w4A06Ah_JEfvtiP2GV1WhLnHEg_cD0928uRk7rv_VKp5U2rVVc-EHXht3KlrfeTDT_2OoCxRL1UnLWFxdLYg7Ej-EBbdT8N4NkvnKaX36TQNyIsvzsI4iWeuFtF0TpP4FJC_5540nEc0mSbRJ5rGaTSdJ6dXylcVcg
Forklar også hele sekvensen med ord. 

1. Oppsummer i tekst hva de sentrale klassene er - bare klassene som faktisk er nevnt i sekvensdiagrammet. Skriv hva som
er ansvaret til hver enkelt klasse, typisk en setning per klasse. 

1. Tenk gjerne gjennom om det er andre ting som med fordel kunne væxrt visualisert, men ikke lag noe diagram uten å forklare
diagrammet med ord - hva er det dette diagrammet viser/forklarer?
