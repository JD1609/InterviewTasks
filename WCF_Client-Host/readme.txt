Obsah:
2 aplikace - "Administration app" & "Device"
-------------------------------------------------

-> spouštět ve VS jako administrátor!
******************************************************************************************



Administration app:
*********************
-slouží k zaznamenávání dat získaných z 'Device' app
	-obsahuje:
		-listBox pro zobrazení zařízení
		-dataGrid pro zobrazení přijatých zpráv/dat z 'Device'
		-button pro znovunačtení dat z SQL databáze


Device app:
*********************
-slouží k zasílání zpráv/dat do "Administration app" která je ukládá do SQL a lze
si je následně zobrazit
	-obsahuje:
		-možnost zadání 'device ID' (pro simulaci připojení různých zařízení)
		-možnost zadání odesílané zprávy/dat

