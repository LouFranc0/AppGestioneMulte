-- Popolamento della terza tabella (Verbali)
INSERT INTO [dbo].[Verbale] (DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica, IdViolazione)
VALUES
    ('2023-01-15', 'Via Roma 1', 'Agente1', '2023-01-20', 100.00, 2, 1, 1),
    ('2023-02-10', 'Via Milano 2', 'Agente2', '2023-02-15', 150.00, 3, 2, 2),
    ('2023-03-05', 'Corso Napoli 3', 'Agente3', '2023-03-10', 120.00, 2, 3, 3),
    ('2023-04-20', 'Viale Torino 4', 'Agente1', '2023-04-25', 200.00, 4, 4, 4),
    ('2023-05-12', 'Piazza Firenze 5', 'Agente2', '2023-05-18', 180.00, 3, 5, 5); 