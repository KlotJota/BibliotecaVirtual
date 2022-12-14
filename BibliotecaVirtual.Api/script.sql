Build started...
Build succeeded.
The Entity Framework tools version '6.0.9' is older than that of the runtime '6.0.10'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.10 initialized 'BDBiblioteca' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.10' with options: None
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categorias] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Cursos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Turno] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Favoritos] (
    [Id] int NOT NULL IDENTITY,
    [AlunoId] int NOT NULL,
    CONSTRAINT [PK_Favoritos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Locacoes] (
    [Id] int NOT NULL IDENTITY,
    [AlunoId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Locacoes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Livros] (
    [Id] int NOT NULL IDENTITY,
    [ImagemUrl] nvarchar(max) NOT NULL,
    [NomeLivro] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [Autor] nvarchar(max) NOT NULL,
    [Quantidade] int NOT NULL,
    [QtdPaginas] int NOT NULL,
    [Editora] nvarchar(max) NOT NULL,
    [CategoriaId] int NOT NULL,
    CONSTRAINT [PK_Livros] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Livros_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Cpf] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Status] int NOT NULL,
    [LocacoesId] int NULL,
    [FavoritosId] int NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [Ra] nvarchar(max) NULL,
    [CursoId] int NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuarios_Cursos_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Cursos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Usuarios_Favoritos_FavoritosId] FOREIGN KEY ([FavoritosId]) REFERENCES [Favoritos] ([Id]),
    CONSTRAINT [FK_Usuarios_Locacoes_LocacoesId] FOREIGN KEY ([LocacoesId]) REFERENCES [Locacoes] ([Id])
);
GO

CREATE TABLE [FavoritoLivros] (
    [Id] int NOT NULL IDENTITY,
    [FavoritoId] int NOT NULL,
    [LivroId] int NOT NULL,
    CONSTRAINT [PK_FavoritoLivros] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_FavoritoLivros_Favoritos_FavoritoId] FOREIGN KEY ([FavoritoId]) REFERENCES [Favoritos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_FavoritoLivros_Livros_LivroId] FOREIGN KEY ([LivroId]) REFERENCES [Livros] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [LocacoesLivros] (
    [Id] int NOT NULL IDENTITY,
    [Quantidade] int NOT NULL,
    [LocacaoId] int NOT NULL,
    [LivroId] int NOT NULL,
    CONSTRAINT [PK_LocacoesLivros] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LocacoesLivros_Livros_LivroId] FOREIGN KEY ([LivroId]) REFERENCES [Livros] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_LocacoesLivros_Locacoes_LocacaoId] FOREIGN KEY ([LocacaoId]) REFERENCES [Locacoes] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[Categorias]'))
    SET IDENTITY_INSERT [Categorias] ON;
INSERT INTO [Categorias] ([Id], [Nome])
VALUES (1, N'ProgramaÃ§Ã£o'),
(2, N'AdministraÃ§Ã£o'),
(3, N'Arquitetura');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[Categorias]'))
    SET IDENTITY_INSERT [Categorias] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'Turno') AND [object_id] = OBJECT_ID(N'[Cursos]'))
    SET IDENTITY_INSERT [Cursos] ON;
INSERT INTO [Cursos] ([Id], [Nome], [Turno])
VALUES (1, N'Ads', N'Tarde'),
(2, N'InformÃ¡tica para negÃ³cios', N'Noite');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'Turno') AND [object_id] = OBJECT_ID(N'[Cursos]'))
    SET IDENTITY_INSERT [Cursos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AlunoId') AND [object_id] = OBJECT_ID(N'[Favoritos]'))
    SET IDENTITY_INSERT [Favoritos] ON;
INSERT INTO [Favoritos] ([Id], [AlunoId])
VALUES (1, 49),
(2, 50);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AlunoId') AND [object_id] = OBJECT_ID(N'[Favoritos]'))
    SET IDENTITY_INSERT [Favoritos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AlunoId') AND [object_id] = OBJECT_ID(N'[Locacoes]'))
    SET IDENTITY_INSERT [Locacoes] ON;
INSERT INTO [Locacoes] ([Id], [AlunoId])
VALUES (1, N'1'),
(2, N'2');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AlunoId') AND [object_id] = OBJECT_ID(N'[Locacoes]'))
    SET IDENTITY_INSERT [Locacoes] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'Discriminator', N'Email', N'FavoritosId', N'LocacoesId', N'Nome', N'Senha', N'Status', N'Telefone') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [Cpf], [Discriminator], [Email], [FavoritosId], [LocacoesId], [Nome], [Senha], [Status], [Telefone])
