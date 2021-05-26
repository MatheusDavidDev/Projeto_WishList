USE WishList
GO

SELECT * FROM Usuarios

SELECT * FROM Desejos

SELECT Usuarios.email, Desejos.descricao, Desejos.dataCriacao FROM Usuarios
INNER JOIN Desejos
ON Usuarios.idUsuario = Desejos.idUsuario

