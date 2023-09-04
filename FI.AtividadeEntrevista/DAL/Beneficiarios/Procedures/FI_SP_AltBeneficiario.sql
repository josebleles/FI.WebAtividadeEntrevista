﻿CREATE PROC FI_SP_AltBeneficiario
    @NOME          VARCHAR (50) ,
    @CPF           VARCHAR (11),
    @IDCLIENTE    BIGINT,
	@Id           BIGINT
AS
BEGIN
	UPDATE CLIENTES 
	SET 
		NOME = @NOME, 
		CPF = @CPF, 
		IDCLIENTE = @IDCLIENTE
	WHERE Id = @Id
END