VALUES (3, N'23232421', N'Administrador', N'henrique@gmail.com', NULL, NULL, N'Henrique', N'churrasco12', 1, N'991726623');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'Discriminator', N'Email', N'FavoritosId', N'LocacoesId', N'Nome', N'Senha', N'Status', N'Telefone') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Autor', N'CategoriaId', N'Descricao', N'Editora', N'ImagemUrl', N'NomeLivro', N'QtdPaginas', N'Quantidade') AND [object_id] = OBJECT_ID(N'[Livros]'))
    SET IDENTITY_INSERT [Livros] ON;
INSERT INTO [Livros] ([Id], [Autor], [CategoriaId], [Descricao], [Editora], [ImagemUrl], [NomeLivro], [QtdPaginas], [Quantidade])
VALUES (1, N'Steven Spielberg', 1, N'Este livro Ã© muito bom', N'Nova', N'/Livros/livro1.png', N'O Codificador Limpo', 198, 0),
(2, N'Ducatti', 2, N'Este livro Ã© muito bala foda pra porra', N'Velha', N'/Livros/livro2.png', N'Curso Intensivo de Pyhton', 120, 0),
(3, N'BoisÃ©s Camilo', 3, N'Este livro Ã© muito grande BoisÃ© quem o diga', N'BoisÃ©s Inc.', N'/Livros/livro3.png', N'Algoritmos e LÃ³gica de ProgramaÃ§Ã£o', 100, 0),
(4, N'Steven Spielberg', 3, N'Que que essa porra de livro ta fazendo aqui', N'Casseta', N'/Livros/livro4.png', N'O CemitÃ©rio', 160, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Autor', N'CategoriaId', N'Descricao', N'Editora', N'ImagemUrl', N'NomeLivro', N'QtdPaginas', N'Quantidade') AND [object_id] = OBJECT_ID(N'[Livros]'))
    SET IDENTITY_INSERT [Livros] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'CursoId', N'Discriminator', N'Email', N'FavoritosId', N'LocacoesId', N'Nome', N'Ra', N'Senha', N'Status', N'Telefone') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [Cpf], [CursoId], [Discriminator], [Email], [FavoritosId], [LocacoesId], [Nome], [Ra], [Senha], [Status], [Telefone])
VALUES (1, N'33034799', 1, N'Aluno', N'artur@gmail.com', NULL, NULL, N'Artur', N'40028922', N'paodeakho', 2, N'991726623'),
(2, N'91289123', 2, N'Aluno', N'zomboid@gmail.com', NULL, NULL, N'Zomboid', N'912903001', N'casseta15', 2, N'991212662');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'CursoId', N'Discriminator', N'Email', N'FavoritosId', N'LocacoesId', N'Nome', N'Ra', N'Senha', N'Status', N'Telefone') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

CREATE INDEX [IX_FavoritoLivros_FavoritoId] ON [FavoritoLivros] ([FavoritoId]);
GO

CREATE INDEX [IX_FavoritoLivros_LivroId] ON [FavoritoLivros] ([LivroId]);
GO

CREATE INDEX [IX_Livros_CategoriaId] ON [Livros] ([CategoriaId]);
GO

CREATE INDEX [IX_LocacoesLivros_LivroId] ON [LocacoesLivros] ([LivroId]);
GO

CREATE INDEX [IX_LocacoesLivros_LocacaoId] ON [LocacoesLivros] ([LocacaoId]);
GO

CREATE INDEX [IX_Usuarios_CursoId] ON [Usuarios] ([CursoId]);
GO

CREATE INDEX [IX_Usuarios_FavoritosId] ON [Usuarios] ([FavoritosId]);
GO

CREATE INDEX [IX_Usuarios_LocacoesId] ON [Usuarios] ([LocacoesId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221123232256_migracao1', N'6.0.10');
GO

COMMIT;
GO


