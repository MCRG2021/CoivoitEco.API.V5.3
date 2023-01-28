USE [CovoitEco.Database.dev3]
GO

/****** Object:  Table [dbo].[Utilisateur]    Script Date: 27/01/2023 15:41:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Utilisateur](
	[UTL_Id] [int] IDENTITY(1,1) NOT NULL,
	[UTL_Nom] [nvarchar](max) NOT NULL,
	[UTL_Prenom] [nvarchar](max) NOT NULL,
	[UTL_Mail] [nvarchar](max) NOT NULL,
	[UTL_Actif] [bit] NOT NULL,
	[UTL_IdAuth0] [int] NOT NULL,
 CONSTRAINT [PK_Utilisateur] PRIMARY KEY CLUSTERED 
(
	[UTL_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Utilisateur] ADD  CONSTRAINT [DF_Utilisateur_UTL_Actif]  DEFAULT ((1)) FOR [UTL_Actif]
GO

CREATE TABLE [dbo].[StatutResevation](
	[STATRES_Id] [int] IDENTITY(1,1) NOT NULL,
	[STATRES_Libelle] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StatutResevation] PRIMARY KEY CLUSTERED 
(
	[STATRES_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[StatutAnnonce](
	[STATANN_Id] [int] IDENTITY(1,1) NOT NULL,
	[STATANN_Libelle] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StatutAnnonce] PRIMARY KEY CLUSTERED 
(
	[STATANN_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Vehicule](
	[VEH_Id] [int] IDENTITY(1,1) NOT NULL,
	[VEH_Immatriculation] [nvarchar](max) NOT NULL,
	[VEH_Couleur] [nvarchar](max) NOT NULL,
	[VEH_Courant] [bit] NOT NULL,
	[VEH_Disponible] [bit] NOT NULL,
	[VEH_Marque] [nvarchar](max) NOT NULL,
	[VEH_Modele] [nvarchar](max) NOT NULL,
	[VEH_NombrePlace] [int] NOT NULL,
	[VEH_NormeEuro] [int] NOT NULL,
	[VEH_UTL_Id] [int] NOT NULL,
 CONSTRAINT [PK_Vehicule] PRIMARY KEY CLUSTERED 
(
	[VEH_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Vehicule] ADD  CONSTRAINT [DF_Vehicule_VEH_Courant]  DEFAULT ((0)) FOR [VEH_Courant]
GO

ALTER TABLE [dbo].[Vehicule] ADD  CONSTRAINT [DF_Vehicule_VEH_Disponible]  DEFAULT ((1)) FOR [VEH_Disponible]
GO

ALTER TABLE [dbo].[Vehicule]  WITH CHECK ADD  CONSTRAINT [FK_Vehicule_Utilisateur] FOREIGN KEY([VEH_UTL_Id])
REFERENCES [dbo].[Utilisateur] ([UTL_Id])
GO

ALTER TABLE [dbo].[Vehicule] CHECK CONSTRAINT [FK_Vehicule_Utilisateur]
GO

CREATE TABLE [dbo].[Note](
	[NOT_Id] [int] IDENTITY(1,1) NOT NULL,
	[NOT_Cotation] [real] NOT NULL,
	[NOT_UTL_Id] [int] NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[NOT_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Utilisateur] FOREIGN KEY([NOT_UTL_Id])
REFERENCES [dbo].[Utilisateur] ([UTL_Id])
GO

ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Utilisateur]
GO

CREATE TABLE [dbo].[Notification](
	[NOTIF_Id] [int] IDENTITY(1,1) NOT NULL,
	[NOTIF_Libelle] [nvarchar](max) NOT NULL,
	[ROL_UTL_Id] [int] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[NOTIF_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Utilisateur] FOREIGN KEY([ROL_UTL_Id])
REFERENCES [dbo].[Utilisateur] ([UTL_Id])
GO

ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Utilisateur]
GO

CREATE TABLE [dbo].[Recherche](
	[RECH_Id] [int] IDENTITY(1,1) NOT NULL,
	[RECH_DateEnregistrement] [datetime2](7) NOT NULL,
	[RECH_LocaliteDepart] [nvarchar](max) NOT NULL,
	[RECH_LocaliteArrvie] [nvarchar](max) NOT NULL,
	[RECH_HeureDepart] [datetime2](7) NOT NULL,
	[RECH_UTL_Id] [int] NOT NULL,
 CONSTRAINT [PK_Recherche] PRIMARY KEY CLUSTERED 
(
	[RECH_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Recherche]  WITH CHECK ADD  CONSTRAINT [FK_Recherche_Utilisateur] FOREIGN KEY([RECH_UTL_Id])
REFERENCES [dbo].[Utilisateur] ([UTL_Id])
GO

ALTER TABLE [dbo].[Recherche] CHECK CONSTRAINT [FK_Recherche_Utilisateur]
GO

CREATE TABLE [dbo].[Annonce](
	[ANN_Id] [int] IDENTITY(1,1) NOT NULL,
	[ANN_DatePublication] [datetime2](7) NOT NULL,
	[ANN_Prix] [real] NOT NULL,
	[ANN_LocaliteDepart] [nvarchar](max) NOT NULL,
	[ANN_LocaliteArrive] [nvarchar](max) NOT NULL,
	[ANN_DateDepart] [datetime2](7) NOT NULL,
	[ANN_DateArrive] [datetime2](7) NOT NULL,
	[ANN_OptAutoroute] [bit] NOT NULL,
	[ANN_OptFumeur] [bit] NOT NULL,
	[ANN_OptAnimaux] [bit] NOT NULL,
	[ANN_VEH_Id] [int] NOT NULL,
	[ANN_STATANN_Id] [int] NOT NULL,
	[ANN_UTL_Id] [int] NOT NULL,
 CONSTRAINT [PK_Annonce] PRIMARY KEY CLUSTERED 
(
	[ANN_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Annonce] ADD  CONSTRAINT [DF_Annonce_ANN_OptAutoroute]  DEFAULT ((0)) FOR [ANN_OptAutoroute]
GO

ALTER TABLE [dbo].[Annonce] ADD  CONSTRAINT [DF_Annonce_ANN_OptFumeur]  DEFAULT ((0)) FOR [ANN_OptFumeur]
GO

ALTER TABLE [dbo].[Annonce] ADD  CONSTRAINT [DF_Annonce_ANN_OptAnimaux]  DEFAULT ((0)) FOR [ANN_OptAnimaux]
GO

ALTER TABLE [dbo].[Annonce]  WITH CHECK ADD  CONSTRAINT [FK_Annonce_StatutAnnonce] FOREIGN KEY([ANN_STATANN_Id])
REFERENCES [dbo].[StatutAnnonce] ([STATANN_Id])
GO

ALTER TABLE [dbo].[Annonce] CHECK CONSTRAINT [FK_Annonce_StatutAnnonce]
GO

ALTER TABLE [dbo].[Annonce]  WITH CHECK ADD  CONSTRAINT [FK_Annonce_Utilisateur] FOREIGN KEY([ANN_UTL_Id])
REFERENCES [dbo].[Utilisateur] ([UTL_Id])
GO

ALTER TABLE [dbo].[Annonce] CHECK CONSTRAINT [FK_Annonce_Utilisateur]
GO

ALTER TABLE [dbo].[Annonce]  WITH CHECK ADD  CONSTRAINT [FK_Annonce_Vehicule] FOREIGN KEY([ANN_VEH_Id])
REFERENCES [dbo].[Vehicule] ([VEH_Id])
GO

ALTER TABLE [dbo].[Annonce] CHECK CONSTRAINT [FK_Annonce_Vehicule]
GO

CREATE TABLE [dbo].[Reservation](
	[RES_Id] [int] IDENTITY(1,1) NOT NULL,
	[RES_DateReservation] [datetime2](7) NOT NULL,
	[RES_ANN_Id] [int] NOT NULL,
	[RES_STATRES_Id] [int] NOT NULL,
	[RES_UTL_Id] [int] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[RES_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Annonce] FOREIGN KEY([RES_ANN_Id])
REFERENCES [dbo].[Annonce] ([ANN_Id])
GO

ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Annonce]
GO

ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_StatutResevation] FOREIGN KEY([RES_STATRES_Id])
REFERENCES [dbo].[StatutResevation] ([STATRES_Id])
GO

ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_StatutResevation]
GO

ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Utilisateur] FOREIGN KEY([RES_UTL_Id])
REFERENCES [dbo].[Utilisateur] ([UTL_Id])
GO

ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Utilisateur]
GO

CREATE TABLE [dbo].[Facture](
	[FACT_Id] [int] IDENTITY(1,1) NOT NULL,
	[FACT_DateCreation] [datetime2](7) NOT NULL,
	[FACT_DatePayment] [datetime2](7) NULL,
	[FACT_Resolus] [bit] NOT NULL,
	[FACT_RES_Id] [int] NOT NULL,
 CONSTRAINT [PK_Facture] PRIMARY KEY CLUSTERED 
(
	[FACT_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Facture] ADD  CONSTRAINT [DF_Facture_FACT_Resolus]  DEFAULT ((0)) FOR [FACT_Resolus]
GO

ALTER TABLE [dbo].[Facture]  WITH CHECK ADD  CONSTRAINT [FK_Facture_Reservation] FOREIGN KEY([FACT_RES_Id])
REFERENCES [dbo].[Reservation] ([RES_Id])
GO

ALTER TABLE [dbo].[Facture] CHECK CONSTRAINT [FK_Facture_Reservation]
GO
CREATE TABLE [dbo].[Role](
	[ROL_Id] [int] IDENTITY(1,1) NOT NULL,
	[ROL_Libelle] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ROL_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO