-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.1.35-community


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema inter
--

CREATE DATABASE IF NOT EXISTS inter;
USE inter;

--
-- Definition of table `adi_atribuicao_disciplina`
--

DROP TABLE IF EXISTS `adi_atribuicao_disciplina`;
CREATE TABLE `adi_atribuicao_disciplina` (
  `ADI_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `ADI_SEMESTRE_ANO` varchar(10) NOT NULL,
  `ADI_MAE` tinyint(1) NOT NULL,
  `TRM_CODIGO` int(11) NOT NULL,
  `PRO_MATRICULA` int(11) NOT NULL,
  `DGE_CODIGO` int(11) NOT NULL,
  PRIMARY KEY (`ADI_CODIGO`),
  KEY `TRM_CODIGO` (`TRM_CODIGO`),
  KEY `PRO_MATRICULA` (`PRO_MATRICULA`),
  KEY `DGE_CODIGO` (`DGE_CODIGO`),
  CONSTRAINT `adi_atribuicao_disciplina_ibfk_1` FOREIGN KEY (`TRM_CODIGO`) REFERENCES `trm_turma` (`TRM_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `adi_atribuicao_disciplina_ibfk_2` FOREIGN KEY (`PRO_MATRICULA`) REFERENCES `pro_professor` (`PRO_MATRICULA`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `adi_atribuicao_disciplina_ibfk_3` FOREIGN KEY (`DGE_CODIGO`) REFERENCES `dge_disciplinas_gerais` (`DGE_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `adi_atribuicao_disciplina`
--

/*!40000 ALTER TABLE `adi_atribuicao_disciplina` DISABLE KEYS */;
INSERT INTO `adi_atribuicao_disciplina` (`ADI_CODIGO`,`ADI_SEMESTRE_ANO`,`ADI_MAE`,`TRM_CODIGO`,`PRO_MATRICULA`,`DGE_CODIGO`) VALUES 
 (1,'2014-2',1,1,4,1),
 (2,'2014-2',1,1,5,3),
 (3,'2014-2',1,2,6,5),
 (4,'2014-2',0,1,6,4);
/*!40000 ALTER TABLE `adi_atribuicao_disciplina` ENABLE KEYS */;


--
-- Definition of table `alu_aluno`
--

DROP TABLE IF EXISTS `alu_aluno`;
CREATE TABLE `alu_aluno` (
  `ALU_MATRICULA` int(11) NOT NULL AUTO_INCREMENT,
  `PES_CODIGO` int(11) NOT NULL,
  PRIMARY KEY (`ALU_MATRICULA`),
  KEY `PES_CODIGO` (`PES_CODIGO`),
  CONSTRAINT `alu_aluno_ibfk_1` FOREIGN KEY (`PES_CODIGO`) REFERENCES `pes_pessoas` (`PES_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `alu_aluno`
--

/*!40000 ALTER TABLE `alu_aluno` DISABLE KEYS */;
INSERT INTO `alu_aluno` (`ALU_MATRICULA`,`PES_CODIGO`) VALUES 
 (1,7),
 (2,8),
 (3,9);
/*!40000 ALTER TABLE `alu_aluno` ENABLE KEYS */;


--
-- Definition of table `cge_criterios_gerais`
--

DROP TABLE IF EXISTS `cge_criterios_gerais`;
CREATE TABLE `cge_criterios_gerais` (
  `CGE_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `CGE_NOME` varchar(50) NOT NULL,
  `CGE_DESCRICAO` varchar(50) NOT NULL,
  `CGE_ATIVO` tinyint(1) NOT NULL,
  PRIMARY KEY (`CGE_CODIGO`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cge_criterios_gerais`
--

/*!40000 ALTER TABLE `cge_criterios_gerais` DISABLE KEYS */;
INSERT INTO `cge_criterios_gerais` (`CGE_CODIGO`,`CGE_NOME`,`CGE_DESCRICAO`,`CGE_ATIVO`) VALUES 
 (1,'Postura','Desenvoltura do aluno na apresentação',1),
 (2,'Apresentação','Maneira do aluno apresentar',1),
 (3,'Vestimenta','Trajes devidamente adequados',1),
 (4,'Conhecimento','Conhecimento do aluno sobre o projeto',1),
 (5,'Fala','Dicção do aluno na apresentação',1);
/*!40000 ALTER TABLE `cge_criterios_gerais` ENABLE KEYS */;


--
-- Definition of table `cpi_criterio_pi`
--

DROP TABLE IF EXISTS `cpi_criterio_pi`;
CREATE TABLE `cpi_criterio_pi` (
  `CPI_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `CPI_PESO` int(11) NOT NULL,
  `PRI_CODIGO` int(11) NOT NULL,
  `ADI_CODIGO` int(11) NOT NULL,
  `CGE_CODIGO` int(11) NOT NULL,
  PRIMARY KEY (`CPI_CODIGO`),
  KEY `PRI_CODIGO` (`PRI_CODIGO`),
  KEY `ADI_CODIGO` (`ADI_CODIGO`),
  KEY `CGE_CODIGO` (`CGE_CODIGO`),
  CONSTRAINT `cpi_criterio_pi_ibfk_1` FOREIGN KEY (`PRI_CODIGO`) REFERENCES `pri_projeto_inter` (`PRI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `cpi_criterio_pi_ibfk_2` FOREIGN KEY (`ADI_CODIGO`) REFERENCES `pri_projeto_inter` (`ADI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `cpi_criterio_pi_ibfk_3` FOREIGN KEY (`CGE_CODIGO`) REFERENCES `cge_criterios_gerais` (`CGE_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cpi_criterio_pi`
--

/*!40000 ALTER TABLE `cpi_criterio_pi` DISABLE KEYS */;
/*!40000 ALTER TABLE `cpi_criterio_pi` ENABLE KEYS */;


--
-- Definition of table `cur_curso`
--

DROP TABLE IF EXISTS `cur_curso`;
CREATE TABLE `cur_curso` (
  `CUR_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `CUR_NOME` varchar(50) NOT NULL,
  `CUR_SIGLA` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`CUR_CODIGO`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cur_curso`
--

/*!40000 ALTER TABLE `cur_curso` DISABLE KEYS */;
INSERT INTO `cur_curso` (`CUR_CODIGO`,`CUR_NOME`,`CUR_SIGLA`) VALUES 
 (1,'Análise e Desenvolvimento de Sistemas','ADS'),
 (2,'Gestão Empresarial','GE'),
 (3,'Gestão Financeira','GF'),
 (4,'Logística','LOG'),
 (5,'Gestão da Tecnologia da Informação','GTI');
/*!40000 ALTER TABLE `cur_curso` ENABLE KEYS */;


--
-- Definition of table `dal_disciplina_aluno`
--

DROP TABLE IF EXISTS `dal_disciplina_aluno`;
CREATE TABLE `dal_disciplina_aluno` (
  `ALU_MATRICULA` int(11) NOT NULL,
  `ADI_CODIGO` int(11) NOT NULL,
  `DAL_SEMESTRE_ANO` varchar(10) NOT NULL,
  PRIMARY KEY (`ALU_MATRICULA`,`ADI_CODIGO`),
  KEY `ADI_CODIGO` (`ADI_CODIGO`),
  CONSTRAINT `dal_disciplina_aluno_ibfk_1` FOREIGN KEY (`ALU_MATRICULA`) REFERENCES `alu_aluno` (`ALU_MATRICULA`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `dal_disciplina_aluno_ibfk_2` FOREIGN KEY (`ADI_CODIGO`) REFERENCES `adi_atribuicao_disciplina` (`ADI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dal_disciplina_aluno`
--

/*!40000 ALTER TABLE `dal_disciplina_aluno` DISABLE KEYS */;
INSERT INTO `dal_disciplina_aluno` (`ALU_MATRICULA`,`ADI_CODIGO`,`DAL_SEMESTRE_ANO`) VALUES 
 (1,1,'2014-2'),
 (2,1,'2014-2'),
 (3,3,'2014-2');
/*!40000 ALTER TABLE `dal_disciplina_aluno` ENABLE KEYS */;


--
-- Definition of table `dge_disciplinas_gerais`
--

DROP TABLE IF EXISTS `dge_disciplinas_gerais`;
CREATE TABLE `dge_disciplinas_gerais` (
  `DGE_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `DGE_NOME` varchar(50) NOT NULL,
  `DGE_SIGLA` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`DGE_CODIGO`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dge_disciplinas_gerais`
--

/*!40000 ALTER TABLE `dge_disciplinas_gerais` DISABLE KEYS */;
INSERT INTO `dge_disciplinas_gerais` (`DGE_CODIGO`,`DGE_NOME`,`DGE_SIGLA`) VALUES 
 (1,'Interação Humano Computador','IHC'),
 (2,'Banco de Dados','BD'),
 (3,'Programação em Script','PS'),
 (4,'Engenharia de Software III','ESIII'),
 (5,'Engenharia de Software IV','ESIV');
/*!40000 ALTER TABLE `dge_disciplinas_gerais` ENABLE KEYS */;


--
-- Definition of table `eve_eventos`
--

DROP TABLE IF EXISTS `eve_eventos`;
CREATE TABLE `eve_eventos` (
  `EVE_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `EVE_DATA` date NOT NULL,
  `EVE_TIPO` varchar(50) NOT NULL,
  `PRI_CODIGO` int(11) NOT NULL,
  `ADI_CODIGO` int(11) NOT NULL,
  PRIMARY KEY (`EVE_CODIGO`),
  KEY `PRI_CODIGO` (`PRI_CODIGO`),
  KEY `ADI_CODIGO` (`ADI_CODIGO`),
  CONSTRAINT `eve_eventos_ibfk_1` FOREIGN KEY (`PRI_CODIGO`) REFERENCES `pri_projeto_inter` (`PRI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `eve_eventos_ibfk_2` FOREIGN KEY (`ADI_CODIGO`) REFERENCES `pri_projeto_inter` (`ADI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `eve_eventos`
--

/*!40000 ALTER TABLE `eve_eventos` DISABLE KEYS */;
/*!40000 ALTER TABLE `eve_eventos` ENABLE KEYS */;


--
-- Definition of table `gal_grupo_aluno`
--

DROP TABLE IF EXISTS `gal_grupo_aluno`;
CREATE TABLE `gal_grupo_aluno` (
  `GRU_CODIGO` int(11) NOT NULL,
  `ALU_MATRICULA` int(11) NOT NULL,
  KEY `GRU_CODIGO` (`GRU_CODIGO`),
  KEY `ALU_MATRICULA` (`ALU_MATRICULA`),
  CONSTRAINT `gal_grupo_aluno_ibfk_1` FOREIGN KEY (`GRU_CODIGO`) REFERENCES `gru_grupo` (`GRU_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `gal_grupo_aluno_ibfk_2` FOREIGN KEY (`ALU_MATRICULA`) REFERENCES `dal_disciplina_aluno` (`ALU_MATRICULA`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `gal_grupo_aluno`
--

/*!40000 ALTER TABLE `gal_grupo_aluno` DISABLE KEYS */;
/*!40000 ALTER TABLE `gal_grupo_aluno` ENABLE KEYS */;


--
-- Definition of table `gru_grupo`
--

DROP TABLE IF EXISTS `gru_grupo`;
CREATE TABLE `gru_grupo` (
  `GRU_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `GRU_NOME_PROJETO` varchar(80) NOT NULL,
  `GRU_MEDIA` double DEFAULT NULL,
  `GRU_FINALIZADO` tinyint(1) NOT NULL,
  `PRI_CODIGO` int(11) NOT NULL,
  `ADI_CODIGO` int(11) NOT NULL,
  PRIMARY KEY (`GRU_CODIGO`),
  KEY `PRI_CODIGO` (`PRI_CODIGO`),
  KEY `ADI_CODIGO` (`ADI_CODIGO`),
  CONSTRAINT `gru_grupo_ibfk_1` FOREIGN KEY (`PRI_CODIGO`) REFERENCES `pri_projeto_inter` (`PRI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `gru_grupo_ibfk_2` FOREIGN KEY (`ADI_CODIGO`) REFERENCES `pri_projeto_inter` (`ADI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `gru_grupo`
--

/*!40000 ALTER TABLE `gru_grupo` DISABLE KEYS */;
/*!40000 ALTER TABLE `gru_grupo` ENABLE KEYS */;


--
-- Definition of table `his_historico_disciplina`
--

DROP TABLE IF EXISTS `his_historico_disciplina`;
CREATE TABLE `his_historico_disciplina` (
  `HIS_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `HIS_NOTA` double DEFAULT NULL,
  `CPI_CODIGO` int(11) NOT NULL,
  `ADI_CODIGO` int(11) NOT NULL,
  `ALU_MATRICULA` int(11) NOT NULL,
  PRIMARY KEY (`HIS_CODIGO`),
  KEY `CPI_CODIGO` (`CPI_CODIGO`),
  KEY `ADI_CODIGO` (`ADI_CODIGO`),
  KEY `ALU_MATRICULA` (`ALU_MATRICULA`),
  CONSTRAINT `his_historico_disciplina_ibfk_1` FOREIGN KEY (`CPI_CODIGO`) REFERENCES `cpi_criterio_pi` (`CPI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `his_historico_disciplina_ibfk_2` FOREIGN KEY (`ADI_CODIGO`) REFERENCES `pri_projeto_inter` (`ADI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `his_historico_disciplina_ibfk_3` FOREIGN KEY (`ALU_MATRICULA`) REFERENCES `gal_grupo_aluno` (`ALU_MATRICULA`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `his_historico_disciplina`
--

/*!40000 ALTER TABLE `his_historico_disciplina` DISABLE KEYS */;
/*!40000 ALTER TABLE `his_historico_disciplina` ENABLE KEYS */;


--
-- Definition of table `mdd_media_disciplina`
--

DROP TABLE IF EXISTS `mdd_media_disciplina`;
CREATE TABLE `mdd_media_disciplina` (
  `MDD_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `MDD_MEDIA` double DEFAULT NULL,
  `PRI_CODIGO` int(11) NOT NULL,
  `ADI_CODIGO` int(11) NOT NULL,
  PRIMARY KEY (`MDD_CODIGO`),
  KEY `PRI_CODIGO` (`PRI_CODIGO`),
  KEY `ADI_CODIGO` (`ADI_CODIGO`),
  CONSTRAINT `mdd_media_disciplina_ibfk_1` FOREIGN KEY (`PRI_CODIGO`) REFERENCES `pri_projeto_inter` (`PRI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `mdd_media_disciplina_ibfk_2` FOREIGN KEY (`ADI_CODIGO`) REFERENCES `pri_projeto_inter` (`ADI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `mdd_media_disciplina`
--

/*!40000 ALTER TABLE `mdd_media_disciplina` DISABLE KEYS */;
/*!40000 ALTER TABLE `mdd_media_disciplina` ENABLE KEYS */;


--
-- Definition of table `pes_pessoas`
--

DROP TABLE IF EXISTS `pes_pessoas`;
CREATE TABLE `pes_pessoas` (
  `PES_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `PES_NOME` varchar(50) NOT NULL,
  `PES_EMAIL` varchar(50) NOT NULL,
  `PES_TEL` varchar(13) DEFAULT NULL,
  `PES_CEL` varchar(14) DEFAULT NULL,
  PRIMARY KEY (`PES_CODIGO`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pes_pessoas`
--

/*!40000 ALTER TABLE `pes_pessoas` DISABLE KEYS */;
INSERT INTO `pes_pessoas` (`PES_CODIGO`,`PES_NOME`,`PES_EMAIL`,`PES_TEL`,`PES_CEL`) VALUES 
 (1,'Vitorio','vitorio@fatecguaratingueta.edu.br','3131-3232','997998778'),
 (2,'Bruno','bruno@fatecguaratingueta.edu.br','3131-3232','997998778'),
 (3,'Albert','albert@fatecguaratingueta.edu.br','3131-3232','997998778'),
 (4,'Camila','camila@fatecguaratingueta.edu.br','3131-3232','997998778'),
 (5,'Rodrigo','rodrigo@fatecguaratingueta.edu.br','3131-3232','997998778'),
 (6,'Claudemir','claudemir@fatecguaratingueta.edu.br','3131-3232','997998778'),
 (7,'Gabriel','gabriel@fatecguaratingueta.edu.br','3131-3232','997998778'),
 (8,'Douglas','douglas@fatecguaratingueta.edu.br','3131-3232','997998778'),
 (9,'Felipe','felipe@fatecguaratingueta.edu.br','3131-3232','997998778');
/*!40000 ALTER TABLE `pes_pessoas` ENABLE KEYS */;

--
-- Definition of table `pri_projeto_inter`
--

DROP TABLE IF EXISTS `pri_projeto_inter`;
CREATE TABLE `pri_projeto_inter` (
  `PRI_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `SAN_SEMESTRE_ANO` int(11) NOT NULL,
  `PRI_DESCRICAO` varchar(100) NOT NULL,
  `PRI_EMENTA` text NOT NULL,
  `ADI_CODIGO` int(11) NOT NULL,
  PRIMARY KEY (`PRI_CODIGO`,`ADI_CODIGO`),
  KEY `ADI_CODIGO` (`ADI_CODIGO`),
  KEY `pri_projeto_inter_ibfk_2` (`SAN_SEMESTRE_ANO`),
  CONSTRAINT `pri_projeto_inter_ibfk_1` FOREIGN KEY (`ADI_CODIGO`) REFERENCES `adi_atribuicao_disciplina` (`ADI_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `pri_projeto_inter_ibfk_2` FOREIGN KEY (`SAN_SEMESTRE_ANO`) REFERENCES `san_semestre_ano` (`san_codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pri_projeto_inter`
--

/*!40000 ALTER TABLE `pri_projeto_inter` DISABLE KEYS */;
INSERT INTO `pri_projeto_inter` (`PRI_CODIGO`,`SAN_SEMESTRE_ANO`,`PRI_DESCRICAO`,`PRI_EMENTA`,`ADI_CODIGO`) VALUES 
 (1,3,'PI','Teste',3),
 (3,2,'Outro PI','Teste2',2);
/*!40000 ALTER TABLE `pri_projeto_inter` ENABLE KEYS */;


--
-- Definition of table `pro_professor`
--

drop table if exists adm_administrador;
create table adm_administrador(
adm_codigo int primary key auto_increment not null,
adm_senha varchar(50) not null,
pes_codigo int not null,
foreign key(pes_codigo) references pes_pessoas(pes_codigo) on delete cascade on update cascade);

insert into adm_administrador values
(1,'e56ae0f09aac66e1d00ce6c0b3c1cd622746380d',1),
(2,'04556b581f269b79f4ed5801f8532331c7cffaf5',2),
(3,'7679357857a838cae279d6123d61d629d38f32b7',3);

DROP TABLE IF EXISTS `pro_professor`;
CREATE TABLE `pro_professor` (
  `PRO_MATRICULA` int(11) NOT NULL AUTO_INCREMENT,
  `PRO_SENHA` varchar(200) NOT NULL,
  `PES_CODIGO` int(11) NOT NULL,
  adm_codigo int,
  PRIMARY KEY (`PRO_MATRICULA`),
  KEY `PES_CODIGO` (`PES_CODIGO`),
  CONSTRAINT `pro_professor_ibfk_1` FOREIGN KEY (`PES_CODIGO`) REFERENCES `pes_pessoas` (`PES_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  foreign key(adm_codigo) references adm_administrador(adm_codigo) on delete cascade on update cascade
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pro_professor`
--

/*!40000 ALTER TABLE `pro_professor` DISABLE KEYS */;
INSERT INTO `pro_professor` (`PRO_MATRICULA`,`PRO_ADMINISTRADOR`,`PRO_SENHA`,`PRO_CHAVE_SENHA`,`PES_CODIGO`) VALUES 
 (4,'b19df6c68faafd4c9925f0dfaf9b1eae4ad13525',4,null),
 (5,'1ac3cf657b0c16fc280e910c6bcbaaa39e243656',5,null),
 (6,'959c8d10fe2052757c4645650eff4825bbf206b0',6,null),
 (7,'04556b581f269b79f4ed5801f8532331c7cffaf5',2,2);
/*!40000 ALTER TABLE `pro_professor` ENABLE KEYS */;

--
-- Definition of table `req_requerimento`
--

DROP TABLE IF EXISTS `req_requerimento`;
CREATE TABLE `req_requerimento` (
  `REQ_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `REQ_DESCRICAO` text NOT NULL,
  `REQ_DATA_REQUISICAO` datetime NOT NULL,
  `REQ_DATA_INICIAL` datetime DEFAULT NULL,
  `REQ_DATA_FINAL` datetime DEFAULT NULL,
  `REQ_RESOLVIDO` tinyint(1) DEFAULT NULL,
  `PRO_MATRICULA` int(11) NOT NULL,
  `GRU_CODIGO` int(11) NOT NULL,
  PRIMARY KEY (`REQ_CODIGO`),
  KEY `PRO_MATRICULA` (`PRO_MATRICULA`),
  KEY `req_requerimento_ibfk_2` (`GRU_CODIGO`),
  CONSTRAINT `req_requerimento_ibfk_1` FOREIGN KEY (`PRO_MATRICULA`) REFERENCES `pro_professor` (`PRO_MATRICULA`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `req_requerimento_ibfk_2` FOREIGN KEY (`GRU_CODIGO`) REFERENCES `gru_grupo` (`GRU_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `req_requerimento`
--

/*!40000 ALTER TABLE `req_requerimento` DISABLE KEYS */;
/*!40000 ALTER TABLE `req_requerimento` ENABLE KEYS */;


--
-- Definition of table `san_semestre_ano`
--

DROP TABLE IF EXISTS `san_semestre_ano`;
CREATE TABLE `san_semestre_ano` (
  `san_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `san_ano` int(11) NOT NULL,
  `san_semestre` int(11) NOT NULL,
  `san_ativo` tinyint(1) NOT NULL,
  PRIMARY KEY (`san_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `san_semestre_ano`
--

/*!40000 ALTER TABLE `san_semestre_ano` DISABLE KEYS */;
INSERT INTO `san_semestre_ano` (`san_codigo`,`san_ano`,`san_semestre`,`san_ativo`) VALUES 
 (1,2014,1,0),
 (2,2014,2,0),
 (3,2015,1,1),
 (4,2015,2,0);
/*!40000 ALTER TABLE `san_semestre_ano` ENABLE KEYS */;


--
-- Definition of table `trm_turma`
--

DROP TABLE IF EXISTS `trm_turma`;
CREATE TABLE `trm_turma` (
  `TRM_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `TRM_NOME` varchar(50) NOT NULL,
  `TUR_CODIGO` int(11) NOT NULL,
  `CUR_CODIGO` int(11) NOT NULL,
  PRIMARY KEY (`TRM_CODIGO`),
  KEY `TUR_CODIGO` (`TUR_CODIGO`),
  KEY `CUR_CODIGO` (`CUR_CODIGO`),
  CONSTRAINT `trm_turma_ibfk_1` FOREIGN KEY (`TUR_CODIGO`) REFERENCES `tur_turno` (`TUR_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `trm_turma_ibfk_2` FOREIGN KEY (`CUR_CODIGO`) REFERENCES `cur_curso` (`CUR_CODIGO`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `trm_turma`
--

/*!40000 ALTER TABLE `trm_turma` DISABLE KEYS */;
INSERT INTO `trm_turma` (`TRM_CODIGO`,`TRM_NOME`,`TUR_CODIGO`,`CUR_CODIGO`) VALUES 
 (1,'4',1,1),
 (2,'5',1,1);
/*!40000 ALTER TABLE `trm_turma` ENABLE KEYS */;


--
-- Definition of table `tur_turno`
--

DROP TABLE IF EXISTS `tur_turno`;
CREATE TABLE `tur_turno` (
  `TUR_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `TUR_NOME` varchar(25) NOT NULL,
  PRIMARY KEY (`TUR_CODIGO`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tur_turno`
--

/*!40000 ALTER TABLE `tur_turno` DISABLE KEYS */;
INSERT INTO `tur_turno` (`TUR_CODIGO`,`TUR_NOME`) VALUES 
 (1,'Tarde'),
 (2,'Noite');
/*!40000 ALTER TABLE `tur_turno` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
