SET IDENTITY_INSERT [dbo].[CompetitionCategories] ON;

-- Inserting records with comp ids from 1 to 6 and category ids from 1 to 20
INSERT INTO [dbo].[CompetitionCategories] ([Id], [categoryId], [competitionId])
VALUES
    (1, 1, 1),
    (2, 2, 1),
    (3, 3, 1),
    (4, 4, 1),
    (5, 5, 2),
    (6, 6, 2),
    (7, 7, 3)

SET IDENTITY_INSERT [dbo].[CompetitionCategories] OFF;