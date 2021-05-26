USE WishList
GO

INSERT INTO Usuarios (email, senha)
VALUES				 ('usuario@gmail.com', '123')
					,('joazinho@joao.com', '1234')
					,('pedrinho@gmail.com', '12345');
GO

INSERT INTO Desejos (idUsuario, descricao, dataCriacao)
VALUES				(1, 'Ter um carro do ano', '26/05/2021')
				   ,(1, 'Comprar um ps5', '25/10/2020')
				   ,(2, 'Comprar um Pc gamer', '14/08/2019')
				   ,(2, 'Viajar para disney', '16/02/2021')
				   ,(3, 'Passar no vestibular', '04/10/2019')
				   ,(3, 'Comprar uma casa', '13/09/2021');
GO
			