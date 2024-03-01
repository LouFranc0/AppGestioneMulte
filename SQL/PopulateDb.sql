-- Popolamento della prima tabella (Anagrafiche)
INSERT INTO [dbo].[Anagrafica] (Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc)
VALUES
    ('Rossi', 'Mario', 'Via Roma 1', 'Roma', '00100', 'RSSMRA80M01H501A'),
    ('Verdi', 'Anna', 'Via Milano 2', 'Milano', '20100', 'VRDANN75M02H502B'),
    ('Bianchi', 'Luca', 'Corso Napoli 3', 'Napoli', '80100', 'BNCLUA85M03H503C'),
    ('Ferrari', 'Laura', 'Viale Torino 4', 'Torino', '10100', 'FRRLRA90M04H504D'),
    ('Ricci', 'Roberto', 'Piazza Firenze 5', 'Firenze', '50100', 'RCCRTB85M05H505E');

-- Popolamento della seconda tabella (TipiViolazione)
INSERT INTO [dbo].[TipoDiViolazione] (IdViolazione, Descrizione)
VALUES
    (1, 'Eccesso di velocità'),
    (2, 'Guida in stato d''ebbreza'),
    (3, 'Violazione del semaforo rosso'),
    (4, 'Manutenzione insufficente del veicolo'),
