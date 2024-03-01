-- PRIMA TABELLA
CREATE TABLE [dbo].[Anagrafica](
    [IdAnagrafica] [int] IDENTITY(1,1) NOT NULL,
    [Cognome] [varchar](30) NOT NULL,
    [Nome] [varchar](30) NOT NULL,
    [Indirizzo] [nvarchar](50) NOT NULL,
    [Città] [varchar](30) NOT NULL,
    [CAP] [char](5) NOT NULL,
    [Cod_Fisc] [char](16) NOT NULL,
 CONSTRAINT [PK_Anagrafiche] PRIMARY KEY CLUSTERED 
(
    [IdAnagrafica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- SECONDA TABELLA
CREATE TABLE [dbo].[TipoDiViolazione](
    [IdViolazione] [int] NOT NULL,
    [Descrizione] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_TipiViolazione] PRIMARY KEY CLUSTERED 
(
    [IdViolazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- TERZA TABELLA
CREATE TABLE [dbo].[Verbale](
    [IdVerbale] [int] IDENTITY(1,1) NOT NULL,
    [DataViolazione] [date] NOT NULL,
    [IndirizzoViolazione] [nvarchar](30) NOT NULL,
    [Nominativo_Agente] [varchar](30) NOT NULL,
    [DataTrascrizioneVerbale] [date] NOT NULL,
    [Importo] [smallmoney] NOT NULL,
    [DecurtamentoPunti] [int] NOT NULL,
    [IdAnagrafica] [int] NOT NULL,
    [IdViolazione] [int] NOT NULL,
 CONSTRAINT [PK_Verbali] PRIMARY KEY CLUSTERED 
(
    [IdVerbale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Verbali] ADD CONSTRAINT [DF_Verbali_DecurtamentoPunti] DEFAULT ((0)) FOR [DecurtamentoPunti]
GOs