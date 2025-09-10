using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Geral
{
    [Table("profissao", Schema = "geral")]
    public class Profissao : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(120), Required] public string Nome { get; set; }
        public int Codigo { get; set; }
        [NotMapped] public static Profissao Abatedor => new Profissao(1, 848505, "Abatedor");
        [NotMapped] public static Profissao AcabadorDeCalcados => new Profissao(2, 764305, "Acabador de calçados");
        [NotMapped] public static Profissao AcabadorDeEmbalagensFlexiveisECartotecnicas => new Profissao(3, 766305, "Acabador de embalagens (flexíveis e cartotécnicas)");
        [NotMapped] public static Profissao AcabadorDeSuperficiesDeConcreto => new Profissao(4, 716105, "Acabador de superfícies de concreto");
        [NotMapped] public static Profissao Acougueiro => new Profissao(5, 848510, "Açougueiro");
        [NotMapped] public static Profissao Acrobata => new Profissao(6, 376205, "Acrobata");
        [NotMapped] public static Profissao AdestradorDeAnimais => new Profissao(7, 623005, "Adestrador de animais");
        [NotMapped] public static Profissao Administrador => new Profissao(8, 252105, "Administrador");
        [NotMapped] public static Profissao AdministradorDeBancoDeDados => new Profissao(9, 212305, "Administrador de banco de dados");
        [NotMapped] public static Profissao AdministradorDeEdificios => new Profissao(10, 510110, "Administrador de edifícios");
        [NotMapped] public static Profissao AdministradorDeFundosECarteirasDeInvestimento => new Profissao(11, 252505, "Administrador de fundos e carteiras de investimento");
        [NotMapped] public static Profissao AdministradorDeRedes => new Profissao(12, 212310, "Administrador de redes");
        [NotMapped] public static Profissao AdministradorDeSistemasOperacionais => new Profissao(13, 212315, "Administrador de sistemas operacionais");
        [NotMapped] public static Profissao AdministradorEmSegurancaDaInformacao => new Profissao(14, 212320, "Administrador em segurança da informação");
        [NotMapped] public static Profissao Advogado => new Profissao(15, 241005, "Advogado");
        [NotMapped] public static Profissao AdvogadoAreasEspeciais => new Profissao(16, 241030, "Advogado (áreas especiais)");
        [NotMapped] public static Profissao AdvogadoDireitoCivil => new Profissao(17, 241015, "Advogado (direito civil)");
        [NotMapped] public static Profissao AdvogadoDireitoDoTrabalho => new Profissao(18, 241035, "Advogado (direito do trabalho)");
        [NotMapped] public static Profissao AdvogadoDireitoPenal => new Profissao(19, 241025, "Advogado (direito penal)");
        [NotMapped] public static Profissao AdvogadoDireitoPublico => new Profissao(20, 241020, "Advogado (direito público)");
        [NotMapped] public static Profissao AdvogadoDaUniao => new Profissao(21, 241205, "Advogado da união");
        [NotMapped] public static Profissao AdvogadoDeEmpresa => new Profissao(22, 241010, "Advogado de empresa");
        [NotMapped] public static Profissao AfiadorDeCardas => new Profissao(23, 721305, "Afiador de cardas");
        [NotMapped] public static Profissao AfiadorDeCutelaria => new Profissao(24, 721310, "Afiador de cutelaria");
        [NotMapped] public static Profissao AfiadorDeFerramentas => new Profissao(25, 721315, "Afiador de ferramentas");
        [NotMapped] public static Profissao AfiadorDeSerras => new Profissao(26, 721320, "Afiador de serras");
        [NotMapped] public static Profissao AfinadorDeInstrumentosMusicais => new Profissao(27, 742105, "Afinador de instrumentos musicais");
        [NotMapped] public static Profissao Afretador => new Profissao(28, 342120, "Afretador");
        [NotMapped] public static Profissao AgenciadorDePropaganda => new Profissao(29, 253140, "Agenciador de propaganda");
        [NotMapped] public static Profissao AgenteComunitarioDeSaude => new Profissao(30, 515105, "Agente comunitário de saúde");
        [NotMapped] public static Profissao AgenteDeAcaoSocial => new Profissao(31, 515310, "Agente de ação social");
        [NotMapped] public static Profissao AgenteDeCombateAsEndemias => new Profissao(32, 515140, "Agente de combate às endemias");
        [NotMapped] public static Profissao AgenteDeDefesaAmbiental => new Profissao(33, 352205, "Agente de defesa ambiental");
        [NotMapped] public static Profissao AgenteDeDireitosAutorais => new Profissao(34, 352405, "Agente de direitos autorais");
        [NotMapped] public static Profissao AgenteDeEstacaoFerroviaEMetro => new Profissao(35, 342405, "Agente de estação (ferrovia e metrô)");
        [NotMapped] public static Profissao AgenteDeHigieneESeguranca => new Profissao(36, 254310, "Agente de higiene e segurança");
        [NotMapped] public static Profissao AgenteDeInteligencia => new Profissao(37, 351905, "Agente de inteligência");
        [NotMapped] public static Profissao AgenteDeManobraEDocagem => new Profissao(38, 215105, "Agente de manobra e docagem");
        [NotMapped] public static Profissao AgenteDeMicrocredito => new Profissao(39, 411050, "Agente de microcrédito");
        [NotMapped] public static Profissao AgenteDePatio => new Profissao(40, 783105, "Agente de pátio");
        [NotMapped] public static Profissao AgenteDePoliciaFederal => new Profissao(41, 517205, "Agente de polícia federal");
        [NotMapped] public static Profissao AgenteDePortaria => new Profissao(42, 517415, "Agente de portaria");
        [NotMapped] public static Profissao AgenteDeProtecaoDeAeroporto => new Profissao(43, 517305, "Agente de proteção de aeroporto");
        [NotMapped] public static Profissao AgenteDeProtecaoDeAviacaoCivil => new Profissao(44, 342550, "Agente de proteção de aviação civil");
        [NotMapped] public static Profissao AgenteDeRecrutamentoESelecao => new Profissao(45, 351315, "Agente de recrutamento e seleção");
        [NotMapped] public static Profissao AgenteDeSaudePublica => new Profissao(46, 352210, "Agente de saúde pública");
        [NotMapped] public static Profissao AgenteDeSeguranca => new Profissao(47, 517310, "Agente de segurança");
        [NotMapped] public static Profissao AgenteDeSegurancaPenitenciaria => new Profissao(48, 517315, "Agente de segurança penitenciária");
        [NotMapped] public static Profissao AgenteDeTransito => new Profissao(49, 517220, "Agente de trânsito");
        [NotMapped] public static Profissao AgenteDeVendasDeServicos => new Profissao(50, 354120, "Agente de vendas de serviços");
        [NotMapped] public static Profissao AgenteDeViagem => new Profissao(51, 354815, "Agente de viagem");
        [NotMapped] public static Profissao AgenteFiscalDeQualidade => new Profissao(52, 352310, "Agente fiscal de qualidade");
        [NotMapped] public static Profissao AgenteFiscalMetrologico => new Profissao(53, 352315, "Agente fiscal metrológico");
        [NotMapped] public static Profissao AgenteFiscalTextil => new Profissao(54, 352320, "Agente fiscal têxtil");
        [NotMapped] public static Profissao AgenteFunerario => new Profissao(55, 516505, "Agente funerário");
        [NotMapped] public static Profissao AgenteIndigenaDeSaneamento => new Profissao(56, 515130, "Agente indígena de saneamento");
        [NotMapped] public static Profissao AgenteIndigenaDeSaude => new Profissao(57, 515125, "Agente indígena de saúde");
        [NotMapped] public static Profissao AgenteTecnicoDeInteligencia => new Profissao(58, 351910, "Agente técnico de inteligência");
        [NotMapped] public static Profissao AjudanteDeCarvoaria => new Profissao(59, 632615, "Ajudante de carvoaria");
        [NotMapped] public static Profissao AjudanteDeConfeccao => new Profissao(60, 763125, "Ajudante de confecção");
        [NotMapped] public static Profissao AjudanteDeDespachanteAduaneiro => new Profissao(61, 342205, "Ajudante de despachante aduaneiro");
        [NotMapped] public static Profissao AjudanteDeMotorista => new Profissao(62, 783225, "Ajudante de motorista");
        [NotMapped] public static Profissao AjustadorDeInstrumentosDePrecisao => new Profissao(63, 741105, "Ajustador de instrumentos de precisão");
        [NotMapped] public static Profissao AjustadorFerramenteiro => new Profissao(64, 725005, "Ajustador ferramenteiro");
        [NotMapped] public static Profissao AjustadorMecanico => new Profissao(65, 725010, "Ajustador mecânico");
        [NotMapped] public static Profissao AjustadorMecanicoUsinagemEmBancadaEEmMaquinasFerramentas => new Profissao(66, 725015, "Ajustador mecânico (usinagem em bancada e em máquinas-ferramentas)");
        [NotMapped] public static Profissao AjustadorMecanicoEmBancada => new Profissao(67, 725020, "Ajustador mecânico em bancada");
        [NotMapped] public static Profissao AjustadorNavalReparoEConstrucao => new Profissao(68, 725025, "Ajustador naval (reparo e construção)");
        [NotMapped] public static Profissao Alambiqueiro => new Profissao(69, 841705, "Alambiqueiro");
        [NotMapped] public static Profissao Alfaiate => new Profissao(70, 763005, "Alfaiate");
        [NotMapped] public static Profissao AlimentadorDeLinhaDeProducao => new Profissao(71, 784205, "Alimentador de linha de produção");
        [NotMapped] public static Profissao AlinhadorDePneus => new Profissao(72, 992105, "Alinhador de pneus");
        [NotMapped] public static Profissao Almoxarife => new Profissao(73, 414105, "Almoxarife");
        [NotMapped] public static Profissao AlvejadorTecidos => new Profissao(74, 761405, "Alvejador (tecidos)");
        [NotMapped] public static Profissao AmarradorEDesamarradoDeEmbarcacoes => new Profissao(75, 783240, "Amarrador e desamarrado de embarcações");
        [NotMapped] public static Profissao AmostradorDeMinerios => new Profissao(76, 711105, "Amostrador de minérios");
        [NotMapped] public static Profissao AnalistaDeCambio => new Profissao(77, 252510, "Analista de câmbio");
        [NotMapped] public static Profissao AnalistaDeCobrancaInstituicoesFinanceiras => new Profissao(78, 252515, "Analista de cobrança (instituições financeiras)");
        [NotMapped] public static Profissao AnalistaDeCompliance => new Profissao(79, 142125, "Analista de compliance");
        [NotMapped] public static Profissao AnalistaDeCreditoInstituicoesFinanceiras => new Profissao(80, 252525, "Analista de crédito (instituições financeiras)");
        [NotMapped] public static Profissao AnalistaDeCreditoRural => new Profissao(81, 252530, "Analista de crédito rural");
        [NotMapped] public static Profissao AnalistaDeDesembaracoAduaneiro => new Profissao(82, 342215, "Analista de desembaraço aduaneiro");
        [NotMapped] public static Profissao AnalistaDeDesenvolvimentoDeSistemas => new Profissao(83, 212405, "Analista de desenvolvimento de sistemas");
        [NotMapped] public static Profissao AnalistaDeExportacaoEImportacao => new Profissao(84, 354305, "Analista de exportação e importação");
        [NotMapped] public static Profissao AnalistaDeFolhaDePagamento => new Profissao(85, 413105, "Analista de folha de pagamento");
        [NotMapped] public static Profissao AnalistaDeGestaoDeEstoque => new Profissao(86, 252725, "Analista de gestão de estoque");
        [NotMapped] public static Profissao AnalistaDeInformacaoEmSaude => new Profissao(87, 415310, "Analista de informação em saúde");
        [NotMapped] public static Profissao AnalistaDeInformacoesPesquisadorDeInformacoesDeRede => new Profissao(88, 261215, "Analista de informações (pesquisador de informações de rede)");
        [NotMapped] public static Profissao AnalistaDeLeasing => new Profissao(89, 252535, "Analista de leasing");
        [NotMapped] public static Profissao AnalistaDeLogistica => new Profissao(90, 252715, "Analista de logistica");
        [NotMapped] public static Profissao AnalistaDeManutencaoEquipamentosAereos => new Profissao(91, 391140, "Analista de manutenção (equipamentos aéreos)");
        [NotMapped] public static Profissao AnalistaDeMidiasSociais => new Profissao(92, 253405, "Analista de mídias sociais");
        [NotMapped] public static Profissao AnalistaDeNegocios => new Profissao(93, 142330, "Analista de negócios");
        [NotMapped] public static Profissao AnalistaDePcpProgramacaoEControleDaProducao => new Profissao(94, 252705, "Analista de pcp (programação e controle da produção)");
        [NotMapped] public static Profissao AnalistaDePesquisaDeMercado => new Profissao(95, 142335, "Analista de pesquisa de mercado");
        [NotMapped] public static Profissao AnalistaDePlanejamentoDeManutencao => new Profissao(96, 391145, "Analista de planejamento de manutenção");
        [NotMapped] public static Profissao AnalistaDePlanejamentoDeMaterias => new Profissao(97, 252710, "Analista de planejamento de materias");
        [NotMapped] public static Profissao AnalistaDePlanejamentoEOrcamentoApo => new Profissao(98, 111510, "Analista de planejamento e orçamento - apo");
        [NotMapped] public static Profissao AnalistaDeProdutosBancarios => new Profissao(99, 252540, "Analista de produtos bancários");
        [NotMapped] public static Profissao AnalistaDeProjetosLogisticos => new Profissao(100, 252720, "Analista de projetos logisticos");
        [NotMapped] public static Profissao AnalistaDeRecursosHumanos => new Profissao(101, 252405, "Analista de recursos humanos");
        [NotMapped] public static Profissao AnalistaDeRedesEDeComunicacaoDeDados => new Profissao(102, 212410, "Analista de redes e de comunicação de dados");
        [NotMapped] public static Profissao AnalistaDeRiscos => new Profissao(103, 142130, "Analista de riscos");
        [NotMapped] public static Profissao AnalistaDeSegurosTecnico => new Profissao(104, 351705, "Analista de seguros (técnico)");
        [NotMapped] public static Profissao AnalistaDeSinistros => new Profissao(105, 351710, "Analista de sinistros");
        [NotMapped] public static Profissao AnalistaDeSistemasDeAutomacao => new Profissao(106, 212415, "Analista de sistemas de automação");
        [NotMapped] public static Profissao AnalistaDeSuporteComputacional => new Profissao(107, 212420, "Analista de suporte computacional");
        [NotMapped] public static Profissao AnalistaDeTestesDeTecnologiaDaInformacao => new Profissao(108, 212430, "Analista de testes de tecnologia da informação");
        [NotMapped] public static Profissao AnalistaDeTransporteEmComercioExterior => new Profissao(109, 342105, "Analista de transporte em comércio exterior");
        [NotMapped] public static Profissao AnalistaFinanceiroInstituicoesFinanceiras => new Profissao(110, 252545, "Analista financeiro (instituições financeiras)");
        [NotMapped] public static Profissao AnalistaMusical => new Profissao(111, 374155, "Analista musical");
        [NotMapped] public static Profissao AncoraDeMidiasAudiovisuais => new Profissao(112, 261705, "Âncora de mídias audiovisuais");
        [NotMapped] public static Profissao Antropologo => new Profissao(113, 251105, "Antropólogo");
        [NotMapped] public static Profissao Apicultor => new Profissao(114, 613405, "Apicultor");
        [NotMapped] public static Profissao AplicadorDeAsfaltoImpermeabilizanteCoberturas => new Profissao(115, 715705, "Aplicador de asfalto impermeabilizante (coberturas)");
        [NotMapped] public static Profissao AplicadorDeProvasConcursoAvaliacaoExame => new Profissao(116, 424210, "Aplicador de provas (concurso, avaliação,exame)");
        [NotMapped] public static Profissao AplicadorDeVinilAutoadesivo => new Profissao(117, 523120, "Aplicador de vinil autoadesivo");
        [NotMapped] public static Profissao AplicadorSerigraficoEmVidros => new Profissao(118, 752205, "Aplicador serigráfico em vidros");
        [NotMapped] public static Profissao ApontadorDeMaoDeObra => new Profissao(119, 414205, "Apontador de mão-de-obra");
        [NotMapped] public static Profissao ApontadorDeProducao => new Profissao(120, 414210, "Apontador de produção");
        [NotMapped] public static Profissao ApresentadorDeCirco => new Profissao(121, 376325, "Apresentador de circo");
        [NotMapped] public static Profissao ApresentadorDeEventos => new Profissao(122, 376305, "Apresentador de eventos");
        [NotMapped] public static Profissao ApresentadorDeFestasPopulares => new Profissao(123, 376310, "Apresentador de festas populares");
        [NotMapped] public static Profissao ApresentadorDeProgramasDeRadio => new Profissao(124, 376315, "Apresentador de programas de rádio");
        [NotMapped] public static Profissao ApresentadorDeProgramasDeTelevisao => new Profissao(125, 376320, "Apresentador de programas de televisão");
        [NotMapped] public static Profissao ArbitroDeAtletismo => new Profissao(126, 377210, "Árbitro de atletismo");
        [NotMapped] public static Profissao ArbitroDeBasquete => new Profissao(127, 377215, "Árbitro de basquete");
        [NotMapped] public static Profissao ArbitroDeFutebol => new Profissao(128, 377220, "Árbitro de futebol");
        [NotMapped] public static Profissao ArbitroDeFutebolDeSalao => new Profissao(129, 377225, "Árbitro de futebol de salão");
        [NotMapped] public static Profissao ArbitroDeJudo => new Profissao(130, 377230, "Árbitro de judô");
        [NotMapped] public static Profissao ArbitroDeKarate => new Profissao(131, 377235, "Árbitro de karatê");
        [NotMapped] public static Profissao ArbitroDePoloAquatico => new Profissao(132, 377240, "Árbitro de poló aquático");
        [NotMapped] public static Profissao ArbitroDeVolei => new Profissao(133, 377245, "Árbitro de vôlei");
        [NotMapped] public static Profissao ArbitroDesportivo => new Profissao(134, 377205, "Árbitro desportivo");
        [NotMapped] public static Profissao ArbitroExtrajudicial => new Profissao(135, 351440, "Árbitro extrajudicial");
        [NotMapped] public static Profissao ArmadorDeEstruturaDeConcreto => new Profissao(136, 715305, "Armador de estrutura de concreto");
        [NotMapped] public static Profissao ArmadorDeEstruturaDeConcretoArmado => new Profissao(137, 715315, "Armador de estrutura de concreto armado");
        [NotMapped] public static Profissao Armazenista => new Profissao(138, 414110, "Armazenista");
        [NotMapped] public static Profissao Aromista => new Profissao(139, 325010, "Aromista");
        [NotMapped] public static Profissao Arqueologo => new Profissao(140, 251110, "Arqueólogo");
        [NotMapped] public static Profissao ArquitetoDeEdificacoes => new Profissao(141, 214105, "Arquiteto de edificações");
        [NotMapped] public static Profissao ArquitetoDeInteriores => new Profissao(142, 214110, "Arquiteto de interiores");
        [NotMapped] public static Profissao ArquitetoDePatrimonio => new Profissao(143, 214115, "Arquiteto de patrimônio");
        [NotMapped] public static Profissao ArquitetoDeSolucoesDeTecnologiaDaInformacao => new Profissao(144, 212425, "Arquiteto de soluções de tecnologia da informação");
        [NotMapped] public static Profissao ArquitetoPaisagista => new Profissao(145, 214120, "Arquiteto paisagista");
        [NotMapped] public static Profissao ArquitetoUrbanista => new Profissao(146, 214125, "Arquiteto urbanista");
        [NotMapped] public static Profissao Arquivista => new Profissao(147, 261305, "Arquivista");
        [NotMapped] public static Profissao ArquivistaDeDocumentos => new Profissao(148, 415105, "Arquivista de documentos");
        [NotMapped] public static Profissao ArquivistaPesquisadorJornalismo => new Profissao(149, 261105, "Arquivista pesquisador (jornalismo)");
        [NotMapped] public static Profissao Arrematadeira => new Profissao(150, 763305, "Arrematadeira");
        [NotMapped] public static Profissao ArtesaoBordador => new Profissao(151, 791105, "Artesão bordador");
        [NotMapped] public static Profissao ArtesaoCeramista => new Profissao(152, 791110, "Artesão ceramista");
        [NotMapped] public static Profissao ArtesaoComMaterialReciclavel => new Profissao(153, 791115, "Artesão com material reciclável");
        [NotMapped] public static Profissao ArtesaoConfeccionadorDeBiojoiasEEcojoias => new Profissao(154, 791120, "Artesão confeccionador de biojóias e ecojóias");
        [NotMapped] public static Profissao ArtesaoCrocheteiro => new Profissao(155, 791150, "Artesão crocheteiro");
        [NotMapped] public static Profissao ArtesaoDoCouro => new Profissao(156, 791125, "Artesão do couro");
        [NotMapped] public static Profissao ArtesaoEscultor => new Profissao(157, 791130, "Artesão escultor");
        [NotMapped] public static Profissao ArtesaoModeladorVidros => new Profissao(158, 752105, "Artesão modelador (vidros)");
        [NotMapped] public static Profissao ArtesaoMoveleiroExcetoReciclado => new Profissao(159, 791135, "Artesão moveleiro (exceto reciclado)");
        [NotMapped] public static Profissao ArtesaoRendeiro => new Profissao(160, 791160, "Artesão rendeiro");
        [NotMapped] public static Profissao ArtesaoTecelao => new Profissao(161, 791140, "Artesão tecelão");
        [NotMapped] public static Profissao ArtesaoTrancador => new Profissao(162, 791145, "Artesão trançador");
        [NotMapped] public static Profissao ArtesaoTricoteiro => new Profissao(163, 791155, "Artesão tricoteiro");
        [NotMapped] public static Profissao Arteterapeuta => new Profissao(164, 226310, "Arteterapeuta");
        [NotMapped] public static Profissao ArtificeDoCouro => new Profissao(165, 768305, "Artífice do couro");
        [NotMapped] public static Profissao ArtistaArtesVisuais => new Profissao(166, 262405, "Artista (artes visuais)");
        [NotMapped] public static Profissao ArtistaAereo => new Profissao(167, 376210, "Artista aéreo");
        [NotMapped] public static Profissao ArtistaDeCircoOutros => new Profissao(168, 376215, "Artista de circo (outros)");
        [NotMapped] public static Profissao Ascensorista => new Profissao(169, 514105, "Ascensorista");
        [NotMapped] public static Profissao AssentadorDeCanalizacaoEdificacoes => new Profissao(170, 724105, "Assentador de canalização (edificações)");
        [NotMapped] public static Profissao AssentadorDeRevestimentosCeramicos => new Profissao(171, 716510, "Assentador de revestimentos cerâmicos");
        [NotMapped] public static Profissao AssessorDeImprensa => new Profissao(172, 261110, "Assessor de imprensa");
        [NotMapped] public static Profissao AssistenteAdministrativo => new Profissao(173, 411010, "Assistente administrativo");
        [NotMapped] public static Profissao AssistenteComercialDeSeguros => new Profissao(174, 351715, "Assistente comercial de seguros");
        [NotMapped] public static Profissao AssistenteDeCoreografia => new Profissao(175, 262805, "Assistente de coreografia");
        [NotMapped] public static Profissao AssistenteDeDirecaoTv => new Profissao(176, 261910, "Assistente de direção (tv)");
        [NotMapped] public static Profissao AssistenteDeLaboratorioIndustrial => new Profissao(177, 818105, "Assistente de laboratório industrial");
        [NotMapped] public static Profissao AssistenteDeOperacoesAudiovisuais => new Profissao(178, 373145, "Assistente de operações audiovisuais");
        [NotMapped] public static Profissao AssistenteDeVendas => new Profissao(179, 354125, "Assistente de vendas");
        [NotMapped] public static Profissao AssistenteSocial => new Profissao(180, 251605, "Assistente social");
        [NotMapped] public static Profissao AssistenteTecnicoDeSeguros => new Profissao(181, 351720, "Assistente técnico de seguros");
        [NotMapped] public static Profissao Assoalhador => new Profissao(182, 716505, "Assoalhador");
        [NotMapped] public static Profissao Astrologo => new Profissao(183, 516705, "Astrólogo");
        [NotMapped] public static Profissao Astronomo => new Profissao(184, 213305, "Astrônomo");
        [NotMapped] public static Profissao AtendenteComercialAgenciaPostal => new Profissao(185, 421105, "Atendente comercial (agência postal)");
        [NotMapped] public static Profissao AtendenteDeAgencia => new Profissao(186, 413205, "Atendente de agência");
        [NotMapped] public static Profissao AtendenteDeEnfermagem => new Profissao(187, 515110, "Atendente de enfermagem");
        [NotMapped] public static Profissao AtendenteDeFarmaciaBalconista => new Profissao(188, 521130, "Atendente de farmácia - balconista");
        [NotMapped] public static Profissao AtendenteDeJudiciario => new Profissao(189, 411015, "Atendente de judiciário");
        [NotMapped] public static Profissao AtendenteDeLanchonete => new Profissao(190, 513435, "Atendente de lanchonete");
        [NotMapped] public static Profissao AtendenteDeLavanderia => new Profissao(191, 516340, "Atendente de lavanderia");
        [NotMapped] public static Profissao AtendenteDeLojasEMercados => new Profissao(192, 521140, "Atendente de lojas e mercados");
        [NotMapped] public static Profissao AtletaProfissionalOutrasModalidades => new Profissao(193, 377105, "Atleta profissional (outras modalidades)");
        [NotMapped] public static Profissao AtletaProfissionalDeFutebol => new Profissao(194, 377110, "Atleta profissional de futebol");
        [NotMapped] public static Profissao AtletaProfissionalDeGolfe => new Profissao(195, 377115, "Atleta profissional de golfe");
        [NotMapped] public static Profissao AtletaProfissionalDeLuta => new Profissao(196, 377120, "Atleta profissional de luta");
        [NotMapped] public static Profissao AtletaProfissionalDeTenis => new Profissao(197, 377125, "Atleta profissional de tênis");
        [NotMapped] public static Profissao Ator => new Profissao(198, 262505, "Ator");
        [NotMapped] public static Profissao Atuario => new Profissao(199, 211105, "Atuário");
        [NotMapped] public static Profissao Audiodescritor => new Profissao(200, 261430, "Audiodescritor");
        [NotMapped] public static Profissao AuditorContadoresEAfins => new Profissao(201, 252205, "Auditor (contadores e afins)");
        [NotMapped] public static Profissao AuditorFiscalDaPrevidenciaSocial => new Profissao(202, 254205, "Auditor-fiscal da previdência social");
        [NotMapped] public static Profissao AuditorFiscalDaReceitaFederal => new Profissao(203, 254105, "Auditor-fiscal da receita federal");
        [NotMapped] public static Profissao AuditorFiscalDoTrabalho => new Profissao(204, 254305, "Auditor-fiscal do trabalho");
        [NotMapped] public static Profissao AutorRoteirista => new Profissao(205, 261505, "Autor-roteirista");
        [NotMapped] public static Profissao AuxiliarDeBancoDeSangue => new Profissao(206, 515205, "Auxiliar de banco de sangue");
        [NotMapped] public static Profissao AuxiliarDeBiblioteca => new Profissao(207, 371105, "Auxiliar de biblioteca");
        [NotMapped] public static Profissao AuxiliarDeCartorio => new Profissao(208, 411025, "Auxiliar de cartório");
        [NotMapped] public static Profissao AuxiliarDeContabilidade => new Profissao(209, 413110, "Auxiliar de contabilidade");
        [NotMapped] public static Profissao AuxiliarDeCortePreparacaoDaConfeccaoDeRoupas => new Profissao(210, 763105, "Auxiliar de corte (preparação da confecção de roupas)");
        [NotMapped] public static Profissao AuxiliarDeDesenvolvimentoInfantil => new Profissao(211, 331110, "Auxiliar de desenvolvimento infantil");
        [NotMapped] public static Profissao AuxiliarDeEnfermagem => new Profissao(212, 322230, "Auxiliar de enfermagem");
        [NotMapped] public static Profissao AuxiliarDeEnfermagemDaEstrategiaDeSaudeDaFamilia => new Profissao(213, 322250, "Auxiliar de enfermagem da estratégia de saúde da família");
        [NotMapped] public static Profissao AuxiliarDeEnfermagemDoTrabalho => new Profissao(214, 322235, "Auxiliar de enfermagem do trabalho");
        [NotMapped] public static Profissao AuxiliarDeEscritorio => new Profissao(215, 411005, "Auxiliar de escritório");
        [NotMapped] public static Profissao AuxiliarDeEstatistica => new Profissao(216, 411035, "Auxiliar de estatística");
        [NotMapped] public static Profissao AuxiliarDeFarmaciaDeManipulacao => new Profissao(217, 515210, "Auxiliar de farmácia de manipulação");
        [NotMapped] public static Profissao AuxiliarDeFaturamento => new Profissao(218, 413115, "Auxiliar de faturamento");
        [NotMapped] public static Profissao AuxiliarDeJudiciario => new Profissao(219, 411020, "Auxiliar de judiciário");
        [NotMapped] public static Profissao AuxiliarDeLaboratorioDeAnalisesClinicas => new Profissao(220, 515215, "Auxiliar de laboratório de análises clínicas");
        [NotMapped] public static Profissao AuxiliarDeLaboratorioDeAnalisesFisicoQuimicas => new Profissao(221, 818110, "Auxiliar de laboratório de análises físico-químicas");
        [NotMapped] public static Profissao AuxiliarDeLaboratorioDeImunobiologicos => new Profissao(222, 515220, "Auxiliar de laboratório de imunobiológicos");
        [NotMapped] public static Profissao AuxiliarDeLavanderia => new Profissao(223, 516345, "Auxiliar de lavanderia");
        [NotMapped] public static Profissao AuxiliarDeLogistica => new Profissao(224, 414140, "Auxiliar de logistica");
        [NotMapped] public static Profissao AuxiliarDeManutencaoPredial => new Profissao(225, 514310, "Auxiliar de manutenção predial");
        [NotMapped] public static Profissao AuxiliarDeMaquinistaDeTrem => new Profissao(226, 782625, "Auxiliar de maquinista de trem");
        [NotMapped] public static Profissao AuxiliarDePessoal => new Profissao(227, 411030, "Auxiliar de pessoal");
        [NotMapped] public static Profissao AuxiliarDeProcessamentoDeFumo => new Profissao(228, 842120, "Auxiliar de processamento de fumo");
        [NotMapped] public static Profissao AuxiliarDeProducaoFarmaceutica => new Profissao(229, 515225, "Auxiliar de produção farmacêutica");
        [NotMapped] public static Profissao AuxiliarDeProteseDentaria => new Profissao(230, 322420, "Auxiliar de prótese dentária");
        [NotMapped] public static Profissao AuxiliarDeRadiologiaRevelacaoFotografica => new Profissao(231, 766420, "Auxiliar de radiologia (revelação fotográfica)");
        [NotMapped] public static Profissao AuxiliarDeSaudeNavegacaoMaritima => new Profissao(232, 322240, "Auxiliar de saúde (navegação marítima)");
        [NotMapped] public static Profissao AuxiliarDeSeguros => new Profissao(233, 411040, "Auxiliar de seguros");
        [NotMapped] public static Profissao AuxiliarDeServicosDeImportacaoEExportacao => new Profissao(234, 411045, "Auxiliar de serviços de importação e exportação");
        [NotMapped] public static Profissao AuxiliarDeServicosJuridicos => new Profissao(235, 351430, "Auxiliar de serviços jurídicos");
        [NotMapped] public static Profissao AuxiliarDeVeterinario => new Profissao(236, 519305, "Auxiliar de veterinário");
        [NotMapped] public static Profissao AuxiliarEmSaudeBucal => new Profissao(237, 322415, "Auxiliar em saúde bucal");
        [NotMapped] public static Profissao AuxiliarEmSaudeBucalDaEstrategiaDeSaudeDaFamilia => new Profissao(238, 322430, "Auxiliar em saúde bucal da estratégia de saúde da família");
        [NotMapped] public static Profissao AuxiliarGeralDeConservacaoDeViasPermanentesExcetoTrilhos => new Profissao(239, 992225, "Auxiliar geral de conservação de vias permanentes (exceto trilhos)");
        [NotMapped] public static Profissao AuxiliarNosServicosDeAlimentacao => new Profissao(240, 513505, "Auxiliar nos serviços de alimentação");
        [NotMapped] public static Profissao AuxiliarTecnicoDeSinalizacaoNautica => new Profissao(241, 341250, "Auxiliar técnico de sinalização nautica");
        [NotMapped] public static Profissao AuxiliarTecnicoEmLaboratorioDeFarmacia => new Profissao(242, 325105, "Auxiliar técnico em laboratório de farmácia");
        [NotMapped] public static Profissao AvaliadorDeBensMoveis => new Profissao(243, 354415, "Avaliador de bens móveis");
        [NotMapped] public static Profissao AvaliadorDeImoveis => new Profissao(244, 354410, "Avaliador de imóveis");
        [NotMapped] public static Profissao AvaliadorDeProdutosDosMeiosDeComunicacao => new Profissao(245, 352410, "Avaliador de produtos dos meios de comunicação");
        [NotMapped] public static Profissao AvaliadorFisico => new Profissao(246, 224105, "Avaliador físico");
        [NotMapped] public static Profissao Avicultor => new Profissao(247, 613305, "Avicultor");
        [NotMapped] public static Profissao Baba => new Profissao(248, 516205, "Babá");
        [NotMapped] public static Profissao BaianaDeAcaraje => new Profissao(249, 524315, "Baiana de acarajé");
        [NotMapped] public static Profissao BailarinoExcetoDancasPopulares => new Profissao(250, 262810, "Bailarino (exceto danças populares)");
        [NotMapped] public static Profissao Balanceador => new Profissao(251, 992110, "Balanceador");
        [NotMapped] public static Profissao Balanceiro => new Profissao(252, 414115, "Balanceiro");
        [NotMapped] public static Profissao Bamburista => new Profissao(253, 811705, "Bamburista");
        [NotMapped] public static Profissao BanhistaDeAnimaisDomesticos => new Profissao(254, 519315, "Banhista de animais domésticos");
        [NotMapped] public static Profissao Barbeiro => new Profissao(255, 516105, "Barbeiro");
        [NotMapped] public static Profissao Barista => new Profissao(256, 513440, "Barista");
        [NotMapped] public static Profissao Barman => new Profissao(257, 513420, "Barman");
        [NotMapped] public static Profissao BateFolhaAMaquina => new Profissao(258, 751105, "Bate-folha a  máquina");
        [NotMapped] public static Profissao Bibliotecario => new Profissao(259, 261205, "Bibliotecário");
        [NotMapped] public static Profissao BilheteiroEstacoesDeMetroFerroviariasEAssemelhadas => new Profissao(260, 511220, "Bilheteiro (estações de metrô, ferroviárias e assemelhadas)");
        [NotMapped] public static Profissao BilheteiroDeTransportesColetivos => new Profissao(261, 421110, "Bilheteiro de transportes coletivos");
        [NotMapped] public static Profissao BilheteiroNoServicoDeDiversoes => new Profissao(262, 421115, "Bilheteiro no serviço de diversões");
        [NotMapped] public static Profissao Bioengenheiro => new Profissao(263, 201105, "Bioengenheiro");
        [NotMapped] public static Profissao Biologo => new Profissao(264, 221105, "Biólogo");
        [NotMapped] public static Profissao Biomedico => new Profissao(265, 221205, "Biomédico");
        [NotMapped] public static Profissao Biotecnologista => new Profissao(266, 201110, "Biotecnologista");
        [NotMapped] public static Profissao BloqueiroTrabalhadorPortuario => new Profissao(267, 783230, "Bloqueiro (trabalhador portuário)");
        [NotMapped] public static Profissao BobinadorEletricistaAMao => new Profissao(268, 731165, "Bobinador eletricista, à mão");
        [NotMapped] public static Profissao BobinadorEletricistaAMaquina => new Profissao(269, 731170, "Bobinador eletricista, à máquina");
        [NotMapped] public static Profissao Boiadeiro => new Profissao(270, 782815, "Boiadeiro");
        [NotMapped] public static Profissao BombeiroCivil => new Profissao(271, 517110, "Bombeiro civil");
        [NotMapped] public static Profissao BombeiroDeAerodromo => new Profissao(272, 517105, "Bombeiro de aeródromo");
        [NotMapped] public static Profissao Boneleiro => new Profissao(273, 765015, "Boneleiro");
        [NotMapped] public static Profissao BordadorAMao => new Profissao(274, 768205, "Bordador, a  mão");
        [NotMapped] public static Profissao BordadorAMaquina => new Profissao(275, 763310, "Bordador, à máquina");
        [NotMapped] public static Profissao Borracheiro => new Profissao(276, 992115, "Borracheiro");
        [NotMapped] public static Profissao Brasador => new Profissao(277, 724305, "Brasador");
        [NotMapped] public static Profissao BrigadistaFlorestal => new Profissao(278, 517120, "Brigadista florestal");
        [NotMapped] public static Profissao Cabeleireiro => new Profissao(279, 516110, "Cabeleireiro");
        [NotMapped] public static Profissao Cableador => new Profissao(280, 722405, "Cableador");
        [NotMapped] public static Profissao CaboBombeiroMilitar => new Profissao(281, 31205, "Cabo bombeiro militar");
        [NotMapped] public static Profissao CaboDaPoliciaMilitar => new Profissao(282, 21205, "Cabo da polícia militar");
        [NotMapped] public static Profissao Cacique => new Profissao(283, 113005, "Cacique");
        [NotMapped] public static Profissao Cafeicultor => new Profissao(284, 612605, "Cafeicultor");
        [NotMapped] public static Profissao CaixaDeBanco => new Profissao(285, 413210, "Caixa de banco");
        [NotMapped] public static Profissao Calafetador => new Profissao(286, 716605, "Calafetador");
        [NotMapped] public static Profissao CalandristaDeBorracha => new Profissao(287, 811710, "Calandrista de borracha");
        [NotMapped] public static Profissao CalandristaDePapel => new Profissao(288, 832105, "Calandrista de papel");
        [NotMapped] public static Profissao Calceteiro => new Profissao(289, 715205, "Calceteiro");
        [NotMapped] public static Profissao CaldeireiroChapasDeCobre => new Profissao(290, 724405, "Caldeireiro (chapas de cobre)");
        [NotMapped] public static Profissao CaldeireiroChapasDeFerroEAco => new Profissao(291, 724410, "Caldeireiro (chapas de ferro e aço)");
        [NotMapped] public static Profissao CamareiroDeHotel => new Profissao(292, 513315, "Camareiro  de hotel");
        [NotMapped] public static Profissao CamareiroDeEmbarcacoes => new Profissao(293, 513320, "Camareiro de embarcações");
        [NotMapped] public static Profissao CamareiroDeTeatro => new Profissao(294, 513305, "Camareiro de teatro");
        [NotMapped] public static Profissao CamareiroDeTelevisao => new Profissao(295, 513310, "Camareiro de televisão");
        [NotMapped] public static Profissao CaminhoneiroAutonomoRotasRegionaisEInternacionais => new Profissao(296, 782505, "Caminhoneiro autônomo (rotas regionais e internacionais)");
        [NotMapped] public static Profissao Canteiro => new Profissao(297, 711110, "Canteiro");
        [NotMapped] public static Profissao CapitaoBombeiroMilitar => new Profissao(298, 30205, "Capitão bombeiro militar");
        [NotMapped] public static Profissao CapitaoDaPoliciaMilitar => new Profissao(299, 20205, "Capitão da polícia militar");
        [NotMapped] public static Profissao CapitaoDeManobraDaMarinhaMercante => new Profissao(300, 215110, "Capitão de manobra da marinha mercante");
        [NotMapped] public static Profissao CaptadorDeRecursos => new Profissao(301, 411055, "Captador de recursos");
        [NotMapped] public static Profissao Carbonizador => new Profissao(302, 632610, "Carbonizador");
        [NotMapped] public static Profissao Carpinteiro => new Profissao(303, 715505, "Carpinteiro");
        [NotMapped] public static Profissao CarpinteiroCenarios => new Profissao(304, 715515, "Carpinteiro (cenários)");
        [NotMapped] public static Profissao CarpinteiroEsquadrias => new Profissao(305, 715510, "Carpinteiro (esquadrias)");
        [NotMapped] public static Profissao CarpinteiroMineracao => new Profissao(306, 715520, "Carpinteiro (mineração)");
        [NotMapped] public static Profissao CarpinteiroTelhados => new Profissao(307, 715530, "Carpinteiro (telhados)");
        [NotMapped] public static Profissao CarpinteiroDeCarretas => new Profissao(308, 777205, "Carpinteiro de carretas");
        [NotMapped] public static Profissao CarpinteiroDeCarrocerias => new Profissao(309, 777210, "Carpinteiro de carrocerias");
        [NotMapped] public static Profissao CarpinteiroDeFormasParaConcreto => new Profissao(310, 715535, "Carpinteiro de fôrmas para concreto");
        [NotMapped] public static Profissao CarpinteiroDeObras => new Profissao(311, 715525, "Carpinteiro de obras");
        [NotMapped] public static Profissao CarpinteiroDeObrasCivisDeArtePontesTuneisBarragens => new Profissao(312, 715540, "Carpinteiro de obras civis de arte (pontes, túneis, barragens)");
        [NotMapped] public static Profissao CarpinteiroNavalConstrucaoDePequenasEmbarcacoes => new Profissao(313, 777105, "Carpinteiro naval (construção de pequenas embarcações)");
        [NotMapped] public static Profissao CarpinteiroNavalEmbarcacoes => new Profissao(314, 777110, "Carpinteiro naval (embarcações)");
        [NotMapped] public static Profissao CarpinteiroNavalEstaleiros => new Profissao(315, 777115, "Carpinteiro naval (estaleiros)");
        [NotMapped] public static Profissao CarregadorAeronaves => new Profissao(316, 783205, "Carregador (aeronaves)");
        [NotMapped] public static Profissao CarregadorArmazem => new Profissao(317, 783210, "Carregador (armazém)");
        [NotMapped] public static Profissao CarregadorVeiculosDeTransportesTerrestres => new Profissao(318, 783215, "Carregador (veículos de transportes terrestres)");
        [NotMapped] public static Profissao Cartazeiro => new Profissao(319, 519905, "Cartazeiro");
        [NotMapped] public static Profissao Carteiro => new Profissao(320, 415205, "Carteiro");
        [NotMapped] public static Profissao CartonageiroAMaoCaixasDePapelao => new Profissao(321, 833205, "Cartonageiro, a mão (caixas de papelão)");
        [NotMapped] public static Profissao CartonageiroAMaquina => new Profissao(322, 833105, "Cartonageiro, a máquina");
        [NotMapped] public static Profissao Carvoeiro => new Profissao(323, 632605, "Carvoeiro");
        [NotMapped] public static Profissao CaseiroAgricultura => new Profissao(324, 622005, "Caseiro (agricultura)");
        [NotMapped] public static Profissao CasqueadorDeAnimais => new Profissao(325, 623025, "Casqueador de animais");
        [NotMapped] public static Profissao CatadorDeCaranguejosESiris => new Profissao(326, 631005, "Catador de caranguejos e siris");
        [NotMapped] public static Profissao CatadorDeMariscos => new Profissao(327, 631010, "Catador de mariscos");
        [NotMapped] public static Profissao CatadorDeMaterialReciclavel => new Profissao(328, 519205, "Catador de material reciclável");
        [NotMapped] public static Profissao CelofanistaNaFabricacaoDeCharutos => new Profissao(329, 842225, "Celofanista na fabricação de charutos");
        [NotMapped] public static Profissao CementadorDeMetais => new Profissao(330, 723105, "Cementador de metais");
        [NotMapped] public static Profissao CenografoCarnavalescoEFestasPopulares => new Profissao(331, 262305, "Cenógrafo carnavalesco e festas populares");
        [NotMapped] public static Profissao CenografoDeCinema => new Profissao(332, 262310, "Cenógrafo de cinema");
        [NotMapped] public static Profissao CenografoDeEventos => new Profissao(333, 262315, "Cenógrafo de eventos");
        [NotMapped] public static Profissao CenografoDeTeatro => new Profissao(334, 262320, "Cenógrafo de teatro");
        [NotMapped] public static Profissao CenografoDeTv => new Profissao(335, 262325, "Cenógrafo de tv");
        [NotMapped] public static Profissao CenotecnicoCinemaVideoTelevisaoTeatroEEspetaculos => new Profissao(336, 374205, "Cenotécnico (cinema, vídeo, televisão, teatro e espetáculos)");
        [NotMapped] public static Profissao Ceramista => new Profissao(337, 752305, "Ceramista");
        [NotMapped] public static Profissao CeramistaTornoDePedalEMotor => new Profissao(338, 752310, "Ceramista (torno de pedal e motor)");
        [NotMapped] public static Profissao CeramistaTornoSemiAutomatico => new Profissao(339, 752315, "Ceramista (torno semi-automático)");
        [NotMapped] public static Profissao CeramistaModelador => new Profissao(340, 752320, "Ceramista modelador");
        [NotMapped] public static Profissao CeramistaMoldador => new Profissao(341, 752325, "Ceramista moldador");
        [NotMapped] public static Profissao CeramistaPrensador => new Profissao(342, 752330, "Ceramista prensador");
        [NotMapped] public static Profissao Cerimonialista => new Profissao(343, 354825, "Cerimonialista");
        [NotMapped] public static Profissao Cerzidor => new Profissao(344, 768210, "Cerzidor");
        [NotMapped] public static Profissao Cesteiro => new Profissao(345, 776405, "Cesteiro");
        [NotMapped] public static Profissao Chapeador => new Profissao(346, 724415, "Chapeador");
        [NotMapped] public static Profissao ChapeadorDeAeronaves => new Profissao(347, 724430, "Chapeador de aeronaves");
        [NotMapped] public static Profissao ChapeadorDeCarroceriasMetalicasFabricacao => new Profissao(348, 724420, "Chapeador de carrocerias metálicas (fabricação)");
        [NotMapped] public static Profissao ChapeadorNaval => new Profissao(349, 724425, "Chapeador naval");
        [NotMapped] public static Profissao ChapeleiroChapeusDePalha => new Profissao(350, 768125, "Chapeleiro (chapéus de palha)");
        [NotMapped] public static Profissao ChapeleiroDeSenhoras => new Profissao(351, 765010, "Chapeleiro de senhoras");
        [NotMapped] public static Profissao CharuteiroAMao => new Profissao(352, 842230, "Charuteiro a mão");
        [NotMapped] public static Profissao Chaveiro => new Profissao(353, 523115, "Chaveiro");
        [NotMapped] public static Profissao ChefeDeBar => new Profissao(354, 510130, "Chefe de bar");
        [NotMapped] public static Profissao ChefeDeBrigada => new Profissao(355, 517125, "Chefe de brigada");
        [NotMapped] public static Profissao ChefeDeConfeitaria => new Profissao(356, 840120, "Chefe de confeitaria");
        [NotMapped] public static Profissao ChefeDeContabilidadeTecnico => new Profissao(357, 351110, "Chefe de contabilidade (técnico)");
        [NotMapped] public static Profissao ChefeDeCozinha => new Profissao(358, 271105, "Chefe de cozinha");
        [NotMapped] public static Profissao ChefeDeEstacaoPortuaria => new Profissao(359, 342605, "Chefe de estação portuária");
        [NotMapped] public static Profissao ChefeDePortariaDeHotel => new Profissao(360, 510120, "Chefe de portaria de hotel");
        [NotMapped] public static Profissao ChefeDeServicoDeTransporteRodoviarioPassageirosECargas => new Profissao(361, 342305, "Chefe de serviço de transporte rodoviário (passageiros e cargas)");
        [NotMapped] public static Profissao ChefeDeServicosBancarios => new Profissao(362, 353235, "Chefe de serviços bancários");
        [NotMapped] public static Profissao Churrasqueiro => new Profissao(363, 513605, "Churrasqueiro");
        [NotMapped] public static Profissao CiclistaMensageiro => new Profissao(364, 519105, "Ciclista mensageiro");
        [NotMapped] public static Profissao CientistaPolitico => new Profissao(365, 251115, "Cientista político");
        [NotMapped] public static Profissao CilindreiroNaPreparacaoDePastaParaFabricacaoDePapel => new Profissao(366, 831105, "Cilindreiro na preparação de pasta para fabricação de papel");
        [NotMapped] public static Profissao CilindristaPetroquimicaEAfins => new Profissao(367, 813105, "Cilindrista (petroquímica e afins)");
        [NotMapped] public static Profissao CimentadorPocosDePetroleo => new Profissao(368, 316340, "Cimentador (poços de petróleo)");
        [NotMapped] public static Profissao CirurgiaoDentistaAuditor => new Profissao(369, 223204, "Cirurgião dentista - auditor");
        [NotMapped] public static Profissao CirurgiaoDentistaClinicoGeral => new Profissao(370, 223208, "Cirurgião dentista - clínico geral");
        [NotMapped] public static Profissao CirurgiaoDentistaDentistica => new Profissao(371, 223280, "Cirurgião dentista - dentística");
        [NotMapped] public static Profissao CirurgiaoDentistaDisfuncaoTemporomandibularEDorOrofacial => new Profissao(372, 223284, "Cirurgião dentista - disfunção temporomandibular e dor orofacial");
        [NotMapped] public static Profissao CirurgiaoDentistaEndodontista => new Profissao(373, 223212, "Cirurgião dentista - endodontista");
        [NotMapped] public static Profissao CirurgiaoDentistaEpidemiologista => new Profissao(374, 223216, "Cirurgião dentista - epidemiologista");
        [NotMapped] public static Profissao CirurgiaoDentistaEstomatologista => new Profissao(375, 223220, "Cirurgião dentista - estomatologista");
        [NotMapped] public static Profissao CirurgiaoDentistaImplantodontista => new Profissao(376, 223224, "Cirurgião dentista - implantodontista");
        [NotMapped] public static Profissao CirurgiaoDentistaOdontogeriatra => new Profissao(377, 223228, "Cirurgião dentista - odontogeriatra");
        [NotMapped] public static Profissao CirurgiaoDentistaOdontologiaDoTrabalho => new Profissao(378, 223276, "Cirurgião dentista - odontologia do trabalho");
        [NotMapped] public static Profissao CirurgiaoDentistaOdontologiaParaPacientesComNecessidadesEspeciais => new Profissao(379, 223288, "Cirurgião dentista - odontologia para pacientes com necessidades especiais");
        [NotMapped] public static Profissao CirurgiaoDentistaOdontologistaLegal => new Profissao(380, 223232, "Cirurgião dentista - odontologista legal");
        [NotMapped] public static Profissao CirurgiaoDentistaOdontopediatra => new Profissao(381, 223236, "Cirurgião dentista - odontopediatra");
        [NotMapped] public static Profissao CirurgiaoDentistaOrtopedistaEOrtodontista => new Profissao(382, 223240, "Cirurgião dentista - ortopedista e ortodontista");
        [NotMapped] public static Profissao CirurgiaoDentistaPatologistaBucal => new Profissao(383, 223244, "Cirurgião dentista - patologista bucal");
        [NotMapped] public static Profissao CirurgiaoDentistaPeriodontista => new Profissao(384, 223248, "Cirurgião dentista - periodontista");
        [NotMapped] public static Profissao CirurgiaoDentistaProtesiologoBucomaxilofacial => new Profissao(385, 223252, "Cirurgião dentista - protesiólogo bucomaxilofacial");
        [NotMapped] public static Profissao CirurgiaoDentistaProtesista => new Profissao(386, 223256, "Cirurgião dentista - protesista");
        [NotMapped] public static Profissao CirurgiaoDentistaRadiologista => new Profissao(387, 223260, "Cirurgião dentista - radiologista");
        [NotMapped] public static Profissao CirurgiaoDentistaReabilitadorOral => new Profissao(388, 223264, "Cirurgião dentista - reabilitador oral");
        [NotMapped] public static Profissao CirurgiaoDentistaTraumatologistaBucomaxilofacial => new Profissao(389, 223268, "Cirurgião dentista - traumatologista bucomaxilofacial");
        [NotMapped] public static Profissao CirurgiaoDentistaDeSaudeColetiva => new Profissao(390, 223272, "Cirurgião dentista de saúde coletiva");
        [NotMapped] public static Profissao CirurgiaoDentistaDaEstrategiaDeSaudeDaFamilia => new Profissao(391, 223293, "Cirurgião-dentista da estratégia de saúde da família");
        [NotMapped] public static Profissao Citotecnico => new Profissao(392, 324215, "Citotécnico");
        [NotMapped] public static Profissao ClassificadorDeCharutos => new Profissao(393, 842215, "Classificador de charutos");
        [NotMapped] public static Profissao ClassificadorDeCouros => new Profissao(394, 762210, "Classificador de couros");
        [NotMapped] public static Profissao ClassificadorDeFibrasTexteis => new Profissao(395, 761105, "Classificador de fibras têxteis");
        [NotMapped] public static Profissao ClassificadorDeFumo => new Profissao(396, 842115, "Classificador de fumo");
        [NotMapped] public static Profissao ClassificadorDeGraos => new Profissao(397, 848425, "Classificador de grãos");
        [NotMapped] public static Profissao ClassificadorDeMadeira => new Profissao(398, 772105, "Classificador de madeira");
        [NotMapped] public static Profissao ClassificadorDePeles => new Profissao(399, 762105, "Classificador de peles");
        [NotMapped] public static Profissao ClassificadorDeToras => new Profissao(400, 632105, "Classificador de toras");
        [NotMapped] public static Profissao ClassificadorEEmpilhadorDeTijolosRefratarios => new Profissao(401, 823305, "Classificador e empilhador de tijolos refratários");
        [NotMapped] public static Profissao CobradorDeTransportesColetivosExcetoTrem => new Profissao(402, 511215, "Cobrador de transportes coletivos (exceto trem)");
        [NotMapped] public static Profissao CobradorExterno => new Profissao(403, 421305, "Cobrador externo");
        [NotMapped] public static Profissao CobradorInterno => new Profissao(404, 421310, "Cobrador interno");
        [NotMapped] public static Profissao CodificadorDeDados => new Profissao(405, 415115, "Codificador de dados");
        [NotMapped] public static Profissao ColchoeiroConfeccaoDeColchoes => new Profissao(406, 765205, "Colchoeiro (confecção de colchões)");
        [NotMapped] public static Profissao ColecionadorDeSelosEMoedas => new Profissao(407, 371205, "Colecionador de selos e moedas");
        [NotMapped] public static Profissao ColetorDeLixoDomiciliar => new Profissao(408, 514205, "Coletor de lixo domiciliar");
        [NotMapped] public static Profissao ColetorDeResiduosSolidosDeServicosDeSaude => new Profissao(409, 514230, "Coletor de resíduos sólidos de serviços de saúde");
        [NotMapped] public static Profissao ColoristaDePapel => new Profissao(410, 311705, "Colorista de papel");
        [NotMapped] public static Profissao ColoristaTextil => new Profissao(411, 311710, "Colorista têxtil");
        [NotMapped] public static Profissao ComandanteDaMarinhaMercante => new Profissao(412, 215115, "Comandante da marinha mercante");
        [NotMapped] public static Profissao ComentaristaDeMidiasAudiovisuais => new Profissao(413, 261710, "Comentarista de mídias audiovisuais");
        [NotMapped] public static Profissao ComercianteAtacadista => new Profissao(414, 141405, "Comerciante atacadista");
        [NotMapped] public static Profissao ComercianteVarejista => new Profissao(415, 141410, "Comerciante varejista");
        [NotMapped] public static Profissao ComissarioDeTrem => new Profissao(416, 511110, "Comissário de trem");
        [NotMapped] public static Profissao ComissarioDeVoo => new Profissao(417, 511105, "Comissário de vôo");
        [NotMapped] public static Profissao CompensadorDeBanco => new Profissao(418, 413215, "Compensador de banco");
        [NotMapped] public static Profissao Compositor => new Profissao(419, 262605, "Compositor");
        [NotMapped] public static Profissao Comprador => new Profissao(420, 354205, "Comprador");
        [NotMapped] public static Profissao Concierge => new Profissao(421, 422130, "Concierge");
        [NotMapped] public static Profissao CondutorDeAmbulancia => new Profissao(422, 782320, "Condutor de ambulância");
        [NotMapped] public static Profissao CondutorDeMaquinas => new Profissao(423, 341310, "Condutor de máquinas");
        [NotMapped] public static Profissao CondutorDeMaquinasBombeador => new Profissao(424, 341320, "Condutor de máquinas (bombeador)");
        [NotMapped] public static Profissao CondutorDeMaquinasMecanico => new Profissao(425, 341325, "Condutor de máquinas (mecânico)");
        [NotMapped] public static Profissao CondutorDeProcessosRobotizadosDePintura => new Profissao(426, 781105, "Condutor de processos robotizados de pintura");
        [NotMapped] public static Profissao CondutorDeProcessosRobotizadosDeSoldagem => new Profissao(427, 781110, "Condutor de processos robotizados de soldagem");
        [NotMapped] public static Profissao CondutorDeTurismoDeAventura => new Profissao(428, 511505, "Condutor de turismo de aventura");
        [NotMapped] public static Profissao CondutorDeTurismoDePesca => new Profissao(429, 511510, "Condutor de turismo de pesca");
        [NotMapped] public static Profissao CondutorDeVeiculosAPedais => new Profissao(430, 782820, "Condutor de veículos a pedais");
        [NotMapped] public static Profissao CondutorDeVeiculosDeTracaoAnimalRuasEEstradas => new Profissao(431, 782805, "Condutor de veículos de tração animal (ruas e estradas)");
        [NotMapped] public static Profissao CondutorMaquinistaMotoristaFluvial => new Profissao(432, 341305, "Condutor maquinista motorista fluvial");
        [NotMapped] public static Profissao ConfeccionadorDeAcordeao => new Profissao(433, 742110, "Confeccionador de acordeão");
        [NotMapped] public static Profissao ConfeccionadorDeArtefatosDeCouroExcetoSapatos => new Profissao(434, 765005, "Confeccionador de artefatos de couro (exceto sapatos)");
        [NotMapped] public static Profissao ConfeccionadorDeBolsasSacosESacolasEPapelAMaquina => new Profissao(435, 833110, "Confeccionador de bolsas, sacos e sacolas e papel, a máquina");
        [NotMapped] public static Profissao ConfeccionadorDeBrinquedosDePano => new Profissao(436, 765215, "Confeccionador de brinquedos de pano");
        [NotMapped] public static Profissao ConfeccionadorDeCarimbosDeBorracha => new Profissao(437, 768630, "Confeccionador de carimbos de borracha");
        [NotMapped] public static Profissao ConfeccionadorDeEscovasPinceisEProdutosSimilaresAMao => new Profissao(438, 776410, "Confeccionador de escovas, pincéis e produtos similares (a mão)");
        [NotMapped] public static Profissao ConfeccionadorDeEscovasPinceisEProdutosSimilaresAMaquina => new Profissao(439, 776415, "Confeccionador de escovas, pincéis e produtos similares (a máquina)");
        [NotMapped] public static Profissao ConfeccionadorDeInstrumentosDeCorda => new Profissao(440, 742115, "Confeccionador de instrumentos de corda");
        [NotMapped] public static Profissao ConfeccionadorDeInstrumentosDePercussaoPeleCouroOuPlastico => new Profissao(441, 742120, "Confeccionador de instrumentos de percussão (pele, couro ou plástico)");
        [NotMapped] public static Profissao ConfeccionadorDeInstrumentosDeSoproMadeira => new Profissao(442, 742125, "Confeccionador de instrumentos de sopro (madeira)");
        [NotMapped] public static Profissao ConfeccionadorDeInstrumentosDeSoproMetal => new Profissao(443, 742130, "Confeccionador de instrumentos de sopro (metal)");
        [NotMapped] public static Profissao ConfeccionadorDeMoveisDeVimeJuncoEBambu => new Profissao(444, 776420, "Confeccionador de móveis de vime, junco e bambu");
        [NotMapped] public static Profissao ConfeccionadorDeOrgao => new Profissao(445, 742135, "Confeccionador de órgão");
        [NotMapped] public static Profissao ConfeccionadorDePiano => new Profissao(446, 742140, "Confeccionador de piano");
        [NotMapped] public static Profissao ConfeccionadorDePneumaticos => new Profissao(447, 811715, "Confeccionador de pneumáticos");
        [NotMapped] public static Profissao ConfeccionadorDeSacosDeCelofaneAMaquina => new Profissao(448, 833115, "Confeccionador de sacos de celofane, a máquina");
        [NotMapped] public static Profissao ConfeccionadorDeVelasNauticasBarracasEToldos => new Profissao(449, 765225, "Confeccionador de velas náuticas, barracas e toldos");
        [NotMapped] public static Profissao ConfeccionadorDeVelasPorImersao => new Profissao(450, 811725, "Confeccionador de velas por imersão");
        [NotMapped] public static Profissao ConfeccionadorDeVelasPorMoldagem => new Profissao(451, 811735, "Confeccionador de velas por moldagem");
        [NotMapped] public static Profissao Confeiteiro => new Profissao(452, 848310, "Confeiteiro");
        [NotMapped] public static Profissao ConferenteDeCargaEDescarga => new Profissao(453, 414215, "Conferente de carga e descarga");
        [NotMapped] public static Profissao ConferenteDeServicosBancarios => new Profissao(454, 413220, "Conferente de serviços bancários");
        [NotMapped] public static Profissao ConferenteMercadoriaExcetoCargaEDescarga => new Profissao(455, 414120, "Conferente mercadoria (exceto carga e descarga)");
        [NotMapped] public static Profissao ConferenteExpedidorDeRoupasLavanderias => new Profissao(456, 516335, "Conferente-expedidor de roupas (lavanderias)");
        [NotMapped] public static Profissao ConselheiroJulgador => new Profissao(457, 241405, "Conselheiro julgador");
        [NotMapped] public static Profissao ConselheiroTutelar => new Profissao(458, 515320, "Conselheiro tutelar");
        [NotMapped] public static Profissao ConservadorDeViaPermanenteTrilhos => new Profissao(459, 991105, "Conservador de via permanente (trilhos)");
        [NotMapped] public static Profissao ConservadorRestauradorDeBensCulturais => new Profissao(460, 262415, "Conservador-restaurador de bens  culturais");
        [NotMapped] public static Profissao ConsultorContabilTecnico => new Profissao(461, 351115, "Consultor contábil (técnico)");
        [NotMapped] public static Profissao ConsultorJuridico => new Profissao(462, 241040, "Consultor jurídico");
        [NotMapped] public static Profissao Contador => new Profissao(463, 252210, "Contador");
        [NotMapped] public static Profissao Continuista => new Profissao(464, 261905, "Continuista");
        [NotMapped] public static Profissao Continuo => new Profissao(465, 412205, "Contínuo");
        [NotMapped] public static Profissao Contorcionista => new Profissao(466, 376220, "Contorcionista");
        [NotMapped] public static Profissao ContramestreDeAcabamentoIndustriaTextil => new Profissao(467, 760105, "Contramestre de acabamento (indústria têxtil)");
        [NotMapped] public static Profissao ContramestreDeCabotagem => new Profissao(468, 341205, "Contramestre de cabotagem");
        [NotMapped] public static Profissao ContramestreDeFiacaoIndustriaTextil => new Profissao(469, 760110, "Contramestre de fiação (indústria têxtil)");
        [NotMapped] public static Profissao ContramestreDeMalhariaIndustriaTextil => new Profissao(470, 760115, "Contramestre de malharia (indústria têxtil)");
        [NotMapped] public static Profissao ContramestreDeTecelagemIndustriaTextil => new Profissao(471, 760120, "Contramestre de tecelagem (indústria têxtil)");
        [NotMapped] public static Profissao ControladorDeEntradaESaida => new Profissao(472, 391115, "Controlador de entrada e saída");
        [NotMapped] public static Profissao ControladorDePragas => new Profissao(473, 519910, "Controlador de pragas");
        [NotMapped] public static Profissao ControladorDeServicosDeMaquinasEVeiculos => new Profissao(474, 342115, "Controlador de serviços de máquinas e veículos");
        [NotMapped] public static Profissao ControladorDeTrafegoAereo => new Profissao(475, 342505, "Controlador de tráfego aéreo");
        [NotMapped] public static Profissao CoordenadorDeOperacoesDeCombateAPoluicaoNoMeioAquaviario => new Profissao(476, 215120, "Coordenador de operações de combate à poluição no meio aquaviário");
        [NotMapped] public static Profissao CoordenadorDeProgramacao => new Profissao(477, 373140, "Coordenador de programação");
        [NotMapped] public static Profissao CoordenadorDeProvasConcursoAvaliacaoExame => new Profissao(478, 424205, "Coordenador de provas (concurso, avaliação, exame)");
        [NotMapped] public static Profissao CoordenadorPedagogico => new Profissao(479, 239405, "Coordenador pedagógico");
        [NotMapped] public static Profissao Copeiro => new Profissao(480, 513425, "Copeiro");
        [NotMapped] public static Profissao CopeiroDeHospital => new Profissao(481, 513430, "Copeiro de hospital");
        [NotMapped] public static Profissao CopiadorDeChapa => new Profissao(482, 766105, "Copiador de chapa");
        [NotMapped] public static Profissao Coreografo => new Profissao(483, 262815, "Coreógrafo");
        [NotMapped] public static Profissao CoronelBombeiroMilitar => new Profissao(484, 30105, "Coronel bombeiro militar");
        [NotMapped] public static Profissao CoronelDaPoliciaMilitar => new Profissao(485, 20105, "Coronel da polícia militar");
        [NotMapped] public static Profissao CorretorDeGraos => new Profissao(486, 354610, "Corretor de grãos");
        [NotMapped] public static Profissao CorretorDeImoveis => new Profissao(487, 354605, "Corretor de imóveis");
        [NotMapped] public static Profissao CorretorDeSeguros => new Profissao(488, 354505, "Corretor de seguros");
        [NotMapped] public static Profissao CorretorDeValoresAtivosFinanceirosMercadoriasEDerivativos => new Profissao(489, 253305, "Corretor de valores, ativos financeiros, mercadorias e derivativos");
        [NotMapped] public static Profissao CortadorDeArtefatosDeCouroExcetoRoupasECalcados => new Profissao(490, 765105, "Cortador de artefatos de couro (exceto roupas e calçados)");
        [NotMapped] public static Profissao CortadorDeCalcadosAMaoExcetoSolas => new Profissao(491, 768310, "Cortador de calçados, a  mão (exceto solas)");
        [NotMapped] public static Profissao CortadorDeCalcadosAMaquinaExcetoSolasEPalmilhas => new Profissao(492, 764105, "Cortador de calçados, a  máquina (exceto solas e palmilhas)");
        [NotMapped] public static Profissao CortadorDeCharutos => new Profissao(493, 842220, "Cortador de charutos");
        [NotMapped] public static Profissao CortadorDeLaminadosDeMadeira => new Profissao(494, 773105, "Cortador de laminados de madeira");
        [NotMapped] public static Profissao CortadorDePedras => new Profissao(495, 712205, "Cortador de pedras");
        [NotMapped] public static Profissao CortadorDeRoupas => new Profissao(496, 763110, "Cortador de roupas");
        [NotMapped] public static Profissao CortadorDeSolasEPalmilhasAMaquina => new Profissao(497, 764110, "Cortador de solas e palmilhas, a  máquina");
        [NotMapped] public static Profissao CortadorDeTapecaria => new Profissao(498, 765110, "Cortador de tapeçaria");
        [NotMapped] public static Profissao CortadorDeVidro => new Profissao(499, 752210, "Cortador de vidro");
        [NotMapped] public static Profissao CosturadorDeArtefatosDeCouroAMaoExcetoRoupasECalcados => new Profissao(500, 768315, "Costurador de artefatos de couro, a  mão (exceto roupas e calçados)");
        [NotMapped] public static Profissao CosturadorDeArtefatosDeCouroAMaquinaExcetoRoupasECalcados => new Profissao(501, 765310, "Costurador de artefatos de couro, a  máquina (exceto roupas e calçados)");
        [NotMapped] public static Profissao CosturadorDeCalcadosAMaquina => new Profissao(502, 764205, "Costurador de calçados, a  máquina");
        [NotMapped] public static Profissao CostureiraDePecasSobEncomenda => new Profissao(503, 763010, "Costureira de peças sob encomenda");
        [NotMapped] public static Profissao CostureiraDeReparacaoDeRoupas => new Profissao(504, 763015, "Costureira de reparação de roupas");
        [NotMapped] public static Profissao CostureiroDeRoupaDeCouroEPele => new Profissao(505, 763020, "Costureiro de roupa de couro e pele");
        [NotMapped] public static Profissao CostureiroDeRoupasDeCouroEPeleAMaquinaNaConfeccaoEmSerie => new Profissao(506, 763205, "Costureiro de roupas de couro e pele, a  máquina na  confecção em série");
        [NotMapped] public static Profissao CostureiroNaConfeccaoEmSerie => new Profissao(507, 763210, "Costureiro na confecção em série");
        [NotMapped] public static Profissao CostureiroAMaquinaNaConfeccaoEmSerie => new Profissao(508, 763215, "Costureiro, a  máquina  na confecção em série");
        [NotMapped] public static Profissao CozinhadorConservacaoDeAlimentos => new Profissao(509, 841408, "Cozinhador (conservação de alimentos)");
        [NotMapped] public static Profissao CozinhadorDeCarnes => new Profissao(510, 841416, "Cozinhador de carnes");
        [NotMapped] public static Profissao CozinhadorDeFrutasELegumes => new Profissao(511, 841420, "Cozinhador de frutas e legumes");
        [NotMapped] public static Profissao CozinhadorDeMalte => new Profissao(512, 841730, "Cozinhador de malte");
        [NotMapped] public static Profissao CozinhadorDePescado => new Profissao(513, 841428, "Cozinhador de pescado");
        [NotMapped] public static Profissao CozinheiroDeEmbarcacoes => new Profissao(514, 513225, "Cozinheiro de embarcações");
        [NotMapped] public static Profissao CozinheiroDeHospital => new Profissao(515, 513220, "Cozinheiro de hospital");
        [NotMapped] public static Profissao CozinheiroDoServicoDomestico => new Profissao(516, 513210, "Cozinheiro do serviço doméstico");
        [NotMapped] public static Profissao CozinheiroGeral => new Profissao(517, 513205, "Cozinheiro geral");
        [NotMapped] public static Profissao CozinheiroIndustrial => new Profissao(518, 513215, "Cozinheiro industrial");
        [NotMapped] public static Profissao CriadorDeAnimaisDomesticos => new Profissao(519, 613010, "Criador de animais domésticos");
        [NotMapped] public static Profissao CriadorDeAnimaisProdutoresDeVeneno => new Profissao(520, 613410, "Criador de animais produtores de veneno");
        [NotMapped] public static Profissao CriadorDeAsininosEMuares => new Profissao(521, 613105, "Criador de asininos e muares");
        [NotMapped] public static Profissao CriadorDeBovinosCorte => new Profissao(522, 613110, "Criador de bovinos (corte)");
        [NotMapped] public static Profissao CriadorDeBovinosLeite => new Profissao(523, 613115, "Criador de bovinos (leite)");
        [NotMapped] public static Profissao CriadorDeBubalinosCorte => new Profissao(524, 613120, "Criador de bubalinos (corte)");
        [NotMapped] public static Profissao CriadorDeBubalinosLeite => new Profissao(525, 613125, "Criador de bubalinos (leite)");
        [NotMapped] public static Profissao CriadorDeCamaroes => new Profissao(526, 631305, "Criador de camarões");
        [NotMapped] public static Profissao CriadorDeCaprinos => new Profissao(527, 613205, "Criador de caprinos");
        [NotMapped] public static Profissao CriadorDeEquinos => new Profissao(528, 613130, "Criador de eqüínos");
        [NotMapped] public static Profissao CriadorDeJacares => new Profissao(529, 631310, "Criador de jacarés");
        [NotMapped] public static Profissao CriadorDeMexilhoes => new Profissao(530, 631315, "Criador de mexilhões");
        [NotMapped] public static Profissao CriadorDeOstras => new Profissao(531, 631320, "Criador de ostras");
        [NotMapped] public static Profissao CriadorDeOvinos => new Profissao(532, 613210, "Criador de ovinos");
        [NotMapped] public static Profissao CriadorDePeixes => new Profissao(533, 631325, "Criador de peixes");
        [NotMapped] public static Profissao CriadorDeQuelonios => new Profissao(534, 631330, "Criador de quelônios");
        [NotMapped] public static Profissao CriadorDeRas => new Profissao(535, 631335, "Criador de rãs");
        [NotMapped] public static Profissao CriadorDeSuinos => new Profissao(536, 613215, "Criador de suínos");
        [NotMapped] public static Profissao CriadorEmPecuariaPolivalente => new Profissao(537, 613005, "Criador em pecuária polivalente");
        [NotMapped] public static Profissao Critico => new Profissao(538, 261510, "Crítico");
        [NotMapped] public static Profissao CrocheteiroAMao => new Profissao(539, 768130, "Crocheteiro, a  mão");
        [NotMapped] public static Profissao Cronoanalista => new Profissao(540, 391105, "Cronoanalista");
        [NotMapped] public static Profissao Cronometrista => new Profissao(541, 391110, "Cronometrista");
        [NotMapped] public static Profissao CubadorDeMadeira => new Profissao(542, 632110, "Cubador de madeira");
        [NotMapped] public static Profissao CuidadorDeIdosos => new Profissao(543, 516210, "Cuidador de idosos");
        [NotMapped] public static Profissao CuidadorEmSaude => new Profissao(544, 516220, "Cuidador em saúde");
        [NotMapped] public static Profissao Cumim => new Profissao(545, 513415, "Cumim");
        [NotMapped] public static Profissao Cunicultor => new Profissao(546, 613310, "Cunicultor");
        [NotMapped] public static Profissao CurtidorCourosEPeles => new Profissao(547, 762205, "Curtidor (couros e peles)");
        [NotMapped] public static Profissao DancarinoPopular => new Profissao(548, 376110, "Dançarino popular");
        [NotMapped] public static Profissao DancarinoTradicional => new Profissao(549, 376105, "Dançarino tradicional");
        [NotMapped] public static Profissao Datilografo => new Profissao(550, 412105, "Datilógrafo");
        [NotMapped] public static Profissao Decapador => new Profissao(551, 723205, "Decapador");
        [NotMapped] public static Profissao DecoradorDeCeramica => new Profissao(552, 752405, "Decorador de cerâmica");
        [NotMapped] public static Profissao DecoradorDeEventos => new Profissao(553, 375120, "Decorador de eventos");
        [NotMapped] public static Profissao DecoradorDeInterioresDeNivelSuperior => new Profissao(554, 262905, "Decorador de interiores de nível superior");
        [NotMapped] public static Profissao DecoradorDeVidro => new Profissao(555, 752410, "Decorador de vidro");
        [NotMapped] public static Profissao DecoradorDeVidroAPincel => new Profissao(556, 752415, "Decorador de vidro à pincel");
        [NotMapped] public static Profissao DefensorPublico => new Profissao(557, 242405, "Defensor público");
        [NotMapped] public static Profissao DefumadorDeCarnesEPescados => new Profissao(558, 848105, "Defumador de carnes e pescados");
        [NotMapped] public static Profissao DegustadorDeCafe => new Profissao(559, 848405, "Degustador de café");
        [NotMapped] public static Profissao DegustadorDeCha => new Profissao(560, 848410, "Degustador de chá");
        [NotMapped] public static Profissao DegustadorDeCharutos => new Profissao(561, 842235, "Degustador de charutos");
        [NotMapped] public static Profissao DegustadorDeDerivadosDeCacau => new Profissao(562, 848415, "Degustador de derivados de cacau");
        [NotMapped] public static Profissao DegustadorDeVinhosOuLicores => new Profissao(563, 848420, "Degustador de vinhos ou licores");
        [NotMapped] public static Profissao DelegadoDePolicia => new Profissao(564, 242305, "Delegado de polícia");
        [NotMapped] public static Profissao DemolidorDeEdificacoes => new Profissao(565, 717005, "Demolidor de edificações");
        [NotMapped] public static Profissao DemonstradorDeMercadorias => new Profissao(566, 521120, "Demonstrador de mercadorias");
        [NotMapped] public static Profissao DeputadoEstadualEDistrital => new Profissao(567, 111115, "Deputado estadual e distrital");
        [NotMapped] public static Profissao DeputadoFederal => new Profissao(568, 111110, "Deputado federal");
        [NotMapped] public static Profissao DescarnadorDeCourosEPelesAMaquina => new Profissao(569, 762110, "Descarnador de couros e peles, à maquina");
        [NotMapped] public static Profissao DesenhistaCopista => new Profissao(570, 318010, "Desenhista copista");
        [NotMapped] public static Profissao DesenhistaDetalhista => new Profissao(571, 318015, "Desenhista detalhista");
        [NotMapped] public static Profissao DesenhistaIndustrialDeProdutoDesignerDeProduto => new Profissao(572, 262420, "Desenhista industrial de produto (designer de produto)");
        [NotMapped] public static Profissao DesenhistaIndustrialDeProdutoDeModaDesignerDeModa => new Profissao(573, 262425, "Desenhista industrial de produto de moda (designer de moda)");
        [NotMapped] public static Profissao DesenhistaIndustrialGraficoDesignerGrafico => new Profissao(574, 262410, "Desenhista industrial gráfico (designer gráfico)");
        [NotMapped] public static Profissao DesenhistaProjetistaDeArquitetura => new Profissao(575, 318505, "Desenhista projetista de arquitetura");
        [NotMapped] public static Profissao DesenhistaProjetistaDeConstrucaoCivil => new Profissao(576, 318510, "Desenhista projetista de construção civil");
        [NotMapped] public static Profissao DesenhistaProjetistaDeEletricidade => new Profissao(577, 318705, "Desenhista projetista de eletricidade");
        [NotMapped] public static Profissao DesenhistaProjetistaDeMaquinas => new Profissao(578, 318605, "Desenhista projetista de máquinas");
        [NotMapped] public static Profissao DesenhistaProjetistaEletronico => new Profissao(579, 318710, "Desenhista projetista eletrônico");
        [NotMapped] public static Profissao DesenhistaProjetistaMecanico => new Profissao(580, 318610, "Desenhista projetista mecânico");
        [NotMapped] public static Profissao DesenhistaTecnico => new Profissao(581, 318005, "Desenhista técnico");
        [NotMapped] public static Profissao DesenhistaTecnicoArquitetura => new Profissao(582, 318105, "Desenhista técnico (arquitetura)");
        [NotMapped] public static Profissao DesenhistaTecnicoArtesGraficas => new Profissao(583, 318405, "Desenhista técnico (artes gráficas)");
        [NotMapped] public static Profissao DesenhistaTecnicoCalefacaoVentilacaoERefrigeracao => new Profissao(584, 318310, "Desenhista técnico (calefação, ventilação e refrigeração)");
        [NotMapped] public static Profissao DesenhistaTecnicoCartografia => new Profissao(585, 318110, "Desenhista técnico (cartografia)");
        [NotMapped] public static Profissao DesenhistaTecnicoConstrucaoCivil => new Profissao(586, 318115, "Desenhista técnico (construção civil)");
        [NotMapped] public static Profissao DesenhistaTecnicoEletricidadeEEletronica => new Profissao(587, 318305, "Desenhista técnico (eletricidade e eletrônica)");
        [NotMapped] public static Profissao DesenhistaTecnicoIlustracoesArtisticas => new Profissao(588, 318410, "Desenhista técnico (ilustrações artísticas)");
        [NotMapped] public static Profissao DesenhistaTecnicoIlustracoesTecnicas => new Profissao(589, 318415, "Desenhista técnico (ilustrações técnicas)");
        [NotMapped] public static Profissao DesenhistaTecnicoIndustriaTextil => new Profissao(590, 318420, "Desenhista técnico (indústria têxtil)");
        [NotMapped] public static Profissao DesenhistaTecnicoInstalacoesHidrossanitarias => new Profissao(591, 318120, "Desenhista técnico (instalações hidrossanitárias)");
        [NotMapped] public static Profissao DesenhistaTecnicoMobiliario => new Profissao(592, 318425, "Desenhista técnico (mobiliário)");
        [NotMapped] public static Profissao DesenhistaTecnicoAeronautico => new Profissao(593, 318210, "Desenhista técnico aeronáutico");
        [NotMapped] public static Profissao DesenhistaTecnicoDeEmbalagensMaquetesELeiautes => new Profissao(594, 318430, "Desenhista técnico de embalagens, maquetes e leiautes");
        [NotMapped] public static Profissao DesenhistaTecnicoMecanico => new Profissao(595, 318205, "Desenhista técnico mecânico");
        [NotMapped] public static Profissao DesenhistaTecnicoNaval => new Profissao(596, 318215, "Desenhista técnico naval");
        [NotMapped] public static Profissao DesenvolvedorDeMultimidia => new Profissao(597, 317120, "Desenvolvedor de multimídia");
        [NotMapped] public static Profissao DesenvolvedorDeSistemasDeTecnologiaDaInformacaoTecnico => new Profissao(598, 317110, "Desenvolvedor de sistemas de tecnologia da informação (técnico)");
        [NotMapped] public static Profissao DesenvolvedorWebTecnico => new Profissao(599, 317105, "Desenvolvedor web (técnico)");
        [NotMapped] public static Profissao DesidratadorDeAlimentos => new Profissao(600, 841432, "Desidratador de alimentos");
        [NotMapped] public static Profissao DesignerDeInteriores => new Profissao(601, 375105, "Designer de interiores");
        [NotMapped] public static Profissao DesignerDeVitrines => new Profissao(602, 375110, "Designer de vitrines");
        [NotMapped] public static Profissao DesignerEducacional => new Profissao(603, 239435, "Designer educacional");
        [NotMapped] public static Profissao DesincrustadorPocosDePetroleo => new Profissao(604, 316335, "Desincrustador (poços de petróleo)");
        [NotMapped] public static Profissao Desossador => new Profissao(605, 848515, "Desossador");
        [NotMapped] public static Profissao DespachanteAduaneiro => new Profissao(606, 342210, "Despachante aduaneiro");
        [NotMapped] public static Profissao DespachanteDeTransito => new Profissao(607, 423110, "Despachante de trânsito");
        [NotMapped] public static Profissao DespachanteDeTransportesColetivosExcetoTrem => new Profissao(608, 511210, "Despachante de transportes coletivos (exceto trem)");
        [NotMapped] public static Profissao DespachanteDocumentalista => new Profissao(609, 423105, "Despachante documentalista");
        [NotMapped] public static Profissao DespachanteOperacionalDeVoo => new Profissao(610, 342510, "Despachante operacional de vôo");
        [NotMapped] public static Profissao DessecadorDeMalte => new Profissao(611, 841735, "Dessecador de malte");
        [NotMapped] public static Profissao DestiladorDeMadeira => new Profissao(612, 811405, "Destilador de madeira");
        [NotMapped] public static Profissao DestiladorDeProdutosQuimicosExcetoPetroleo => new Profissao(613, 811410, "Destilador de produtos químicos (exceto petróleo)");
        [NotMapped] public static Profissao DestrocadorDePedra => new Profissao(614, 711115, "Destroçador de pedra");
        [NotMapped] public static Profissao DetetiveProfissional => new Profissao(615, 351805, "Detetive profissional");
        [NotMapped] public static Profissao Detonador => new Profissao(616, 711120, "Detonador");
        [NotMapped] public static Profissao Dietista => new Profissao(617, 223705, "Dietista");
        [NotMapped] public static Profissao Digitador => new Profissao(618, 412110, "Digitador");
        [NotMapped] public static Profissao DiretorAdministrativo => new Profissao(619, 123105, "Diretor administrativo");
        [NotMapped] public static Profissao DiretorAdministrativoEFinanceiro => new Profissao(620, 123110, "Diretor administrativo e financeiro");
        [NotMapped] public static Profissao DiretorArtistico => new Profissao(621, 262235, "Diretor artistíco");
        [NotMapped] public static Profissao DiretorComercial => new Profissao(622, 123305, "Diretor comercial");
        [NotMapped] public static Profissao DiretorComercialEmOperacoesDeIntermediacaoFinanceira => new Profissao(623, 122705, "Diretor comercial em operações de intermediação financeira");
        [NotMapped] public static Profissao DiretorDeProducaoEOperacoesDeAlimentacao => new Profissao(624, 122505, "Diretor de  produção e operações de alimentação");
        [NotMapped] public static Profissao DiretorDeProducaoEOperacoesDeHotel => new Profissao(625, 122510, "Diretor de  produção e operações de hotel");
        [NotMapped] public static Profissao DiretorDeProducaoEOperacoesDeTurismo => new Profissao(626, 122515, "Diretor de  produção e operações de turismo");
        [NotMapped] public static Profissao DiretorDeArte => new Profissao(627, 262330, "Diretor de arte");
        [NotMapped] public static Profissao DiretorDeArtePublicidade => new Profissao(628, 253125, "Diretor de arte (publicidade)");
        [NotMapped] public static Profissao DiretorDeCambioEComercioExterior => new Profissao(629, 122720, "Diretor de câmbio e comércio exterior");
        [NotMapped] public static Profissao DiretorDeCinema => new Profissao(630, 262205, "Diretor de cinema");
        [NotMapped] public static Profissao DiretorDeCompliance => new Profissao(631, 122725, "Diretor de compliance");
        [NotMapped] public static Profissao DiretorDeContasPublicidade => new Profissao(632, 253135, "Diretor de contas (publicidade)");
        [NotMapped] public static Profissao DiretorDeCreditoExcetoCreditoImobiliario => new Profissao(633, 122730, "Diretor de crédito (exceto crédito imobiliário)");
        [NotMapped] public static Profissao DiretorDeCreditoImobiliario => new Profissao(634, 122735, "Diretor de crédito imobiliário");
        [NotMapped] public static Profissao DiretorDeCreditoRural => new Profissao(635, 122715, "Diretor de crédito rural");
        [NotMapped] public static Profissao DiretorDeCriacao => new Profissao(636, 253130, "Diretor de criação");
        [NotMapped] public static Profissao DiretorDeFotografia => new Profissao(637, 372105, "Diretor de fotografia");
        [NotMapped] public static Profissao DiretorDeImagensTv => new Profissao(638, 374425, "Diretor de imagens (tv)");
        [NotMapped] public static Profissao DiretorDeInstituicaoEducacionalDaAreaPrivada => new Profissao(639, 131305, "Diretor de instituição educacional da área privada");
        [NotMapped] public static Profissao DiretorDeInstituicaoEducacionalPublica => new Profissao(640, 131310, "Diretor de instituição educacional pública");
        [NotMapped] public static Profissao DiretorDeLeasing => new Profissao(641, 122740, "Diretor de leasing");
        [NotMapped] public static Profissao DiretorDeManutencao => new Profissao(642, 123805, "Diretor de manutenção");
        [NotMapped] public static Profissao DiretorDeMarketing => new Profissao(643, 123310, "Diretor de marketing");
        [NotMapped] public static Profissao DiretorDeMercadoDeCapitais => new Profissao(644, 122745, "Diretor de mercado de capitais");
        [NotMapped] public static Profissao DiretorDeMidiaPublicidade => new Profissao(645, 253120, "Diretor de mídia (publicidade)");
        [NotMapped] public static Profissao DiretorDeOperacoesComerciaisComercioAtacadistaEVarejista => new Profissao(646, 122405, "Diretor de operações comerciais (comércio atacadista e varejista)");
        [NotMapped] public static Profissao DiretorDeOperacoesDeCorreios => new Profissao(647, 122605, "Diretor de operações de correios");
        [NotMapped] public static Profissao DiretorDeOperacoesDeObrasPublicaECivil => new Profissao(648, 122305, "Diretor de operações de obras pública e civil");
        [NotMapped] public static Profissao DiretorDeOperacoesDeServicosDeArmazenamento => new Profissao(649, 122610, "Diretor de operações de serviços de armazenamento");
        [NotMapped] public static Profissao DiretorDeOperacoesDeServicosDeTelecomunicacoes => new Profissao(650, 122615, "Diretor de operações de serviços de telecomunicações");
        [NotMapped] public static Profissao DiretorDeOperacoesDeServicosDeTransporte => new Profissao(651, 122620, "Diretor de operações de serviços de transporte");
        [NotMapped] public static Profissao DiretorDePesquisaEDesenvolvimentoPD => new Profissao(652, 123705, "Diretor de pesquisa e desenvolvimento (p&d)");
        [NotMapped] public static Profissao DiretorDePlanejamentoEstrategico => new Profissao(653, 121005, "Diretor de planejamento estratégico");
        [NotMapped] public static Profissao DiretorDeProducao => new Profissao(654, 262230, "Diretor de produção");
        [NotMapped] public static Profissao DiretorDeProducaoEOperacoesDaIndustriaDeTransformacaoExtracaoMineralEUtilidades => new Profissao(655, 122205, "Diretor de produção e operações da indústria de transformação, extração mineral e utilidades");
        [NotMapped] public static Profissao DiretorDeProducaoEOperacoesEmEmpresaAgropecuaria => new Profissao(656, 122105, "Diretor de produção e operações em empresa agropecuária");
        [NotMapped] public static Profissao DiretorDeProducaoEOperacoesEmEmpresaAquicola => new Profissao(657, 122110, "Diretor de produção e operações em empresa aqüícola");
        [NotMapped] public static Profissao DiretorDeProducaoEOperacoesEmEmpresaFlorestal => new Profissao(658, 122115, "Diretor de produção e operações em empresa florestal");
        [NotMapped] public static Profissao DiretorDeProducaoEOperacoesEmEmpresaPesqueira => new Profissao(659, 122120, "Diretor de produção e operações em empresa pesqueira");
        [NotMapped] public static Profissao DiretorDeProdutosBancarios => new Profissao(660, 122710, "Diretor de produtos bancários");
        [NotMapped] public static Profissao DiretorDeProgramacao => new Profissao(661, 262225, "Diretor de programação");
        [NotMapped] public static Profissao DiretorDeProgramasDeRadio => new Profissao(662, 262210, "Diretor de programas de rádio");
        [NotMapped] public static Profissao DiretorDeProgramasDeTelevisao => new Profissao(663, 262215, "Diretor de programas de televisão");
        [NotMapped] public static Profissao DiretorDeRecuperacaoDeCreditosEmOperacoesDeIntermediacaoFinanceira => new Profissao(664, 122750, "Diretor de recuperação de créditos em operações de intermediação financeira");
        [NotMapped] public static Profissao DiretorDeRecursosHumanos => new Profissao(665, 123205, "Diretor de recursos humanos");
        [NotMapped] public static Profissao DiretorDeRedacao => new Profissao(666, 261115, "Diretor de redação");
        [NotMapped] public static Profissao DiretorDeRelacoesDeTrabalho => new Profissao(667, 123210, "Diretor de relações de trabalho");
        [NotMapped] public static Profissao DiretorDeRiscosDeMercado => new Profissao(668, 122755, "Diretor de riscos de mercado");
        [NotMapped] public static Profissao DiretorDeServicosCulturais => new Profissao(669, 131105, "Diretor de serviços culturais");
        [NotMapped] public static Profissao DiretorDeServicosDeSaude => new Profissao(670, 131205, "Diretor de serviços de saúde");
        [NotMapped] public static Profissao DiretorDeServicosSociais => new Profissao(671, 131110, "Diretor de serviços sociais");
        [NotMapped] public static Profissao DiretorDeSuprimentos => new Profissao(672, 123405, "Diretor de suprimentos");
        [NotMapped] public static Profissao DiretorDeSuprimentosNoServicoPublico => new Profissao(673, 123410, "Diretor de suprimentos no serviço público");
        [NotMapped] public static Profissao DiretorDeTecnologiaDaInformacao => new Profissao(674, 123605, "Diretor de tecnologia da informação");
        [NotMapped] public static Profissao DiretorFinanceiro => new Profissao(675, 123115, "Diretor financeiro");
        [NotMapped] public static Profissao DiretorGeralDeEmpresaEOrganizacoesExcetoDeInteressePublico => new Profissao(676, 121010, "Diretor geral de empresa e organizações (exceto de interesse público)");
        [NotMapped] public static Profissao DiretorTeatral => new Profissao(677, 262220, "Diretor teatral");
        [NotMapped] public static Profissao DirigenteDePartidoPolitico => new Profissao(678, 114105, "Dirigente de partido político");
        [NotMapped] public static Profissao DirigenteDoServicoPublicoEstadualEDistrital => new Profissao(679, 111410, "Dirigente do serviço público estadual e distrital");
        [NotMapped] public static Profissao DirigenteDoServicoPublicoFederal => new Profissao(680, 111405, "Dirigente do serviço público federal");
        [NotMapped] public static Profissao DirigenteDoServicoPublicoMunicipal => new Profissao(681, 111415, "Dirigente do serviço público municipal");
        [NotMapped] public static Profissao DirigenteEAdministradorDeOrganizacaoDaSociedadeCivilSemFinsLucrativos => new Profissao(682, 114405, "Dirigente e administrador de organização da sociedade civil sem fins lucrativos");
        [NotMapped] public static Profissao DirigenteEAdministradorDeOrganizacaoReligiosa => new Profissao(683, 114305, "Dirigente e administrador de organização religiosa");
        [NotMapped] public static Profissao DirigentesDeEntidadesDeTrabalhadores => new Profissao(684, 114205, "Dirigentes de entidades de trabalhadores");
        [NotMapped] public static Profissao DirigentesDeEntidadesPatronais => new Profissao(685, 114210, "Dirigentes de entidades patronais");
        [NotMapped] public static Profissao DjDiscJockey => new Profissao(686, 374145, "Dj (disc jockey)");
        [NotMapped] public static Profissao Documentalista => new Profissao(687, 261210, "Documentalista");
        [NotMapped] public static Profissao DomadorDeAnimaisCircense => new Profissao(688, 376225, "Domador de animais (circense)");
        [NotMapped] public static Profissao Doula => new Profissao(689, 322135, "Doula");
        [NotMapped] public static Profissao DrageadorMedicamentos => new Profissao(690, 811810, "Drageador (medicamentos)");
        [NotMapped] public static Profissao DramaturgoDeDanca => new Profissao(691, 262820, "Dramaturgo de dança");
        [NotMapped] public static Profissao Economista => new Profissao(692, 251205, "Economista");
        [NotMapped] public static Profissao EconomistaAgroindustrial => new Profissao(693, 251210, "Economista agroindustrial");
        [NotMapped] public static Profissao EconomistaAmbiental => new Profissao(694, 251230, "Economista ambiental");
        [NotMapped] public static Profissao EconomistaDoSetorPublico => new Profissao(695, 251225, "Economista do setor público");
        [NotMapped] public static Profissao EconomistaDomestico => new Profissao(696, 251610, "Economista doméstico");
        [NotMapped] public static Profissao EconomistaFinanceiro => new Profissao(697, 251215, "Economista financeiro");
        [NotMapped] public static Profissao EconomistaIndustrial => new Profissao(698, 251220, "Economista industrial");
        [NotMapped] public static Profissao EconomistaRegionalEUrbano => new Profissao(699, 251235, "Economista regional e urbano");
        [NotMapped] public static Profissao Editor => new Profissao(700, 261120, "Editor");
        [NotMapped] public static Profissao EditorDeJornal => new Profissao(701, 261605, "Editor de jornal");
        [NotMapped] public static Profissao EditorDeLivro => new Profissao(702, 261610, "Editor de livro");
        [NotMapped] public static Profissao EditorDeMidiaAudiovisual => new Profissao(703, 374405, "Editor de mídia audiovisual");
        [NotMapped] public static Profissao EditorDeMidiaEletronica => new Profissao(704, 261615, "Editor de mídia eletrônica");
        [NotMapped] public static Profissao EditorDeRevista => new Profissao(705, 261620, "Editor de revista");
        [NotMapped] public static Profissao EditorDeRevistaCientifica => new Profissao(706, 261625, "Editor de revista científica");
        [NotMapped] public static Profissao EditorDeTextoEImagem => new Profissao(707, 766120, "Editor de texto e imagem");
        [NotMapped] public static Profissao EducadorSocial => new Profissao(708, 515305, "Educador social");
        [NotMapped] public static Profissao EletricistaDeBordo => new Profissao(709, 341315, "Eletricista de bordo");
        [NotMapped] public static Profissao EletricistaDeInstalacoes => new Profissao(710, 715615, "Eletricista de instalações");
        [NotMapped] public static Profissao EletricistaDeInstalacoesAeronaves => new Profissao(711, 953105, "Eletricista de instalações (aeronaves)");
        [NotMapped] public static Profissao EletricistaDeInstalacoesCenarios => new Profissao(712, 715605, "Eletricista de instalações (cenários)");
        [NotMapped] public static Profissao EletricistaDeInstalacoesEdificios => new Profissao(713, 715610, "Eletricista de instalações (edifícios)");
        [NotMapped] public static Profissao EletricistaDeInstalacoesEmbarcacoes => new Profissao(714, 953110, "Eletricista de instalações (embarcações)");
        [NotMapped] public static Profissao EletricistaDeInstalacoesVeiculosAutomotoresEMaquinasOperatrizesExcetoAeronavesEEmbarcacoes => new Profissao(715, 953115, "Eletricista de instalações (veículos automotores e máquinas operatrizes, exceto aeronaves e embarcações)");
        [NotMapped] public static Profissao EletricistaDeManutencaoDeLinhasEletricasTelefonicasEDeComunicacaoDeDados => new Profissao(716, 732105, "Eletricista de manutenção de linhas elétricas, telefônicas e de comunicação de dados");
        [NotMapped] public static Profissao EletricistaDeManutencaoEletroeletronica => new Profissao(717, 951105, "Eletricista de manutenção eletroeletrônica");
        [NotMapped] public static Profissao EletromecanicoDeManutencaoDeElevadores => new Profissao(718, 954105, "Eletromecânico de manutenção de elevadores");
        [NotMapped] public static Profissao EletromecanicoDeManutencaoDeEscadasRolantes => new Profissao(719, 954110, "Eletromecânico de manutenção de escadas rolantes");
        [NotMapped] public static Profissao EletromecanicoDeManutencaoDePortasAutomaticas => new Profissao(720, 954115, "Eletromecânico de manutenção de portas automáticas");
        [NotMapped] public static Profissao Eletrotecnico => new Profissao(721, 313105, "Eletrotécnico");
        [NotMapped] public static Profissao EletrotecnicoProducaoDeEnergia => new Profissao(722, 313110, "Eletrotécnico (produção de energia)");
        [NotMapped] public static Profissao EletrotecnicoNaFabricacaoMontagemEInstalacaoDeMaquinasEEquipamentos => new Profissao(723, 313115, "Eletrotécnico na fabricação, montagem e instalação de máquinas e equipamentos");
        [NotMapped] public static Profissao EmbaladorAMao => new Profissao(724, 784105, "Embalador, a mão");
        [NotMapped] public static Profissao EmbaladorAMaquina => new Profissao(725, 784110, "Embalador, a máquina");
        [NotMapped] public static Profissao Embalsamador => new Profissao(726, 328105, "Embalsamador");
        [NotMapped] public static Profissao EmendadorDeCabosEletricosETelefonicosAereosESubterraneos => new Profissao(727, 732110, "Emendador de cabos elétricos e telefônicos (aéreos e subterrâneos)");
        [NotMapped] public static Profissao EmissorDePassagens => new Profissao(728, 421120, "Emissor de passagens");
        [NotMapped] public static Profissao EmpregadoDomesticoNosServicosGerais => new Profissao(729, 512105, "Empregado  doméstico  nos serviços gerais");
        [NotMapped] public static Profissao EmpregadoDomesticoArrumador => new Profissao(730, 512110, "Empregado doméstico  arrumador");
        [NotMapped] public static Profissao EmpregadoDomesticoFaxineiro => new Profissao(731, 512115, "Empregado doméstico  faxineiro");
        [NotMapped] public static Profissao EmpregadoDomesticoDiarista => new Profissao(732, 512120, "Empregado doméstico diarista");
        [NotMapped] public static Profissao Encanador => new Profissao(733, 724110, "Encanador");
        [NotMapped] public static Profissao EncarregadoDeAcabamentoDeChapasEMetaisTempera => new Profissao(734, 821405, "Encarregado de acabamento de chapas e metais  (têmpera)");
        [NotMapped] public static Profissao EncarregadoDeCorteNaConfeccaoDoVestuario => new Profissao(735, 760305, "Encarregado de corte na confecção do vestuário");
        [NotMapped] public static Profissao EncarregadoDeCosturaNaConfeccaoDoVestuario => new Profissao(736, 760310, "Encarregado de costura na confecção do vestuário");
        [NotMapped] public static Profissao EncarregadoDeEquipeDeConservacaoDeViasPermanentesExcetoTrilhos => new Profissao(737, 992210, "Encarregado de equipe de conservação de vias permanentes (exceto trilhos)");
        [NotMapped] public static Profissao EncarregadoDeManutencaoDeInstrumentosDeControleMedicaoESimilares => new Profissao(738, 313415, "Encarregado de manutenção de instrumentos de controle, medição e similares");
        [NotMapped] public static Profissao EncarregadoDeManutencaoEletricaDeVeiculos => new Profissao(739, 950205, "Encarregado de manutenção elétrica de veículos");
        [NotMapped] public static Profissao EncarregadoDeManutencaoMecanicaDeSistemasOperacionais => new Profissao(740, 910105, "Encarregado de manutenção mecânica de sistemas operacionais");
        [NotMapped] public static Profissao EncarregadoGeralDeOperacoesDeConservacaoDeViasPermanentesExcetoTrilhos => new Profissao(741, 992205, "Encarregado geral de operações de conservação de vias permanentes (exceto trilhos)");
        [NotMapped] public static Profissao Enfermeiro => new Profissao(742, 223505, "Enfermeiro");
        [NotMapped] public static Profissao EnfermeiroAuditor => new Profissao(743, 223510, "Enfermeiro auditor");
        [NotMapped] public static Profissao EnfermeiroDaEstrategiaDeSaudeDaFamilia => new Profissao(744, 223565, "Enfermeiro da estratégia de saúde da família");
        [NotMapped] public static Profissao EnfermeiroDeBordo => new Profissao(745, 223515, "Enfermeiro de bordo");
        [NotMapped] public static Profissao EnfermeiroDeCentroCirurgico => new Profissao(746, 223520, "Enfermeiro de centro cirúrgico");
        [NotMapped] public static Profissao EnfermeiroDeTerapiaIntensiva => new Profissao(747, 223525, "Enfermeiro de terapia intensiva");
        [NotMapped] public static Profissao EnfermeiroDoTrabalho => new Profissao(748, 223530, "Enfermeiro do trabalho");
        [NotMapped] public static Profissao EnfermeiroNefrologista => new Profissao(749, 223535, "Enfermeiro nefrologista");
        [NotMapped] public static Profissao EnfermeiroNeonatologista => new Profissao(750, 223540, "Enfermeiro neonatologista");
        [NotMapped] public static Profissao EnfermeiroObstetrico => new Profissao(751, 223545, "Enfermeiro obstétrico");
        [NotMapped] public static Profissao EnfermeiroPsiquiatrico => new Profissao(752, 223550, "Enfermeiro psiquiátrico");
        [NotMapped] public static Profissao EnfermeiroPuericultorEPediatrico => new Profissao(753, 223555, "Enfermeiro puericultor e pediátrico");
        [NotMapped] public static Profissao EnfermeiroSanitarista => new Profissao(754, 223560, "Enfermeiro sanitarista");
        [NotMapped] public static Profissao EnfestadorDeRoupas => new Profissao(755, 763115, "Enfestador de roupas");
        [NotMapped] public static Profissao EngastadorJoias => new Profissao(756, 751005, "Engastador (jóias)");
        [NotMapped] public static Profissao EngenheiroAeronautico => new Profissao(757, 214425, "Engenheiro aeronáutico");
        [NotMapped] public static Profissao EngenheiroAgricola => new Profissao(758, 222105, "Engenheiro agrícola");
        [NotMapped] public static Profissao EngenheiroAgrimensor => new Profissao(759, 214805, "Engenheiro agrimensor");
        [NotMapped] public static Profissao EngenheiroAgronomo => new Profissao(760, 222110, "Engenheiro agrônomo");
        [NotMapped] public static Profissao EngenheiroAmbiental => new Profissao(761, 214005, "Engenheiro ambiental");
        [NotMapped] public static Profissao EngenheiroCartografo => new Profissao(762, 214810, "Engenheiro cartógrafo");
        [NotMapped] public static Profissao EngenheiroCivil => new Profissao(763, 214205, "Engenheiro civil");
        [NotMapped] public static Profissao EngenheiroCivilAeroportos => new Profissao(764, 214210, "Engenheiro civil (aeroportos)");
        [NotMapped] public static Profissao EngenheiroCivilEdificacoes => new Profissao(765, 214215, "Engenheiro civil (edificações)");
        [NotMapped] public static Profissao EngenheiroCivilEstruturasMetalicas => new Profissao(766, 214220, "Engenheiro civil (estruturas metálicas)");
        [NotMapped] public static Profissao EngenheiroCivilFerroviasEMetrovias => new Profissao(767, 214225, "Engenheiro civil (ferrovias e metrovias)");
        [NotMapped] public static Profissao EngenheiroCivilGeotecnia => new Profissao(768, 214230, "Engenheiro civil (geotécnia)");
        [NotMapped] public static Profissao EngenheiroCivilHidraulica => new Profissao(769, 214240, "Engenheiro civil (hidráulica)");
        [NotMapped] public static Profissao EngenheiroCivilHidrologia => new Profissao(770, 214235, "Engenheiro civil (hidrologia)");
        [NotMapped] public static Profissao EngenheiroCivilPontesEViadutos => new Profissao(771, 214245, "Engenheiro civil (pontes e viadutos)");
        [NotMapped] public static Profissao EngenheiroCivilPortosEViasNavegaveis => new Profissao(772, 214250, "Engenheiro civil (portos e vias navegáveis)");
        [NotMapped] public static Profissao EngenheiroCivilRodovias => new Profissao(773, 214255, "Engenheiro civil (rodovias)");
        [NotMapped] public static Profissao EngenheiroCivilSaneamento => new Profissao(774, 214260, "Engenheiro civil (saneamento)");
        [NotMapped] public static Profissao EngenheiroCivilTransportesETransito => new Profissao(775, 214270, "Engenheiro civil (transportes e trânsito)");
        [NotMapped] public static Profissao EngenheiroCivilTuneis => new Profissao(776, 214265, "Engenheiro civil (túneis)");
        [NotMapped] public static Profissao EngenheiroDeAlimentos => new Profissao(777, 222205, "Engenheiro de alimentos");
        [NotMapped] public static Profissao EngenheiroDeAplicativosEmComputacao => new Profissao(778, 212205, "Engenheiro de aplicativos em computação");
        [NotMapped] public static Profissao EngenheiroDeControleDeQualidade => new Profissao(779, 214910, "Engenheiro de controle de qualidade");
        [NotMapped] public static Profissao EngenheiroDeControleEAutomacao => new Profissao(780, 202110, "Engenheiro de controle e automação");
        [NotMapped] public static Profissao EngenheiroDeEquipamentosEmComputacao => new Profissao(781, 212210, "Engenheiro de equipamentos em computação");
        [NotMapped] public static Profissao EngenheiroDeLogistica => new Profissao(782, 214945, "Engenheiro de logistica");
        [NotMapped] public static Profissao EngenheiroDeManutencaoDeTelecomunicacoes => new Profissao(783, 214335, "Engenheiro de manutenção de telecomunicações");
        [NotMapped] public static Profissao EngenheiroDeMateriais => new Profissao(784, 214605, "Engenheiro de materiais");
        [NotMapped] public static Profissao EngenheiroDeMinas => new Profissao(785, 214705, "Engenheiro de minas");
        [NotMapped] public static Profissao EngenheiroDeMinasBeneficiamento => new Profissao(786, 214710, "Engenheiro de minas (beneficiamento)");
        [NotMapped] public static Profissao EngenheiroDeMinasLavraACeuAberto => new Profissao(787, 214715, "Engenheiro de minas (lavra a céu aberto)");
        [NotMapped] public static Profissao EngenheiroDeMinasLavraSubterranea => new Profissao(788, 214720, "Engenheiro de minas (lavra subterrânea)");
        [NotMapped] public static Profissao EngenheiroDeMinasPesquisaMineral => new Profissao(789, 214725, "Engenheiro de minas (pesquisa mineral)");
        [NotMapped] public static Profissao EngenheiroDeMinasPlanejamento => new Profissao(790, 214730, "Engenheiro de minas (planejamento)");
        [NotMapped] public static Profissao EngenheiroDeMinasProcesso => new Profissao(791, 214735, "Engenheiro de minas (processo)");
        [NotMapped] public static Profissao EngenheiroDeMinasProjeto => new Profissao(792, 214740, "Engenheiro de minas (projeto)");
        [NotMapped] public static Profissao EngenheiroDePesca => new Profissao(793, 222115, "Engenheiro de pesca");
        [NotMapped] public static Profissao EngenheiroDeProducao => new Profissao(794, 214905, "Engenheiro de produção");
        [NotMapped] public static Profissao EngenheiroDeRedesDeComunicacao => new Profissao(795, 214350, "Engenheiro de redes de comunicação");
        [NotMapped] public static Profissao EngenheiroDeRiscos => new Profissao(796, 214920, "Engenheiro de riscos");
        [NotMapped] public static Profissao EngenheiroDeSegurancaDoTrabalho => new Profissao(797, 214915, "Engenheiro de segurança do trabalho");
        [NotMapped] public static Profissao EngenheiroDeTelecomunicacoes => new Profissao(798, 214340, "Engenheiro de telecomunicações");
        [NotMapped] public static Profissao EngenheiroDeTemposEMovimentos => new Profissao(799, 214925, "Engenheiro de tempos e movimentos");
        [NotMapped] public static Profissao EngenheiroEletricista => new Profissao(800, 214305, "Engenheiro eletricista");
        [NotMapped] public static Profissao EngenheiroEletricistaDeManutencao => new Profissao(801, 214315, "Engenheiro eletricista de manutenção");
        [NotMapped] public static Profissao EngenheiroEletricistaDeProjetos => new Profissao(802, 214320, "Engenheiro eletricista de projetos");
        [NotMapped] public static Profissao EngenheiroEletronico => new Profissao(803, 214310, "Engenheiro eletrônico");
        [NotMapped] public static Profissao EngenheiroEletronicoDeManutencao => new Profissao(804, 214325, "Engenheiro eletrônico de manutenção");
        [NotMapped] public static Profissao EngenheiroEletronicoDeProjetos => new Profissao(805, 214330, "Engenheiro eletrônico de projetos");
        [NotMapped] public static Profissao EngenheiroFlorestal => new Profissao(806, 222120, "Engenheiro florestal");
        [NotMapped] public static Profissao EngenheiroMecanico => new Profissao(807, 214405, "Engenheiro mecânico");
        [NotMapped] public static Profissao EngenheiroMecanicoEnergiaNuclear => new Profissao(808, 214415, "Engenheiro mecânico (energia nuclear)");
        [NotMapped] public static Profissao EngenheiroMecanicoAutomotivo => new Profissao(809, 214410, "Engenheiro mecânico automotivo");
        [NotMapped] public static Profissao EngenheiroMecanicoIndustrial => new Profissao(810, 214420, "Engenheiro mecânico industrial");
        [NotMapped] public static Profissao EngenheiroMecatronico => new Profissao(811, 202105, "Engenheiro mecatrônico");
        [NotMapped] public static Profissao EngenheiroMetalurgista => new Profissao(812, 214610, "Engenheiro metalurgista");
        [NotMapped] public static Profissao EngenheiroNaval => new Profissao(813, 214430, "Engenheiro naval");
        [NotMapped] public static Profissao EngenheiroProjetistaDeTelecomunicacoes => new Profissao(814, 214345, "Engenheiro projetista de telecomunicações");
        [NotMapped] public static Profissao EngenheiroQuimico => new Profissao(815, 214505, "Engenheiro químico");
        [NotMapped] public static Profissao EngenheiroQuimicoIndustriaQuimica => new Profissao(816, 214510, "Engenheiro químico (indústria química)");
        [NotMapped] public static Profissao EngenheiroQuimicoMineracaoMetalurgiaSiderurgiaCimenteiraECeramica => new Profissao(817, 214515, "Engenheiro químico (mineração, metalurgia, siderurgia, cimenteira e cerâmica)");
        [NotMapped] public static Profissao EngenheiroQuimicoPapelECelulose => new Profissao(818, 214520, "Engenheiro químico (papel e celulose)");
        [NotMapped] public static Profissao EngenheiroQuimicoPetroleoEBorracha => new Profissao(819, 214525, "Engenheiro químico (petróleo e borracha)");
        [NotMapped] public static Profissao EngenheiroQuimicoUtilidadesEMeioAmbiente => new Profissao(820, 214530, "Engenheiro químico (utilidades e meio ambiente)");
        [NotMapped] public static Profissao EngenheirosDeSistemasOperacionaisEmComputacao => new Profissao(821, 212215, "Engenheiros de sistemas operacionais em computação");
        [NotMapped] public static Profissao Engraxate => new Profissao(822, 519915, "Engraxate");
        [NotMapped] public static Profissao Enologo => new Profissao(823, 325005, "Enólogo");
        [NotMapped] public static Profissao EnsaiadorDeDanca => new Profissao(824, 262825, "Ensaiador de dança");
        [NotMapped] public static Profissao EntalhadorDeMadeira => new Profissao(825, 775105, "Entalhador  de madeira");
        [NotMapped] public static Profissao EntregadorDePublicacoes => new Profissao(826, 415215, "Entregador de publicações");
        [NotMapped] public static Profissao EntrevistadorCensitarioEDePesquisasAmostrais => new Profissao(827, 424105, "Entrevistador censitário e de pesquisas amostrais");
        [NotMapped] public static Profissao EntrevistadorDePesquisaDeOpiniaoEMidia => new Profissao(828, 424110, "Entrevistador de pesquisa de opinião e mídia");
        [NotMapped] public static Profissao EntrevistadorDePesquisasDeMercado => new Profissao(829, 424115, "Entrevistador de pesquisas de mercado");
        [NotMapped] public static Profissao EntrevistadorDePrecos => new Profissao(830, 424120, "Entrevistador de preços");
        [NotMapped] public static Profissao EntrevistadorSocial => new Profissao(831, 424130, "Entrevistador social");
        [NotMapped] public static Profissao EnxugadorDeCouros => new Profissao(832, 762215, "Enxugador de couros");
        [NotMapped] public static Profissao Equilibrista => new Profissao(833, 376230, "Equilibrista");
        [NotMapped] public static Profissao Equoterapeuta => new Profissao(834, 226315, "Equoterapeuta");
        [NotMapped] public static Profissao Escarfador => new Profissao(835, 821410, "Escarfador");
        [NotMapped] public static Profissao EscolhedorDePapel => new Profissao(836, 391225, "Escolhedor de papel");
        [NotMapped] public static Profissao EscoradorDeMinas => new Profissao(837, 711125, "Escorador de minas");
        [NotMapped] public static Profissao Escrevente => new Profissao(838, 351405, "Escrevente");
        [NotMapped] public static Profissao EscritorDeFiccao => new Profissao(839, 261515, "Escritor de ficção");
        [NotMapped] public static Profissao EscritorDeNaoFiccao => new Profissao(840, 261520, "Escritor de não ficção");
        [NotMapped] public static Profissao EscriturarioEmEstatistica => new Profissao(841, 424125, "Escriturário  em  estatística");
        [NotMapped] public static Profissao EscriturarioDeBanco => new Profissao(842, 413225, "Escriturário de banco");
        [NotMapped] public static Profissao EscrivaoDePolicia => new Profissao(843, 351420, "Escrivão de polícia");
        [NotMapped] public static Profissao EscrivaoExtraJudicial => new Profissao(844, 351415, "Escrivão extra - judicial");
        [NotMapped] public static Profissao EscrivaoJudicial => new Profissao(845, 351410, "Escrivão judicial");
        [NotMapped] public static Profissao Esoterico => new Profissao(846, 516805, "Esotérico");
        [NotMapped] public static Profissao EspecialistaDePoliticasPublicasEGestaoGovernamentalEppgg => new Profissao(847, 111505, "Especialista de políticas públicas e gestão governamental - eppgg");
        [NotMapped] public static Profissao EspecialistaEmCalibracoesMetrologicas => new Profissao(848, 201210, "Especialista em calibrações metrológicas");
        [NotMapped] public static Profissao EspecialistaEmDesenvolvimentoDeCigarros => new Profissao(849, 142610, "Especialista em desenvolvimento de cigarros");
        [NotMapped] public static Profissao EspecialistaEmEnsaiosMetrologicos => new Profissao(850, 201215, "Especialista em ensaios metrológicos");
        [NotMapped] public static Profissao EspecialistaEmInstrumentacaoMetrologica => new Profissao(851, 201220, "Especialista em instrumentação metrológica");
        [NotMapped] public static Profissao EspecialistaEmMateriaisDeReferenciaMetrologica => new Profissao(852, 201225, "Especialista em materiais de referência metrológica");
        [NotMapped] public static Profissao EspecialistaEmPesquisaOperacional => new Profissao(853, 211110, "Especialista em pesquisa operacional");
        [NotMapped] public static Profissao EstampadorDeTecido => new Profissao(854, 761410, "Estampador de tecido");
        [NotMapped] public static Profissao Estatistico => new Profissao(855, 211205, "Estatístico");
        [NotMapped] public static Profissao EstatisticoEstatisticaAplicada => new Profissao(856, 211210, "Estatístico (estatística aplicada)");
        [NotMapped] public static Profissao EstatisticoTeorico => new Profissao(857, 211215, "Estatístico teórico");
        [NotMapped] public static Profissao Esteireiro => new Profissao(858, 776425, "Esteireiro");
        [NotMapped] public static Profissao Estenotipista => new Profissao(859, 351515, "Estenotipista");
        [NotMapped] public static Profissao EsterilizadorDeAlimentos => new Profissao(860, 841440, "Esterilizador de alimentos");
        [NotMapped] public static Profissao Esteticista => new Profissao(861, 322130, "Esteticista");
        [NotMapped] public static Profissao EsteticistaDeAnimaisDomesticos => new Profissao(862, 519310, "Esteticista de animais domésticos");
        [NotMapped] public static Profissao EstiradorDeCourosEPelesAcabamento => new Profissao(863, 762305, "Estirador de couros e peles (acabamento)");
        [NotMapped] public static Profissao EstiradorDeCourosEPelesPreparacao => new Profissao(864, 762115, "Estirador de couros e peles (preparação)");
        [NotMapped] public static Profissao EstiradorDeTubosDeMetalSemCostura => new Profissao(865, 722410, "Estirador de tubos de metal sem costura");
        [NotMapped] public static Profissao Estivador => new Profissao(866, 783220, "Estivador");
        [NotMapped] public static Profissao EstofadorDeAvioes => new Profissao(867, 765230, "Estofador de aviões");
        [NotMapped] public static Profissao EstofadorDeMoveis => new Profissao(868, 765235, "Estofador de móveis");
        [NotMapped] public static Profissao Estoquista => new Profissao(869, 414125, "Estoquista");
        [NotMapped] public static Profissao ExaminadorDeCabosLinhasEletricasETelefonicas => new Profissao(870, 732115, "Examinador de cabos, linhas elétricas e telefônicas");
        [NotMapped] public static Profissao ExpedidorDeMercadorias => new Profissao(871, 414135, "Expedidor de mercadorias");
        [NotMapped] public static Profissao ExtrusorDeFiosOuFibrasDeVidro => new Profissao(872, 823210, "Extrusor de fios ou fibras de vidro");
        [NotMapped] public static Profissao Farmaceutico => new Profissao(873, 223405, "Farmacêutico");
        [NotMapped] public static Profissao FarmaceuticoAnalistaClinico => new Profissao(874, 223415, "Farmacêutico analista clínico");
        [NotMapped] public static Profissao FarmaceuticoDeAlimentos => new Profissao(875, 223420, "Farmacêutico de alimentos");
        [NotMapped] public static Profissao FarmaceuticoEmSaudePublica => new Profissao(876, 223430, "Farmacêutico em saúde pública");
        [NotMapped] public static Profissao FarmaceuticoHospitalarEClinico => new Profissao(877, 223445, "Farmacêutico hospitalar e clínico");
        [NotMapped] public static Profissao FarmaceuticoIndustrial => new Profissao(878, 223435, "Farmacêutico industrial");
        [NotMapped] public static Profissao FarmaceuticoPraticasIntegrativasEComplementares => new Profissao(879, 223425, "Farmacêutico práticas integrativas e complementares");
        [NotMapped] public static Profissao FarmaceuticoToxicologista => new Profissao(880, 223440, "Farmacêutico toxicologista");
        [NotMapped] public static Profissao Faxineiro => new Profissao(881, 514320, "Faxineiro");
        [NotMapped] public static Profissao Feirante => new Profissao(882, 524205, "Feirante");
        [NotMapped] public static Profissao Fermentador => new Profissao(883, 841715, "Fermentador");
        [NotMapped] public static Profissao FerradorDeAnimais => new Profissao(884, 623030, "Ferrador de animais");
        [NotMapped] public static Profissao Ferramenteiro => new Profissao(885, 721105, "Ferramenteiro");
        [NotMapped] public static Profissao FerramenteiroDeMandrisCalibradoresEOutrosDispositivos => new Profissao(886, 721110, "Ferramenteiro de mandris, calibradores e outros dispositivos");
        [NotMapped] public static Profissao Filologo => new Profissao(887, 261405, "Filólogo");
        [NotMapped] public static Profissao Filosofo => new Profissao(888, 251405, "Filósofo");
        [NotMapped] public static Profissao FiltradorDeCerveja => new Profissao(889, 841710, "Filtrador de cerveja");
        [NotMapped] public static Profissao FinalizadorDeFilmes => new Profissao(890, 374410, "Finalizador de filmes");
        [NotMapped] public static Profissao FinalizadorDeVideo => new Profissao(891, 374415, "Finalizador de vídeo");
        [NotMapped] public static Profissao FiscalDeAtividadesUrbanas => new Profissao(892, 254505, "Fiscal de atividades urbanas");
        [NotMapped] public static Profissao FiscalDeAviacaoCivilFac => new Profissao(893, 342515, "Fiscal de aviação civil (fac)");
        [NotMapped] public static Profissao FiscalDeLoja => new Profissao(894, 517425, "Fiscal de loja");
        [NotMapped] public static Profissao FiscalDePatioDeUsinaDeConcreto => new Profissao(895, 710225, "Fiscal de pátio de usina de concreto");
        [NotMapped] public static Profissao FiscalDePistaDeAeroporto => new Profissao(896, 342555, "Fiscal de pista de aeroporto");
        [NotMapped] public static Profissao FiscalDeTransportesColetivosExcetoTrem => new Profissao(897, 511205, "Fiscal de transportes coletivos (exceto trem)");
        [NotMapped] public static Profissao FiscalDeTributosEstadual => new Profissao(898, 254405, "Fiscal de tributos estadual");
        [NotMapped] public static Profissao FiscalDeTributosMunicipal => new Profissao(899, 254410, "Fiscal de tributos municipal");
        [NotMapped] public static Profissao Fisico => new Profissao(900, 213105, "Físico");
        [NotMapped] public static Profissao FisicoAcustica => new Profissao(901, 213110, "Físico (acústica)");
        [NotMapped] public static Profissao FisicoAtomicaEMolecular => new Profissao(902, 213115, "Físico (atômica e molecular)");
        [NotMapped] public static Profissao FisicoCosmologia => new Profissao(903, 213120, "Físico (cosmologia)");
        [NotMapped] public static Profissao FisicoEstatisticaEMatematica => new Profissao(904, 213125, "Físico (estatística e matemática)");
        [NotMapped] public static Profissao FisicoFluidos => new Profissao(905, 213130, "Físico (fluidos)");
        [NotMapped] public static Profissao FisicoInstrumentacao => new Profissao(906, 213135, "Físico (instrumentação)");
        [NotMapped] public static Profissao FisicoMateriaCondensada => new Profissao(907, 213140, "Físico (matéria condensada)");
        [NotMapped] public static Profissao FisicoMateriais => new Profissao(908, 213145, "Físico (materiais)");
        [NotMapped] public static Profissao FisicoMedicina => new Profissao(909, 213150, "Físico (medicina)");
        [NotMapped] public static Profissao FisicoNuclearEReatores => new Profissao(910, 213155, "Físico (nuclear e reatores)");
        [NotMapped] public static Profissao FisicoOptica => new Profissao(911, 213160, "Físico (óptica)");
        [NotMapped] public static Profissao FisicoParticulasECampos => new Profissao(912, 213165, "Físico (partículas e campos)");
        [NotMapped] public static Profissao FisicoPlasma => new Profissao(913, 213170, "Físico (plasma)");
        [NotMapped] public static Profissao FisicoTermica => new Profissao(914, 213175, "Físico (térmica)");
        [NotMapped] public static Profissao FisioterapeutaDoTrabalho => new Profissao(915, 223660, "Fisioterapeuta  do trabalho");
        [NotMapped] public static Profissao FisioterapeutaAcupunturista => new Profissao(916, 223650, "Fisioterapeuta acupunturista");
        [NotMapped] public static Profissao FisioterapeutaEsportivo => new Profissao(917, 223655, "Fisioterapeuta esportivo");
        [NotMapped] public static Profissao FisioterapeutaGeral => new Profissao(918, 223605, "Fisioterapeuta geral");
        [NotMapped] public static Profissao FisioterapeutaNeurofuncional => new Profissao(919, 223630, "Fisioterapeuta neurofuncional");
        [NotMapped] public static Profissao FisioterapeutaOsteopata => new Profissao(920, 223640, "Fisioterapeuta osteopata");
        [NotMapped] public static Profissao FisioterapeutaQuiropraxista => new Profissao(921, 223645, "Fisioterapeuta quiropraxista");
        [NotMapped] public static Profissao FisioterapeutaRespiratoria => new Profissao(922, 223625, "Fisioterapeuta respiratória");
        [NotMapped] public static Profissao FisioterapeutaTraumatoOrtopedicaFuncional => new Profissao(923, 223635, "Fisioterapeuta traumato-ortopédica funcional");
        [NotMapped] public static Profissao Fitotecario => new Profissao(924, 415120, "Fitotecário");
        [NotMapped] public static Profissao FoguistaLocomotivasAVapor => new Profissao(925, 862105, "Foguista (locomotivas a vapor)");
        [NotMapped] public static Profissao FolheadorDeMoveisDeMadeira => new Profissao(926, 775110, "Folheador de móveis de madeira");
        [NotMapped] public static Profissao FonoaudiologoEducacional => new Profissao(927, 223815, "Fonoaudiólogo educacional");
        [NotMapped] public static Profissao FonoaudiologoEmAudiologia => new Profissao(928, 223820, "Fonoaudiólogo em audiologia");
        [NotMapped] public static Profissao FonoaudiologoEmDisfagia => new Profissao(929, 223825, "Fonoaudiólogo em disfagia");
        [NotMapped] public static Profissao FonoaudiologoEmLinguagem => new Profissao(930, 223830, "Fonoaudiólogo em linguagem");
        [NotMapped] public static Profissao FonoaudiologoEmMotricidadeOrofacial => new Profissao(931, 223835, "Fonoaudiólogo em motricidade orofacial");
        [NotMapped] public static Profissao FonoaudiologoEmSaudeColetiva => new Profissao(932, 223840, "Fonoaudiólogo em saúde coletiva");
        [NotMapped] public static Profissao FonoaudiologoEmVoz => new Profissao(933, 223845, "Fonoaudiólogo em voz");
        [NotMapped] public static Profissao FonoaudiologoGeral => new Profissao(934, 223810, "Fonoaudiólogo geral");
        [NotMapped] public static Profissao Forjador => new Profissao(935, 722105, "Forjador");
        [NotMapped] public static Profissao ForjadorAMartelo => new Profissao(936, 722110, "Forjador a martelo");
        [NotMapped] public static Profissao ForjadorPrensista => new Profissao(937, 722115, "Forjador prensista");
        [NotMapped] public static Profissao ForneiroMateriaisDeConstrucao => new Profissao(938, 823315, "Forneiro (materiais de construção)");
        [NotMapped] public static Profissao ForneiroDeCubilo => new Profissao(939, 822105, "Forneiro de cubilô");
        [NotMapped] public static Profissao ForneiroDeFornoPoco => new Profissao(940, 822110, "Forneiro de forno-poço");
        [NotMapped] public static Profissao ForneiroDeFundicaoFornoDeReducao => new Profissao(941, 822115, "Forneiro de fundição (forno de redução)");
        [NotMapped] public static Profissao ForneiroDeReaquecimentoETratamentoTermicoNaMetalurgia => new Profissao(942, 822120, "Forneiro de reaquecimento e tratamento térmico na metalurgia");
        [NotMapped] public static Profissao ForneiroDeReverbero => new Profissao(943, 822125, "Forneiro de revérbero");
        [NotMapped] public static Profissao ForneiroEOperadorAltoForno => new Profissao(944, 821205, "Forneiro e operador (alto-forno)");
        [NotMapped] public static Profissao ForneiroEOperadorConversorAOxigenio => new Profissao(945, 821210, "Forneiro e operador (conversor a oxigênio)");
        [NotMapped] public static Profissao ForneiroEOperadorFornoEletrico => new Profissao(946, 821215, "Forneiro e operador (forno elétrico)");
        [NotMapped] public static Profissao ForneiroEOperadorRefinoDeMetaisNaoFerrosos => new Profissao(947, 821220, "Forneiro e operador (refino de metais não-ferrosos)");
        [NotMapped] public static Profissao ForneiroEOperadorDeFornoDeReducaoDireta => new Profissao(948, 821225, "Forneiro e operador de forno de redução direta");
        [NotMapped] public static Profissao ForneiroNaFundicaoDeVidro => new Profissao(949, 823215, "Forneiro na fundição de vidro");
        [NotMapped] public static Profissao ForneiroNoRecozimentoDeVidro => new Profissao(950, 823220, "Forneiro no recozimento de vidro");
        [NotMapped] public static Profissao Fosfatizador => new Profissao(951, 723210, "Fosfatizador");
        [NotMapped] public static Profissao Fotografo => new Profissao(952, 261805, "Fotógrafo");
        [NotMapped] public static Profissao FotografoPublicitario => new Profissao(953, 261810, "Fotógrafo publicitário");
        [NotMapped] public static Profissao FotografoRetratista => new Profissao(954, 261815, "Fotógrafo retratista");
        [NotMapped] public static Profissao Frentista => new Profissao(955, 521135, "Frentista");
        [NotMapped] public static Profissao Fuloneiro => new Profissao(956, 762120, "Fuloneiro");
        [NotMapped] public static Profissao FuloneiroNoAcabamentoDeCourosEPeles => new Profissao(957, 762310, "Fuloneiro no acabamento de couros e peles");
        [NotMapped] public static Profissao FundidorJoalheriaEOurivesaria => new Profissao(958, 751110, "Fundidor (joalheria e ourivesaria)");
        [NotMapped] public static Profissao FundidorDeMetais => new Profissao(959, 722205, "Fundidor de metais");
        [NotMapped] public static Profissao FunileiroDeVeiculosReparacao => new Profissao(960, 991305, "Funileiro de veículos (reparação)");
        [NotMapped] public static Profissao FunileiroIndustrial => new Profissao(961, 724435, "Funileiro industrial");
        [NotMapped] public static Profissao Galvanizador => new Profissao(962, 723215, "Galvanizador");
        [NotMapped] public static Profissao Gandula => new Profissao(963, 519920, "Gandula");
        [NotMapped] public static Profissao Garagista => new Profissao(964, 514110, "Garagista");
        [NotMapped] public static Profissao Garcom => new Profissao(965, 513405, "Garçom");
        [NotMapped] public static Profissao GarcomServicosDeVinhos => new Profissao(966, 513410, "Garçom (serviços de vinhos)");
        [NotMapped] public static Profissao Garimpeiro => new Profissao(967, 711405, "Garimpeiro");
        [NotMapped] public static Profissao GeladorIndustrial => new Profissao(968, 631405, "Gelador industrial");
        [NotMapped] public static Profissao GeladorProfissional => new Profissao(969, 631410, "Gelador profissional");
        [NotMapped] public static Profissao Geneticista => new Profissao(970, 201115, "Geneticista");
        [NotMapped] public static Profissao Geofisico => new Profissao(971, 213415, "Geofísico");
        [NotMapped] public static Profissao GeofisicoEspacial => new Profissao(972, 213310, "Geofísico espacial");
        [NotMapped] public static Profissao Geografo => new Profissao(973, 251305, "Geógrafo");
        [NotMapped] public static Profissao Geologo => new Profissao(974, 213405, "Geólogo");
        [NotMapped] public static Profissao GeologoDeEngenharia => new Profissao(975, 213410, "Geólogo de engenharia");
        [NotMapped] public static Profissao Geoquimico => new Profissao(976, 213420, "Geoquímico");
        [NotMapped] public static Profissao GerenteAdministrativo => new Profissao(977, 142105, "Gerente administrativo");
        [NotMapped] public static Profissao GerenteComercial => new Profissao(978, 142305, "Gerente comercial");
        [NotMapped] public static Profissao GerenteDeAdministracaoEmAeroportos => new Profissao(979, 141805, "Gerente de administração em aeroportos");
        [NotMapped] public static Profissao GerenteDeAgencia => new Profissao(980, 141710, "Gerente de agência");
        [NotMapped] public static Profissao GerenteDeAlmoxarifado => new Profissao(981, 142415, "Gerente de almoxarifado");
        [NotMapped] public static Profissao GerenteDeBar => new Profissao(982, 141515, "Gerente de bar");
        [NotMapped] public static Profissao GerenteDeCambioEComercioExterior => new Profissao(983, 141715, "Gerente de câmbio e comércio exterior");
        [NotMapped] public static Profissao GerenteDeCaptacaoFundosEInvestimentosInstitucionais => new Profissao(984, 253205, "Gerente de captação (fundos e investimentos institucionais)");
        [NotMapped] public static Profissao GerenteDeClientesEspeciaisPrivate => new Profissao(985, 253210, "Gerente de clientes especiais (private)");
        [NotMapped] public static Profissao GerenteDeCompras => new Profissao(986, 142405, "Gerente de compras");
        [NotMapped] public static Profissao GerenteDeComunicacao => new Profissao(987, 142310, "Gerente de comunicação");
        [NotMapped] public static Profissao GerenteDeContasPessoaFisicaEJuridica => new Profissao(988, 253215, "Gerente de contas - pessoa física e jurídica");
        [NotMapped] public static Profissao GerenteDeCreditoECobranca => new Profissao(989, 141720, "Gerente de crédito e cobrança");
        [NotMapped] public static Profissao GerenteDeCreditoImobiliario => new Profissao(990, 141725, "Gerente de crédito imobiliário");
        [NotMapped] public static Profissao GerenteDeCreditoRural => new Profissao(991, 141730, "Gerente de crédito rural");
        [NotMapped] public static Profissao GerenteDeDepartamentoPessoal => new Profissao(992, 142210, "Gerente de departamento pessoal");
        [NotMapped] public static Profissao GerenteDeDesenvolvimentoDeSistemas => new Profissao(993, 142510, "Gerente de desenvolvimento de sistemas");
        [NotMapped] public static Profissao GerenteDeEmpresaAereaEEmpresaDeServicosAuxiliaresAoTransporteAereoEsataEmAeroportos => new Profissao(994, 141810, "Gerente de empresa aérea e empresa de serviços auxiliares ao transporte aéreo (esata) em aeroportos");
        [NotMapped] public static Profissao GerenteDeGrandesContasCorporate => new Profissao(995, 253220, "Gerente de grandes contas (corporate)");
        [NotMapped] public static Profissao GerenteDeHotel => new Profissao(996, 141505, "Gerente de hotel");
        [NotMapped] public static Profissao GerenteDeInfraestruturaDeTecnologiaDaInformacao => new Profissao(997, 142505, "Gerente de infraestrutura de tecnologia da informação");
        [NotMapped] public static Profissao GerenteDeInstituicaoEducacionalDaAreaPrivada => new Profissao(998, 131315, "Gerente de instituição educacional da área privada");
        [NotMapped] public static Profissao GerenteDeLogisticaArmazenagemEDistribuicao => new Profissao(999, 141615, "Gerente de logística (armazenagem e distribuição)");
        [NotMapped] public static Profissao GerenteDeLojaESupermercado => new Profissao(1000, 141415, "Gerente de loja e supermercado");
        [NotMapped] public static Profissao GerenteDeMarketing => new Profissao(1001, 142315, "Gerente de marketing");
        [NotMapped] public static Profissao GerenteDeOperacaoDeTecnologiaDaInformacao => new Profissao(1002, 142515, "Gerente de operação de tecnologia da informação");
        [NotMapped] public static Profissao GerenteDeOperacoesDeCargas => new Profissao(1003, 141820, "Gerente de operações de cargas");
        [NotMapped] public static Profissao GerenteDeOperacoesDeCorreiosETelecomunicacoes => new Profissao(1004, 141610, "Gerente de operações de correios e telecomunicações");
        [NotMapped] public static Profissao GerenteDeOperacoesDeServicosDeAssistenciaTecnica => new Profissao(1005, 141420, "Gerente de operações de serviços de assistência técnica");
        [NotMapped] public static Profissao GerenteDeOperacoesDeTransportes => new Profissao(1006, 141605, "Gerente de operações de transportes");
        [NotMapped] public static Profissao GerenteDeOperacoesEmAeroportos => new Profissao(1007, 141815, "Gerente de operações em aeroportos");
        [NotMapped] public static Profissao GerenteDePensao => new Profissao(1008, 141520, "Gerente de pensão");
        [NotMapped] public static Profissao GerenteDePesquisaEDesenvolvimentoPD => new Profissao(1009, 142605, "Gerente de pesquisa e desenvolvimento (p&d)");
        [NotMapped] public static Profissao GerenteDeProducaoEOperacoes => new Profissao(1010, 141205, "Gerente de produção e operações");
        [NotMapped] public static Profissao GerenteDeProducaoEOperacoesAquicolas => new Profissao(1011, 141105, "Gerente de produção e operações  aqüícolas");
        [NotMapped] public static Profissao GerenteDeProducaoEOperacoesFlorestais => new Profissao(1012, 141110, "Gerente de produção e operações  florestais");
        [NotMapped] public static Profissao GerenteDeProducaoEOperacoesAgropecuarias => new Profissao(1013, 141115, "Gerente de produção e operações agropecuárias");
        [NotMapped] public static Profissao GerenteDeProducaoEOperacoesDaConstrucaoCivilEObrasPublicas => new Profissao(1014, 141305, "Gerente de produção e operações da construção civil e obras públicas");
        [NotMapped] public static Profissao GerenteDeProducaoEOperacoesPesqueiras => new Profissao(1015, 141120, "Gerente de produção e operações pesqueiras");
        [NotMapped] public static Profissao GerenteDeProdutosBancarios => new Profissao(1016, 141705, "Gerente de produtos bancários");
        [NotMapped] public static Profissao GerenteDeProjetosDeTecnologiaDaInformacao => new Profissao(1017, 142520, "Gerente de projetos de tecnologia da informação");
        [NotMapped] public static Profissao GerenteDeProjetosEServicosDeManutencao => new Profissao(1018, 142705, "Gerente de projetos e serviços de manutenção");
        [NotMapped] public static Profissao GerenteDeRecuperacaoDeCredito => new Profissao(1019, 141735, "Gerente de recuperação de crédito");
        [NotMapped] public static Profissao GerenteDeRecursosHumanos => new Profissao(1020, 142205, "Gerente de recursos humanos");
        [NotMapped] public static Profissao GerenteDeRestaurante => new Profissao(1021, 141510, "Gerente de restaurante");
        [NotMapped] public static Profissao GerenteDeRiscos => new Profissao(1022, 142110, "Gerente de riscos");
        [NotMapped] public static Profissao GerenteDeSegurancaDaAviacaoCivil => new Profissao(1023, 141825, "Gerente de segurança da aviação civil");
        [NotMapped] public static Profissao GerenteDeSegurancaDaInformacao => new Profissao(1024, 142525, "Gerente de segurança da informação");
        [NotMapped] public static Profissao GerenteDeSegurancaOperacionalAviacaoCivil => new Profissao(1025, 141830, "Gerente de segurança operacional (aviação civil)");
        [NotMapped] public static Profissao GerenteDeServicosCulturais => new Profissao(1026, 131115, "Gerente de serviços culturais");
        [NotMapped] public static Profissao GerenteDeServicosDeSaude => new Profissao(1027, 131210, "Gerente de serviços de saúde");
        [NotMapped] public static Profissao GerenteDeServicosEducacionaisDaAreaPublica => new Profissao(1028, 131320, "Gerente de serviços educacionais da área pública");
        [NotMapped] public static Profissao GerenteDeServicosSociais => new Profissao(1029, 131120, "Gerente de serviços sociais");
        [NotMapped] public static Profissao GerenteDeSuporteTecnicoDeTecnologiaDaInformacao => new Profissao(1030, 142530, "Gerente de suporte técnico de tecnologia da informação");
        [NotMapped] public static Profissao GerenteDeSuprimentos => new Profissao(1031, 142410, "Gerente de suprimentos");
        [NotMapped] public static Profissao GerenteDeTurismo => new Profissao(1032, 141525, "Gerente de turismo");
        [NotMapped] public static Profissao GerenteDeVendas => new Profissao(1033, 142320, "Gerente de vendas");
        [NotMapped] public static Profissao GerenteFinanceiro => new Profissao(1034, 142115, "Gerente financeiro");
        [NotMapped] public static Profissao Gerontologo => new Profissao(1035, 131220, "Gerontólogo");
        [NotMapped] public static Profissao Gesseiro => new Profissao(1036, 716405, "Gesseiro");
        [NotMapped] public static Profissao GestorEmSeguranca => new Profissao(1037, 252605, "Gestor em segurança");
        [NotMapped] public static Profissao GovernadorDeEstado => new Profissao(1038, 111230, "Governador de estado");
        [NotMapped] public static Profissao GovernadorDoDistritoFederal => new Profissao(1039, 111235, "Governador do distrito federal");
        [NotMapped] public static Profissao GovernantaDeHotelaria => new Profissao(1040, 513115, "Governanta de hotelaria");
        [NotMapped] public static Profissao GravadorJoalheriaEOurivesaria => new Profissao(1041, 751115, "Gravador (joalheria e ourivesaria)");
        [NotMapped] public static Profissao GravadorDeInscricoesEmPedra => new Profissao(1042, 712210, "Gravador de inscrições em pedra");
        [NotMapped] public static Profissao GravadorDeMatrizCalcografica => new Profissao(1043, 766135, "Gravador de matriz calcográfica");
        [NotMapped] public static Profissao GravadorDeMatrizParaFlexografiaClicherista => new Profissao(1044, 766115, "Gravador de matriz para flexografia (clicherista)");
        [NotMapped] public static Profissao GravadorDeMatrizParaRotogravuraEletromecanicoEQuimico => new Profissao(1045, 766130, "Gravador de matriz para rotogravura (eletromecânico e químico)");
        [NotMapped] public static Profissao GravadorDeMatrizSerigrafica => new Profissao(1046, 766140, "Gravador de matriz serigráfica");
        [NotMapped] public static Profissao GravadorDeRelevosEmPedra => new Profissao(1047, 712215, "Gravador de relevos em pedra");
        [NotMapped] public static Profissao GravadorDeVidroAAguaForte => new Profissao(1048, 752215, "Gravador de vidro a  água-forte");
        [NotMapped] public static Profissao GravadorDeVidroAEsmeril => new Profissao(1049, 752220, "Gravador de vidro a  esmeril");
        [NotMapped] public static Profissao GravadorDeVidroAJatoDeAreia => new Profissao(1050, 752225, "Gravador de vidro a  jato de areia");
        [NotMapped] public static Profissao GravadorAMaoEncadernacao => new Profissao(1051, 768705, "Gravador, à mão (encadernação)");
        [NotMapped] public static Profissao GuardaPortuario => new Profissao(1052, 517335, "Guarda portuário");
        [NotMapped] public static Profissao GuardaCivilMunicipal => new Profissao(1053, 517215, "Guarda-civil municipal");
        [NotMapped] public static Profissao GuardadorDeVeiculos => new Profissao(1054, 519925, "Guardador de veículos");
        [NotMapped] public static Profissao GuardaRoupeiroDeCinema => new Profissao(1055, 513325, "Guarda-roupeiro de cinema");
        [NotMapped] public static Profissao GuiaDeTurismo => new Profissao(1056, 511405, "Guia de turismo");
        [NotMapped] public static Profissao GuiaFlorestal => new Profissao(1057, 632005, "Guia florestal");
        [NotMapped] public static Profissao GuincheiroConstrucaoCivil => new Profissao(1058, 782205, "Guincheiro (construção civil)");
        [NotMapped] public static Profissao HidrogenadorDeOleosEGorduras => new Profissao(1059, 841444, "Hidrogenador de óleos e gorduras");
        [NotMapped] public static Profissao Hidrogeologo => new Profissao(1060, 213425, "Hidrogeólogo");
        [NotMapped] public static Profissao HigienistaOcupacional => new Profissao(1061, 214940, "Higienista ocupacional");
        [NotMapped] public static Profissao IdentificadorFlorestal => new Profissao(1062, 632115, "Identificador florestal");
        [NotMapped] public static Profissao IluminadorTelevisao => new Profissao(1063, 372110, "Iluminador (televisão)");
        [NotMapped] public static Profissao ImediatoDaMarinhaMercante => new Profissao(1064, 215125, "Imediato da marinha mercante");
        [NotMapped] public static Profissao ImpregnadorDeMadeira => new Profissao(1065, 772110, "Impregnador de madeira");
        [NotMapped] public static Profissao ImpressorSerigrafia => new Profissao(1066, 766205, "Impressor (serigrafia)");
        [NotMapped] public static Profissao ImpressorCalcografico => new Profissao(1067, 766210, "Impressor calcográfico");
        [NotMapped] public static Profissao ImpressorDeCorteEVinco => new Profissao(1068, 766310, "Impressor de corte e vinco");
        [NotMapped] public static Profissao ImpressorDeOfsetePlanoERotativo => new Profissao(1069, 766215, "Impressor de ofsete (plano e rotativo)");
        [NotMapped] public static Profissao ImpressorDeRotativa => new Profissao(1070, 766220, "Impressor de rotativa");
        [NotMapped] public static Profissao ImpressorDeRotogravura => new Profissao(1071, 766225, "Impressor de rotogravura");
        [NotMapped] public static Profissao ImpressorDigital => new Profissao(1072, 766230, "Impressor digital");
        [NotMapped] public static Profissao ImpressorFlexografico => new Profissao(1073, 766235, "Impressor flexográfico");
        [NotMapped] public static Profissao ImpressorLetterset => new Profissao(1074, 766240, "Impressor letterset");
        [NotMapped] public static Profissao ImpressorTampografico => new Profissao(1075, 766245, "Impressor tampográfico");
        [NotMapped] public static Profissao ImpressorTipografico => new Profissao(1076, 766250, "Impressor tipográfico");
        [NotMapped] public static Profissao InfluenciadorDigital => new Profissao(1077, 253410, "Influenciador digital");
        [NotMapped] public static Profissao Inseminador => new Profissao(1078, 623010, "Inseminador");
        [NotMapped] public static Profissao InspetorDeAlunosDeEscolaPrivada => new Profissao(1079, 334105, "Inspetor de alunos de escola privada");
        [NotMapped] public static Profissao InspetorDeAlunosDeEscolaPublica => new Profissao(1080, 334110, "Inspetor de alunos de escola pública");
        [NotMapped] public static Profissao InspetorDeAviacaoCivil => new Profissao(1081, 342530, "Inspetor de aviação civil");
        [NotMapped] public static Profissao InspetorDeControleDimensional => new Profissao(1082, 314830, "Inspetor de controle dimensional");
        [NotMapped] public static Profissao InspetorDeDutos => new Profissao(1083, 314825, "Inspetor de dutos");
        [NotMapped] public static Profissao InspetorDeEnsaiosNaoDestrutivos => new Profissao(1084, 314815, "Inspetor de ensaios não destrutivos");
        [NotMapped] public static Profissao InspetorDeEquipamentos => new Profissao(1085, 314805, "Inspetor de equipamentos");
        [NotMapped] public static Profissao InspetorDeEstampariaProducaoTextil => new Profissao(1086, 761805, "Inspetor de estamparia (produção têxtil)");
        [NotMapped] public static Profissao InspetorDeFabricacao => new Profissao(1087, 314810, "Inspetor de fabricação");
        [NotMapped] public static Profissao InspetorDeManutencao => new Profissao(1088, 314840, "Inspetor de manutenção");
        [NotMapped] public static Profissao InspetorDePintura => new Profissao(1089, 314835, "Inspetor de pintura");
        [NotMapped] public static Profissao InspetorDeQualidade => new Profissao(1090, 391205, "Inspetor de qualidade");
        [NotMapped] public static Profissao InspetorDeRisco => new Profissao(1091, 351725, "Inspetor de risco");
        [NotMapped] public static Profissao InspetorDeServicosDeTransportesRodoviariosPassageirosECargas => new Profissao(1092, 342310, "Inspetor de serviços de transportes rodoviários (passageiros e cargas)");
        [NotMapped] public static Profissao InspetorDeSinistros => new Profissao(1093, 351730, "Inspetor de sinistros");
        [NotMapped] public static Profissao InspetorDeSoldagem => new Profissao(1094, 314845, "Inspetor de soldagem");
        [NotMapped] public static Profissao InspetorDeTerminal => new Profissao(1095, 215130, "Inspetor de terminal");
        [NotMapped] public static Profissao InspetorDeTerraplenagem => new Profissao(1096, 710215, "Inspetor de terraplenagem");
        [NotMapped] public static Profissao InspetorDeViaPermanenteTrilhos => new Profissao(1097, 991110, "Inspetor de via permanente (trilhos)");
        [NotMapped] public static Profissao InspetorNaval => new Profissao(1098, 215135, "Inspetor naval");
        [NotMapped] public static Profissao InstaladorDeCortinasEPersianasPortasSanfonadasEBoxe => new Profissao(1099, 523105, "Instalador de cortinas e persianas, portas sanfonadas e boxe");
        [NotMapped] public static Profissao InstaladorDeIsolantesAcusticos => new Profissao(1100, 715710, "Instalador de isolantes acústicos");
        [NotMapped] public static Profissao InstaladorDeIsolantesTermicosRefrigeracaoEClimatizacao => new Profissao(1101, 715715, "Instalador de isolantes térmicos (refrigeração e climatização)");
        [NotMapped] public static Profissao InstaladorDeIsolantesTermicosDeCaldeiraETubulacoes => new Profissao(1102, 715720, "Instalador de isolantes térmicos de caldeira e tubulações");
        [NotMapped] public static Profissao InstaladorDeLinhasEletricasDeAltaEBaixaTensaoRedeAereaESubterranea => new Profissao(1103, 732120, "Instalador de linhas elétricas de alta e baixa - tensão (rede aérea e subterrânea)");
        [NotMapped] public static Profissao InstaladorDeMaterialIsolanteAMaoEdificacoes => new Profissao(1104, 715725, "Instalador de material isolante, a mão (edificações)");
        [NotMapped] public static Profissao InstaladorDeMaterialIsolanteAMaquinaEdificacoes => new Profissao(1105, 715730, "Instalador de material isolante, à máquina (edificações)");
        [NotMapped] public static Profissao InstaladorDeSistemasEletroeletronicosDeSeguranca => new Profissao(1106, 951305, "Instalador de sistemas eletroeletrônicos de segurança");
        [NotMapped] public static Profissao InstaladorDeSistemasFotovoltaicos => new Profissao(1107, 732140, "Instalador de sistemas fotovoltaicos");
        [NotMapped] public static Profissao InstaladorDeSomEAcessoriosDeVeiculos => new Profissao(1108, 523110, "Instalador de som e acessórios de veículos");
        [NotMapped] public static Profissao InstaladorDeTubulacoes => new Profissao(1109, 724115, "Instalador de tubulações");
        [NotMapped] public static Profissao InstaladorDeTubulacoesAeronaves => new Profissao(1110, 724120, "Instalador de tubulações (aeronaves)");
        [NotMapped] public static Profissao InstaladorDeTubulacoesEmbarcacoes => new Profissao(1111, 724125, "Instalador de tubulações (embarcações)");
        [NotMapped] public static Profissao InstaladorDeTubulacoesDeGasCombustivelProducaoEDistribuicao => new Profissao(1112, 724130, "Instalador de tubulações de gás combustível (produção e distribuição)");
        [NotMapped] public static Profissao InstaladorDeTubulacoesDeVaporProducaoEDistribuicao => new Profissao(1113, 724135, "Instalador de tubulações de vapor (produção e distribuição)");
        [NotMapped] public static Profissao InstaladorEletricistaTracaoDeVeiculos => new Profissao(1114, 732125, "Instalador eletricista (tração de veículos)");
        [NotMapped] public static Profissao InstaladorReparadorDeEquipamentosDeComutacaoEmTelefonia => new Profissao(1115, 731305, "Instalador-reparador de equipamentos de comutação em telefonia");
        [NotMapped] public static Profissao InstaladorReparadorDeEquipamentosDeEnergiaEmTelefonia => new Profissao(1116, 731310, "Instalador-reparador de equipamentos de energia em telefonia");
        [NotMapped] public static Profissao InstaladorReparadorDeEquipamentosDeTransmissaoEmTelefonia => new Profissao(1117, 731315, "Instalador-reparador de equipamentos de transmissão em telefonia");
        [NotMapped] public static Profissao InstaladorReparadorDeLinhasEAparelhosDeTelecomunicacoes => new Profissao(1118, 731320, "Instalador-reparador de linhas e aparelhos de telecomunicações");
        [NotMapped] public static Profissao InstaladorReparadorDeRedesECabosTelefonicos => new Profissao(1119, 731325, "Instalador-reparador de redes e cabos telefônicos");
        [NotMapped] public static Profissao InstaladorReparadorDeRedesTelefonicasEDeComunicacaoDeDados => new Profissao(1120, 732130, "Instalador-reparador de redes telefônicas e de comunicação de dados");
        [NotMapped] public static Profissao InstrumentadorCirurgico => new Profissao(1121, 322225, "Instrumentador cirúrgico");
        [NotMapped] public static Profissao InstrutorDeAprendizagemETreinamentoAgropecuario => new Profissao(1122, 233205, "Instrutor de aprendizagem e treinamento agropecuário");
        [NotMapped] public static Profissao InstrutorDeAprendizagemETreinamentoComercial => new Profissao(1123, 233215, "Instrutor de aprendizagem e treinamento comercial");
        [NotMapped] public static Profissao InstrutorDeAprendizagemETreinamentoIndustrial => new Profissao(1124, 233210, "Instrutor de aprendizagem e treinamento industrial");
        [NotMapped] public static Profissao InstrutorDeAutoEscola => new Profissao(1125, 333105, "Instrutor de auto-escola");
        [NotMapped] public static Profissao InstrutorDeCursosLivres => new Profissao(1126, 333110, "Instrutor de cursos livres");
        [NotMapped] public static Profissao InstrutorDeVoo => new Profissao(1127, 215315, "Instrutor de vôo");
        [NotMapped] public static Profissao Interprete => new Profissao(1128, 261410, "Intérprete");
        [NotMapped] public static Profissao InterpreteDeLinguaDeSinais => new Profissao(1129, 261425, "Intérprete de língua de sinais");
        [NotMapped] public static Profissao InvestigadorDePolicia => new Profissao(1130, 351810, "Investigador de polícia");
        [NotMapped] public static Profissao Jardineiro => new Profissao(1131, 622010, "Jardineiro");
        [NotMapped] public static Profissao Joalheiro => new Profissao(1132, 751010, "Joalheiro");
        [NotMapped] public static Profissao JoalheiroReparacoes => new Profissao(1133, 751015, "Joalheiro (reparações)");
        [NotMapped] public static Profissao Joquei => new Profissao(1134, 377130, "Jóquei");
        [NotMapped] public static Profissao JornaleiroEmBancaDeJornal => new Profissao(1135, 524210, "Jornaleiro (em banca de jornal)");
        [NotMapped] public static Profissao Jornalista => new Profissao(1136, 261125, "Jornalista");
        [NotMapped] public static Profissao JuizAuditorEstadualJusticaMilitar => new Profissao(1137, 111340, "Juiz auditor estadual - justiça militar");
        [NotMapped] public static Profissao JuizAuditorFederalJusticaMilitar => new Profissao(1138, 111335, "Juiz auditor federal - justiça militar");
        [NotMapped] public static Profissao JuizDeDireito => new Profissao(1139, 111325, "Juiz de direito");
        [NotMapped] public static Profissao JuizDoTrabalho => new Profissao(1140, 111345, "Juiz do trabalho");
        [NotMapped] public static Profissao JuizFederal => new Profissao(1141, 111330, "Juiz federal");
        [NotMapped] public static Profissao Kardexista => new Profissao(1142, 415125, "Kardexista");
        [NotMapped] public static Profissao LaboratoristaFotografico => new Profissao(1143, 766405, "Laboratorista fotográfico");
        [NotMapped] public static Profissao Lagareiro => new Profissao(1144, 841448, "Lagareiro");
        [NotMapped] public static Profissao LaminadorDeMetaisPreciososAMao => new Profissao(1145, 751120, "Laminador de metais preciosos a  mão");
        [NotMapped] public static Profissao LaminadorDePlastico => new Profissao(1146, 811745, "Laminador de plástico");
        [NotMapped] public static Profissao LapidadorJoias => new Profissao(1147, 751020, "Lapidador (jóias)");
        [NotMapped] public static Profissao LapidadorDeVidrosECristais => new Profissao(1148, 752230, "Lapidador de vidros e cristais");
        [NotMapped] public static Profissao LavadeiroEmGeral => new Profissao(1149, 516305, "Lavadeiro, em geral");
        [NotMapped] public static Profissao LavadorDeArtefatosDeTapecaria => new Profissao(1150, 516315, "Lavador de artefatos de tapeçaria");
        [NotMapped] public static Profissao LavadorDeGarrafasVidrosEOutrosUtensilios => new Profissao(1151, 519930, "Lavador de garrafas, vidros e outros utensílios");
        [NotMapped] public static Profissao LavadorDeLa => new Profissao(1152, 761110, "Lavador de lã");
        [NotMapped] public static Profissao LavadorDePecas => new Profissao(1153, 992120, "Lavador de peças");
        [NotMapped] public static Profissao LavadorDeRoupas => new Profissao(1154, 516405, "Lavador de roupas");
        [NotMapped] public static Profissao LavadorDeRoupasAMaquina => new Profissao(1155, 516310, "Lavador de roupas  a maquina");
        [NotMapped] public static Profissao LavadorDeVeiculos => new Profissao(1156, 519935, "Lavador de veículos");
        [NotMapped] public static Profissao Leiloeiro => new Profissao(1157, 354405, "Leiloeiro");
        [NotMapped] public static Profissao Leiturista => new Profissao(1158, 519940, "Leiturista");
        [NotMapped] public static Profissao LiderDeComunidadeCaicara => new Profissao(1159, 113010, "Líder de comunidade caiçara");
        [NotMapped] public static Profissao LiderDeRampaTransporteAereo => new Profissao(1160, 342560, "Lider de rampa ( transporte aéreo)");
        [NotMapped] public static Profissao LigadorDeLinhasTelefonicas => new Profissao(1161, 732135, "Ligador de linhas telefônicas");
        [NotMapped] public static Profissao LimpadorASecoAMaquina => new Profissao(1162, 516320, "Limpador a seco, à máquina");
        [NotMapped] public static Profissao LimpadorDeFachadas => new Profissao(1163, 514315, "Limpador de fachadas");
        [NotMapped] public static Profissao LimpadorDePiscinas => new Profissao(1164, 514330, "Limpador de piscinas");
        [NotMapped] public static Profissao LimpadorDeRoupasASecoAMao => new Profissao(1165, 516410, "Limpador de roupas a seco, à mão");
        [NotMapped] public static Profissao LimpadorDeVidros => new Profissao(1166, 514305, "Limpador de vidros");
        [NotMapped] public static Profissao Lingotador => new Profissao(1167, 722210, "Lingotador");
        [NotMapped] public static Profissao Linguista => new Profissao(1168, 261415, "Lingüista");
        [NotMapped] public static Profissao Linotipista => new Profissao(1169, 768610, "Linotipista");
        [NotMapped] public static Profissao LixadorDeCourosEPeles => new Profissao(1170, 762315, "Lixador de couros e peles");
        [NotMapped] public static Profissao LocalizadorCobrador => new Profissao(1171, 421315, "Localizador (cobrador)");
        [NotMapped] public static Profissao LocutorDeMidiasAudiovisuais => new Profissao(1172, 261715, "Locutor de mídias audiovisuais");
        [NotMapped] public static Profissao LubrificadorDeEmbarcacoes => new Profissao(1173, 919115, "Lubrificador de embarcações");
        [NotMapped] public static Profissao LubrificadorDeVeiculosAutomotoresExcetoEmbarcacoes => new Profissao(1174, 919110, "Lubrificador de veículos automotores (exceto embarcações)");
        [NotMapped] public static Profissao LubrificadorIndustrial => new Profissao(1175, 919105, "Lubrificador industrial");
        [NotMapped] public static Profissao Ludomotricista => new Profissao(1176, 224110, "Ludomotricista");
        [NotMapped] public static Profissao LustradorDePecasDeMadeira => new Profissao(1177, 775115, "Lustrador de peças de madeira");
        [NotMapped] public static Profissao LustradorDePiso => new Profissao(1178, 716520, "Lustrador de piso");
        [NotMapped] public static Profissao LuthierRestauracaoDeCordasArcadas => new Profissao(1179, 915215, "Luthier (restauração de cordas arcadas)");
        [NotMapped] public static Profissao MacheiroAMaquina => new Profissao(1180, 722310, "Macheiro, a  máquina");
        [NotMapped] public static Profissao MacheiroAMao => new Profissao(1181, 722305, "Macheiro, a mão");
        [NotMapped] public static Profissao MaeSocial => new Profissao(1182, 516215, "Mãe social");
        [NotMapped] public static Profissao Magarefe => new Profissao(1183, 848520, "Magarefe");
        [NotMapped] public static Profissao Magico => new Profissao(1184, 376235, "Mágico");
        [NotMapped] public static Profissao Maitre => new Profissao(1185, 510135, "Maître");
        [NotMapped] public static Profissao MajorBombeiroMilitar => new Profissao(1186, 30110, "Major bombeiro militar");
        [NotMapped] public static Profissao MajorDaPoliciaMilitar => new Profissao(1187, 20115, "Major da polícia militar");
        [NotMapped] public static Profissao Malabarista => new Profissao(1188, 376240, "Malabarista");
        [NotMapped] public static Profissao MalteiroGerminacao => new Profissao(1189, 841725, "Malteiro (germinação)");
        [NotMapped] public static Profissao Manicure => new Profissao(1190, 516120, "Manicure");
        [NotMapped] public static Profissao Manobrador => new Profissao(1191, 783110, "Manobrador");
        [NotMapped] public static Profissao ManteigueiroNaFabricacaoDeLaticinio => new Profissao(1192, 848215, "Manteigueiro na fabricação de laticínio");
        [NotMapped] public static Profissao MantenedorDeEquipamentosDeParquesDeDiversoesESimilares => new Profissao(1193, 991205, "Mantenedor de equipamentos de parques de diversões e similares");
        [NotMapped] public static Profissao MantenedorDeSistemasEletroeletronicosDeSeguranca => new Profissao(1194, 951310, "Mantenedor de sistemas eletroeletrônicos de segurança");
        [NotMapped] public static Profissao MaquetistaNaMarcenaria => new Profissao(1195, 771115, "Maquetista na marcenaria");
        [NotMapped] public static Profissao Maquiador => new Profissao(1196, 516125, "Maquiador");
        [NotMapped] public static Profissao MaquiadorDeCaracterizacao => new Profissao(1197, 516130, "Maquiador de caracterização");
        [NotMapped] public static Profissao MaquinistaDeCinemaEVideo => new Profissao(1198, 374210, "Maquinista de cinema e vídeo");
        [NotMapped] public static Profissao MaquinistaDeEmbarcacoes => new Profissao(1199, 862110, "Maquinista de embarcações");
        [NotMapped] public static Profissao MaquinistaDeTeatroEEspetaculos => new Profissao(1200, 374215, "Maquinista de teatro e espetáculos");
        [NotMapped] public static Profissao MaquinistaDeTrem => new Profissao(1201, 782610, "Maquinista de trem");
        [NotMapped] public static Profissao MaquinistaDeTremMetropolitano => new Profissao(1202, 782615, "Maquinista de trem metropolitano");
        [NotMapped] public static Profissao MarcadorDePecasConfeccionadasParaBordar => new Profissao(1203, 763315, "Marcador de peças confeccionadas para bordar");
        [NotMapped] public static Profissao MarcadorDeProdutosSiderurgicoEMetalurgico => new Profissao(1204, 821415, "Marcador de produtos (siderúrgico e metalúrgico)");
        [NotMapped] public static Profissao Marceneiro => new Profissao(1205, 771105, "Marceneiro");
        [NotMapped] public static Profissao Marcheteiro => new Profissao(1206, 775120, "Marcheteiro");
        [NotMapped] public static Profissao MarinheiroAuxiliarDeConvesMaritimoEAquaviario => new Profissao(1207, 782730, "Marinheiro auxiliar de convés (marítimo e aquaviario)");
        [NotMapped] public static Profissao MarinheiroAuxiliarDeMaquinasMaritimoEAquaviario => new Profissao(1208, 782735, "Marinheiro auxiliar de máquinas (marítimo e aquaviário)");
        [NotMapped] public static Profissao MarinheiroDeConvesMaritimoEFluviario => new Profissao(1209, 782705, "Marinheiro de convés (marítimo e fluviário)");
        [NotMapped] public static Profissao MarinheiroDeEsporteERecreio => new Profissao(1210, 782725, "Marinheiro de esporte e recreio");
        [NotMapped] public static Profissao MarinheiroDeMaquinas => new Profissao(1211, 782710, "Marinheiro de máquinas");
        [NotMapped] public static Profissao MarmoristaConstrucao => new Profissao(1212, 716525, "Marmorista (construção)");
        [NotMapped] public static Profissao MasseiroMassasAlimenticias => new Profissao(1213, 848315, "Masseiro (massas alimentícias)");
        [NotMapped] public static Profissao Massoterapeuta => new Profissao(1214, 322120, "Massoterapeuta");
        [NotMapped] public static Profissao Matematico => new Profissao(1215, 211115, "Matemático");
        [NotMapped] public static Profissao MatematicoAplicado => new Profissao(1216, 211120, "Matemático aplicado");
        [NotMapped] public static Profissao MatizadorDeCourosEPeles => new Profissao(1217, 762320, "Matizador de couros e peles");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeAeronavesEmGeral => new Profissao(1218, 914105, "Mecânico de manutenção de aeronaves, em geral");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeAparelhosDeLevantamento => new Profissao(1219, 913105, "Mecânico de manutenção de aparelhos de levantamento");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeAparelhosEsportivosEDeGinastica => new Profissao(1220, 919305, "Mecânico de manutenção de aparelhos esportivos e de ginástica");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeAutomoveisMotocicletasEVeiculosSimilares => new Profissao(1221, 914405, "Mecânico de manutenção de automóveis, motocicletas e veículos similares");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeBicicletasEVeiculosSimilares => new Profissao(1222, 919310, "Mecânico de manutenção de bicicletas e veículos similares");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeBombaInjetoraExcetoDeVeiculosAutomotores => new Profissao(1223, 911105, "Mecânico de manutenção de bomba injetora (exceto de veículos automotores)");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeBombas => new Profissao(1224, 911110, "Mecânico de manutenção de bombas");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeCompressoresDeAr => new Profissao(1225, 911115, "Mecânico de manutenção de compressores de ar");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeEmpilhadeirasEOutrosVeiculosDeCargasLeves => new Profissao(1226, 914410, "Mecânico de manutenção de empilhadeiras e outros veículos de cargas leves");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeEquipamentoDeMineracao => new Profissao(1227, 913110, "Mecânico de manutenção de equipamento de mineração");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeInstalacoesMecanicasDeEdificios => new Profissao(1228, 954120, "Mecânico de manutenção de instalações mecânicas de edifícios");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMaquinasAgricolas => new Profissao(1229, 913115, "Mecânico de manutenção de máquinas agrícolas");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMaquinasCortadorasDeGramaRocadeirasMotosserrasESimilares => new Profissao(1230, 919205, "Mecânico de manutenção de máquinas cortadoras de grama, roçadeiras, motosserras e similares");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMaquinasDeConstrucaoETerraplenagem => new Profissao(1231, 913120, "Mecânico de manutenção de máquinas de construção e terraplenagem");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMaquinasGraficas => new Profissao(1232, 911310, "Mecânico de manutenção de máquinas gráficas");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMaquinasOperatrizesLavraDeMadeira => new Profissao(1233, 911315, "Mecânico de manutenção de máquinas operatrizes (lavra de madeira)");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMaquinasTexteis => new Profissao(1234, 911320, "Mecânico de manutenção de máquinas têxteis");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMaquinasEmGeral => new Profissao(1235, 911305, "Mecânico de manutenção de máquinas, em geral");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMaquinasFerramentasUsinagemDeMetais => new Profissao(1236, 911325, "Mecânico de manutenção de máquinas-ferramentas (usinagem de metais)");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMotocicletas => new Profissao(1237, 914415, "Mecânico de manutenção de motocicletas");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMotoresDieselExcetoDeVeiculosAutomotores => new Profissao(1238, 911120, "Mecânico de manutenção de motores diesel (exceto de veículos automotores)");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeMotoresEEquipamentosNavais => new Profissao(1239, 914205, "Mecânico de manutenção de motores e equipamentos navais");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeRedutores => new Profissao(1240, 911125, "Mecânico de manutenção de redutores");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeSistemaHidraulicoDeAeronavesServicosDePistaEHangar => new Profissao(1241, 914110, "Mecânico de manutenção de sistema hidráulico de aeronaves (serviços de pista e hangar)");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeTratores => new Profissao(1242, 914420, "Mecânico de manutenção de tratores");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeTurbinasExcetoDeAeronaves => new Profissao(1243, 911130, "Mecânico de manutenção de turbinas (exceto de aeronaves)");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeTurbocompressores => new Profissao(1244, 911135, "Mecânico de manutenção de turbocompressores");
        [NotMapped] public static Profissao MecanicoDeManutencaoDeVeiculosFerroviarios => new Profissao(1245, 914305, "Mecânico de manutenção de veículos ferroviários");
        [NotMapped] public static Profissao MecanicoDeManutencaoEInstalacaoDeAparelhosDeClimatizacaoERefrigeracao => new Profissao(1246, 911205, "Mecânico de manutenção e instalação de aparelhos de climatização e  refrigeração");
        [NotMapped] public static Profissao MecanicoDeRefrigeracao => new Profissao(1247, 725705, "Mecânico de refrigeração");
        [NotMapped] public static Profissao MecanicoDeVeiculosAutomotoresADieselExcetoTratores => new Profissao(1248, 914425, "Mecânico de veículos automotores a diesel (exceto tratores)");
        [NotMapped] public static Profissao MecanicoDeVoo => new Profissao(1249, 341115, "Mecânico de vôo");
        [NotMapped] public static Profissao MecanicoMontadorDeMotoresDeAeronaves => new Profissao(1250, 725405, "Mecânico montador de motores de aeronaves");
        [NotMapped] public static Profissao MecanicoMontadorDeMotoresDeEmbarcacoes => new Profissao(1251, 725410, "Mecânico montador de motores de embarcações");
        [NotMapped] public static Profissao MecanicoMontadorDeMotoresDeExplosaoEDiesel => new Profissao(1252, 725415, "Mecânico montador de motores de explosão e diesel");
        [NotMapped] public static Profissao MecanicoMontadorDeTurboalimentadores => new Profissao(1253, 725420, "Mecânico montador de turboalimentadores");
        [NotMapped] public static Profissao MediadorExtrajudicial => new Profissao(1254, 351435, "Mediador extrajudicial");
        [NotMapped] public static Profissao MedicoAcupunturista => new Profissao(1255, 225105, "Médico acupunturista");
        [NotMapped] public static Profissao MedicoAlergistaEImunologista => new Profissao(1256, 225110, "Médico alergista e imunologista");
        [NotMapped] public static Profissao MedicoAnatomopatologista => new Profissao(1257, 225148, "Médico anatomopatologista");
        [NotMapped] public static Profissao MedicoAnestesiologista => new Profissao(1258, 225151, "Médico anestesiologista");
        [NotMapped] public static Profissao MedicoAngiologista => new Profissao(1259, 225115, "Médico angiologista");
        [NotMapped] public static Profissao MedicoAntroposofico => new Profissao(1260, 225154, "Médico antroposófico");
        [NotMapped] public static Profissao MedicoCancerologistaCirurgico => new Profissao(1261, 225290, "Médico cancerologista cirurgíco");
        [NotMapped] public static Profissao MedicoCancerologistaPediatrico => new Profissao(1262, 225122, "Médico cancerologista pediátrico");
        [NotMapped] public static Profissao MedicoCardiologista => new Profissao(1263, 225120, "Médico cardiologista");
        [NotMapped] public static Profissao MedicoCirurgiaoCardiovascular => new Profissao(1264, 225210, "Médico cirurgião cardiovascular");
        [NotMapped] public static Profissao MedicoCirurgiaoDaMao => new Profissao(1265, 225295, "Médico cirurgião da mão");
        [NotMapped] public static Profissao MedicoCirurgiaoDeCabecaEPescoco => new Profissao(1266, 225215, "Médico cirurgião de cabeça e pescoço");
        [NotMapped] public static Profissao MedicoCirurgiaoDoAparelhoDigestivo => new Profissao(1267, 225220, "Médico cirurgião do aparelho digestivo");
        [NotMapped] public static Profissao MedicoCirurgiaoGeral => new Profissao(1268, 225225, "Médico cirurgião geral");
        [NotMapped] public static Profissao MedicoCirurgiaoPediatrico => new Profissao(1269, 225230, "Médico cirurgião pediátrico");
        [NotMapped] public static Profissao MedicoCirurgiaoPlastico => new Profissao(1270, 225235, "Médico cirurgião plástico");
        [NotMapped] public static Profissao MedicoCirurgiaoToracico => new Profissao(1271, 225240, "Médico cirurgião torácico");
        [NotMapped] public static Profissao MedicoCitopatologista => new Profissao(1272, 225305, "Médico citopatologista");
        [NotMapped] public static Profissao MedicoClinico => new Profissao(1273, 225125, "Médico clínico");
        [NotMapped] public static Profissao MedicoColoproctologista => new Profissao(1274, 225280, "Médico coloproctologista");
        [NotMapped] public static Profissao MedicoDaEstrategiaDeSaudeDaFamilia => new Profissao(1275, 225142, "Médico da estratégia de saúde da família");
        [NotMapped] public static Profissao MedicoDeFamiliaEComunidade => new Profissao(1276, 225130, "Médico de família e comunidade");
        [NotMapped] public static Profissao MedicoDermatologista => new Profissao(1277, 225135, "Médico dermatologista");
        [NotMapped] public static Profissao MedicoDoTrabalho => new Profissao(1278, 225140, "Médico do trabalho");
        [NotMapped] public static Profissao MedicoEmCirurgiaVascular => new Profissao(1279, 225203, "Médico em cirurgia vascular");
        [NotMapped] public static Profissao MedicoEmEndoscopia => new Profissao(1280, 225310, "Médico em endoscopia");
        [NotMapped] public static Profissao MedicoEmMedicinaDeTrafego => new Profissao(1281, 225145, "Médico em medicina de tráfego");
        [NotMapped] public static Profissao MedicoEmMedicinaIntensiva => new Profissao(1282, 225150, "Médico em medicina intensiva");
        [NotMapped] public static Profissao MedicoEmMedicinaNuclear => new Profissao(1283, 225315, "Médico em medicina nuclear");
        [NotMapped] public static Profissao MedicoEmRadiologiaEDiagnosticoPorImagem => new Profissao(1284, 225320, "Médico em radiologia e diagnóstico por imagem");
        [NotMapped] public static Profissao MedicoEndocrinologistaEMetabologista => new Profissao(1285, 225155, "Médico endocrinologista e metabologista");
        [NotMapped] public static Profissao MedicoFisiatra => new Profissao(1286, 225160, "Médico fisiatra");
        [NotMapped] public static Profissao MedicoGastroenterologista => new Profissao(1287, 225165, "Médico gastroenterologista");
        [NotMapped] public static Profissao MedicoGeneralista => new Profissao(1288, 225170, "Médico generalista");
        [NotMapped] public static Profissao MedicoGeneticista => new Profissao(1289, 225175, "Médico geneticista");
        [NotMapped] public static Profissao MedicoGeriatra => new Profissao(1290, 225180, "Médico geriatra");
        [NotMapped] public static Profissao MedicoGinecologistaEObstetra => new Profissao(1291, 225250, "Médico ginecologista e obstetra");
        [NotMapped] public static Profissao MedicoHematologista => new Profissao(1292, 225185, "Médico hematologista");
        [NotMapped] public static Profissao MedicoHemoterapeuta => new Profissao(1293, 225340, "Médico hemoterapeuta");
        [NotMapped] public static Profissao MedicoHiperbarista => new Profissao(1294, 225345, "Médico hiperbarista");
        [NotMapped] public static Profissao MedicoHomeopata => new Profissao(1295, 225195, "Médico homeopata");
        [NotMapped] public static Profissao MedicoInfectologista => new Profissao(1296, 225103, "Médico infectologista");
        [NotMapped] public static Profissao MedicoLegista => new Profissao(1297, 225106, "Médico legista");
        [NotMapped] public static Profissao MedicoMastologista => new Profissao(1298, 225255, "Médico mastologista");
        [NotMapped] public static Profissao MedicoNefrologista => new Profissao(1299, 225109, "Médico nefrologista");
        [NotMapped] public static Profissao MedicoNeurocirurgiao => new Profissao(1300, 225260, "Médico neurocirurgião");
        [NotMapped] public static Profissao MedicoNeurofisiologistaClinico => new Profissao(1301, 225350, "Médico neurofisiologista clínico");
        [NotMapped] public static Profissao MedicoNeurologista => new Profissao(1302, 225112, "Médico neurologista");
        [NotMapped] public static Profissao MedicoNutrologista => new Profissao(1303, 225118, "Médico nutrologista");
        [NotMapped] public static Profissao MedicoOftalmologista => new Profissao(1304, 225265, "Médico oftalmologista");
        [NotMapped] public static Profissao MedicoOncologistaClinico => new Profissao(1305, 225121, "Médico oncologista clínico");
        [NotMapped] public static Profissao MedicoOrtopedistaETraumatologista => new Profissao(1306, 225270, "Médico ortopedista e traumatologista");
        [NotMapped] public static Profissao MedicoOtorrinolaringologista => new Profissao(1307, 225275, "Médico otorrinolaringologista");
        [NotMapped] public static Profissao MedicoPatologista => new Profissao(1308, 225325, "Médico patologista");
        [NotMapped] public static Profissao MedicoPatologistaClinicoMedicinaLaboratorial => new Profissao(1309, 225335, "Médico patologista clínico / medicina laboratorial");
        [NotMapped] public static Profissao MedicoPediatra => new Profissao(1310, 225124, "Médico pediatra");
        [NotMapped] public static Profissao MedicoPneumologista => new Profissao(1311, 225127, "Médico pneumologista");
        [NotMapped] public static Profissao MedicoPsiquiatra => new Profissao(1312, 225133, "Médico psiquiatra");
        [NotMapped] public static Profissao MedicoRadiologistaIntervencionista => new Profissao(1313, 225355, "Médico radiologista intervencionista");
        [NotMapped] public static Profissao MedicoRadioterapeuta => new Profissao(1314, 225330, "Médico radioterapeuta");
        [NotMapped] public static Profissao MedicoReumatologista => new Profissao(1315, 225136, "Médico reumatologista");
        [NotMapped] public static Profissao MedicoSanitarista => new Profissao(1316, 225139, "Médico sanitarista");
        [NotMapped] public static Profissao MedicoUrologista => new Profissao(1317, 225285, "Médico urologista");
        [NotMapped] public static Profissao MedicoVeterinario => new Profissao(1318, 223305, "Médico veterinário");
        [NotMapped] public static Profissao MembroDeLiderancaQuilombola => new Profissao(1319, 113015, "Membro de liderança quilombola");
        [NotMapped] public static Profissao MembroSuperiorDoPoderExecutivo => new Profissao(1320, 111225, "Membro superior do poder executivo");
        [NotMapped] public static Profissao MergulhadorProfissionalRasoEProfundo => new Profissao(1321, 781705, "Mergulhador profissional (raso e profundo)");
        [NotMapped] public static Profissao MestreAfiadorDeFerramentas => new Profissao(1322, 720105, "Mestre (afiador de ferramentas)");
        [NotMapped] public static Profissao MestreConstrucaoCivil => new Profissao(1323, 710205, "Mestre (construção civil)");
        [NotMapped] public static Profissao MestreConstrucaoNaval => new Profissao(1324, 720205, "Mestre (construção naval)");
        [NotMapped] public static Profissao MestreIndustriaDeAutomotoresEMaterialDeTransportes => new Profissao(1325, 720210, "Mestre (indústria de automotores e material de transportes)");
        [NotMapped] public static Profissao MestreIndustriaDeBorrachaEPlastico => new Profissao(1326, 810205, "Mestre (indústria de borracha e plástico)");
        [NotMapped] public static Profissao MestreIndustriaDeCelulosePapelEPapelao => new Profissao(1327, 830105, "Mestre (indústria de celulose, papel e papelão)");
        [NotMapped] public static Profissao MestreIndustriaDeMadeiraEMobiliario => new Profissao(1328, 770105, "Mestre (indústria de madeira e mobiliário)");
        [NotMapped] public static Profissao MestreIndustriaDeMaquinasEOutrosEquipamentosMecanicos => new Profissao(1329, 720215, "Mestre (indústria de máquinas e outros equipamentos mecânicos)");
        [NotMapped] public static Profissao MestreIndustriaPetroquimicaECarboquimica => new Profissao(1330, 810105, "Mestre (indústria petroquímica e carboquímica)");
        [NotMapped] public static Profissao MestreIndustriaTextilEDeConfeccoes => new Profissao(1331, 760125, "Mestre (indústria têxtil e de confecções)");
        [NotMapped] public static Profissao MestreCarpinteiro => new Profissao(1332, 770110, "Mestre carpinteiro");
        [NotMapped] public static Profissao MestreDeAciaria => new Profissao(1333, 820110, "Mestre de aciaria");
        [NotMapped] public static Profissao MestreDeAltoForno => new Profissao(1334, 820115, "Mestre de alto-forno");
        [NotMapped] public static Profissao MestreDeCabotagem => new Profissao(1335, 341210, "Mestre de cabotagem");
        [NotMapped] public static Profissao MestreDeCaldeiraria => new Profissao(1336, 720110, "Mestre de caldeiraria");
        [NotMapped] public static Profissao MestreDeCerimonias => new Profissao(1337, 376330, "Mestre de cerimonias");
        [NotMapped] public static Profissao MestreDeConstrucaoDeFornos => new Profissao(1338, 720220, "Mestre de construção de fornos");
        [NotMapped] public static Profissao MestreDeFerramentaria => new Profissao(1339, 720115, "Mestre de ferramentaria");
        [NotMapped] public static Profissao MestreDeForjaria => new Profissao(1340, 720120, "Mestre de forjaria");
        [NotMapped] public static Profissao MestreDeFornoEletrico => new Profissao(1341, 820120, "Mestre de forno elétrico");
        [NotMapped] public static Profissao MestreDeFundicao => new Profissao(1342, 720125, "Mestre de fundição");
        [NotMapped] public static Profissao MestreDeGalvanoplastia => new Profissao(1343, 720130, "Mestre de galvanoplastia");
        [NotMapped] public static Profissao MestreDeLaminacao => new Profissao(1344, 820125, "Mestre de laminação");
        [NotMapped] public static Profissao MestreDeLinhasFerrovias => new Profissao(1345, 710210, "Mestre de linhas (ferrovias)");
        [NotMapped] public static Profissao MestreDePinturaTratamentoDeSuperficies => new Profissao(1346, 720135, "Mestre de pintura (tratamento de superfícies)");
        [NotMapped] public static Profissao MestreDeProducaoFarmaceutica => new Profissao(1347, 810305, "Mestre de produção farmacêutica");
        [NotMapped] public static Profissao MestreDeProducaoQuimica => new Profissao(1348, 810110, "Mestre de produção química");
        [NotMapped] public static Profissao MestreDeSiderurgia => new Profissao(1349, 820105, "Mestre de siderurgia");
        [NotMapped] public static Profissao MestreDeSoldagem => new Profissao(1350, 720140, "Mestre de soldagem");
        [NotMapped] public static Profissao MestreDeTrefilacaoDeMetais => new Profissao(1351, 720145, "Mestre de trefilação de metais");
        [NotMapped] public static Profissao MestreDeUsinagem => new Profissao(1352, 720150, "Mestre de usinagem");
        [NotMapped] public static Profissao MestreFluvial => new Profissao(1353, 341215, "Mestre fluvial");
        [NotMapped] public static Profissao MestreSerralheiro => new Profissao(1354, 720155, "Mestre serralheiro");
        [NotMapped] public static Profissao MetalizadorBanhoQuente => new Profissao(1355, 723225, "Metalizador (banho quente)");
        [NotMapped] public static Profissao MetalizadorAPistola => new Profissao(1356, 723220, "Metalizador a pistola");
        [NotMapped] public static Profissao Meteorologista => new Profissao(1357, 213315, "Meteorologista");
        [NotMapped] public static Profissao Metrologista => new Profissao(1358, 352305, "Metrologista");
        [NotMapped] public static Profissao Microfonista => new Profissao(1359, 374140, "Microfonista");
        [NotMapped] public static Profissao Mineiro => new Profissao(1360, 711130, "Mineiro");
        [NotMapped] public static Profissao Minhocultor => new Profissao(1361, 613415, "Minhocultor");
        [NotMapped] public static Profissao MinistroDeCultoReligioso => new Profissao(1362, 263105, "Ministro de culto religioso");
        [NotMapped] public static Profissao MinistroDeEstado => new Profissao(1363, 111215, "Ministro de estado");
        [NotMapped] public static Profissao MinistroDoSuperiorTribunalDoTrabalho => new Profissao(1364, 111320, "Ministro do  superior tribunal do trabalho");
        [NotMapped] public static Profissao MinistroDoSuperiorTribunalMilitar => new Profissao(1365, 111315, "Ministro do  superior tribunal militar");
        [NotMapped] public static Profissao MinistroDoSuperiorTribunalDeJustica => new Profissao(1366, 111310, "Ministro do superior tribunal de justiça");
        [NotMapped] public static Profissao MinistroDoSupremoTribunalFederal => new Profissao(1367, 111305, "Ministro do supremo tribunal federal");
        [NotMapped] public static Profissao Missionario => new Profissao(1368, 263110, "Missionário");
        [NotMapped] public static Profissao MisturadorDeCafe => new Profissao(1369, 841605, "Misturador de café");
        [NotMapped] public static Profissao MisturadorDeChaOuMate => new Profissao(1370, 841630, "Misturador de chá ou mate");
        [NotMapped] public static Profissao MocoDeConvesMaritimoEFluviario => new Profissao(1371, 782715, "Moço de convés (marítimo e fluviário)");
        [NotMapped] public static Profissao MocoDeMaquinasMaritimoEFluviario => new Profissao(1372, 782720, "Moço de máquinas (marítimo e fluviário)");
        [NotMapped] public static Profissao ModeladorDeMadeira => new Profissao(1373, 771110, "Modelador de madeira");
        [NotMapped] public static Profissao ModeladorDeMetaisFundicao => new Profissao(1374, 721115, "Modelador de metais (fundição)");
        [NotMapped] public static Profissao ModelistaDeCalcados => new Profissao(1375, 318815, "Modelista de calçados");
        [NotMapped] public static Profissao ModelistaDeRoupas => new Profissao(1376, 318810, "Modelista de roupas");
        [NotMapped] public static Profissao ModeloArtistico => new Profissao(1377, 376405, "Modelo artístico");
        [NotMapped] public static Profissao ModeloDeModas => new Profissao(1378, 376410, "Modelo de modas");
        [NotMapped] public static Profissao ModeloPublicitario => new Profissao(1379, 376415, "Modelo publicitário");
        [NotMapped] public static Profissao MoedorDeCafe => new Profissao(1380, 841615, "Moedor de café");
        [NotMapped] public static Profissao MoedorDeSal => new Profissao(1381, 841205, "Moedor de sal");
        [NotMapped] public static Profissao MoldadorVidros => new Profissao(1382, 752110, "Moldador (vidros)");
        [NotMapped] public static Profissao MoldadorDeAbrasivosNaFabricacaoDeCeramicaVidroEPorcelana => new Profissao(1383, 823230, "Moldador de abrasivos na fabricação de cerâmica, vidro e porcelana");
        [NotMapped] public static Profissao MoldadorDeBorrachaPorCompressao => new Profissao(1384, 811750, "Moldador de borracha por compressão");
        [NotMapped] public static Profissao MoldadorDeCorposDeProvaEmUsinasDeConcreto => new Profissao(1385, 715310, "Moldador de corpos de prova em usinas de concreto");
        [NotMapped] public static Profissao MoldadorDePlasticoPorCompressao => new Profissao(1386, 811760, "Moldador de plástico por compressão");
        [NotMapped] public static Profissao MoldadorDePlasticoPorInjecao => new Profissao(1387, 811770, "Moldador de plástico por injeção");
        [NotMapped] public static Profissao MoldadorAMao => new Profissao(1388, 722315, "Moldador, a  mão");
        [NotMapped] public static Profissao MoldadorAMaquina => new Profissao(1389, 722320, "Moldador, a  máquina");
        [NotMapped] public static Profissao MoleiroTratamentosQuimicosEAfins => new Profissao(1390, 811105, "Moleiro (tratamentos químicos e afins)");
        [NotMapped] public static Profissao MoleiroDeCereaisExcetoArroz => new Profissao(1391, 841105, "Moleiro de cereais (exceto arroz)");
        [NotMapped] public static Profissao MoleiroDeEspeciarias => new Profissao(1392, 841110, "Moleiro de especiarias");
        [NotMapped] public static Profissao MoleiroDeMinerios => new Profissao(1393, 712105, "Moleiro de minérios");
        [NotMapped] public static Profissao MonitorDeDependenteQuimico => new Profissao(1394, 515315, "Monitor de dependente químico");
        [NotMapped] public static Profissao MonitorDeRessocializacaoPrisional => new Profissao(1395, 515330, "Monitor de ressocialização prisional");
        [NotMapped] public static Profissao MonitorDeSistemasEletronicosDeSegurancaExterno => new Profissao(1396, 951320, "Monitor de sistemas eletrônicos de segurança externo");
        [NotMapped] public static Profissao MonitorDeSistemasEletronicosDeSegurancaInterno => new Profissao(1397, 951315, "Monitor de sistemas eletrônicos de segurança interno");
        [NotMapped] public static Profissao MonitorDeTeleatendimento => new Profissao(1398, 422335, "Monitor de teleatendimento");
        [NotMapped] public static Profissao MonitorDeTransporteEscolar => new Profissao(1399, 334115, "Monitor de transporte escolar");
        [NotMapped] public static Profissao Monotipista => new Profissao(1400, 768615, "Monotipista");
        [NotMapped] public static Profissao MontadorDeAndaimesEdificacoes => new Profissao(1401, 715545, "Montador de andaimes (edificações)");
        [NotMapped] public static Profissao MontadorDeArtefatosDeCouroExcetoRoupasECalcados => new Profissao(1402, 765315, "Montador de artefatos de couro (exceto roupas e calçados)");
        [NotMapped] public static Profissao MontadorDeBicicletas => new Profissao(1403, 919315, "Montador de bicicletas");
        [NotMapped] public static Profissao MontadorDeCalcados => new Profissao(1404, 764210, "Montador de calçados");
        [NotMapped] public static Profissao MontadorDeEquipamentoDeLevantamento => new Profissao(1405, 725305, "Montador de equipamento de levantamento");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletricos => new Profissao(1406, 731135, "Montador de equipamentos elétricos");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletricosAparelhosEletrodomesticos => new Profissao(1407, 731120, "Montador de equipamentos elétricos (aparelhos eletrodomésticos)");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletricosCentraisEletricas => new Profissao(1408, 731125, "Montador de equipamentos elétricos (centrais elétricas)");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletricosElevadoresEEquipamentosSimilares => new Profissao(1409, 731155, "Montador de equipamentos elétricos (elevadores e equipamentos similares)");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletricosInstrumentosDeMedicao => new Profissao(1410, 731115, "Montador de equipamentos elétricos (instrumentos de medição)");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletricosMotoresEDinamos => new Profissao(1411, 731130, "Montador de equipamentos elétricos (motores e dínamos)");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletricosTransformadores => new Profissao(1412, 731160, "Montador de equipamentos elétricos (transformadores)");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletronicos => new Profissao(1413, 731150, "Montador de equipamentos eletrônicos");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletronicosAparelhosMedicos => new Profissao(1414, 731105, "Montador de equipamentos eletrônicos (aparelhos médicos)");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletronicosComputadoresEEquipamentosAuxiliares => new Profissao(1415, 731110, "Montador de equipamentos eletrônicos (computadores e equipamentos auxiliares)");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletronicosEstacaoDeRadioTvEEquipamentosDeRadar => new Profissao(1416, 731205, "Montador de equipamentos eletrônicos (estação de rádio, tv e equipamentos de radar)");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletronicosInstalacoesDeSinalizacao => new Profissao(1417, 731140, "Montador de equipamentos eletrônicos (instalações de sinalização)");
        [NotMapped] public static Profissao MontadorDeEquipamentosEletronicosMaquinasIndustriais => new Profissao(1418, 731145, "Montador de equipamentos eletrônicos (máquinas industriais)");
        [NotMapped] public static Profissao MontadorDeEstruturasDeAeronaves => new Profissao(1419, 725605, "Montador de estruturas de aeronaves");
        [NotMapped] public static Profissao MontadorDeEstruturasMetalicas => new Profissao(1420, 724205, "Montador de estruturas metálicas");
        [NotMapped] public static Profissao MontadorDeEstruturasMetalicasDeEmbarcacoes => new Profissao(1421, 724210, "Montador de estruturas metálicas de embarcações");
        [NotMapped] public static Profissao MontadorDeFilmes => new Profissao(1422, 374420, "Montador de filmes");
        [NotMapped] public static Profissao MontadorDeFotolitoAnalogicoEDigital => new Profissao(1423, 766125, "Montador de fotolito (analógico e digital)");
        [NotMapped] public static Profissao MontadorDeInstrumentosDeOptica => new Profissao(1424, 741110, "Montador de instrumentos de óptica");
        [NotMapped] public static Profissao MontadorDeInstrumentosDePrecisao => new Profissao(1425, 741115, "Montador de instrumentos de precisão");
        [NotMapped] public static Profissao MontadorDeMaquinas => new Profissao(1426, 725205, "Montador de máquinas");
        [NotMapped] public static Profissao MontadorDeMaquinasAgricolas => new Profissao(1427, 725310, "Montador de máquinas agrícolas");
        [NotMapped] public static Profissao MontadorDeMaquinasDeMinasEPedreiras => new Profissao(1428, 725315, "Montador de máquinas de minas e pedreiras");
        [NotMapped] public static Profissao MontadorDeMaquinasDeTerraplenagem => new Profissao(1429, 725320, "Montador de máquinas de terraplenagem");
        [NotMapped] public static Profissao MontadorDeMaquinasGraficas => new Profissao(1430, 725210, "Montador de máquinas gráficas");
        [NotMapped] public static Profissao MontadorDeMaquinasOperatrizesParaMadeira => new Profissao(1431, 725215, "Montador de máquinas operatrizes para madeira");
        [NotMapped] public static Profissao MontadorDeMaquinasTexteis => new Profissao(1432, 725220, "Montador de máquinas têxteis");
        [NotMapped] public static Profissao MontadorDeMaquinasMotoresEAcessoriosMontagemEmSerie => new Profissao(1433, 725105, "Montador de máquinas, motores e acessórios (montagem em série)");
        [NotMapped] public static Profissao MontadorDeMaquinasFerramentasUsinagemDeMetais => new Profissao(1434, 725225, "Montador de máquinas-ferramentas (usinagem de metais)");
        [NotMapped] public static Profissao MontadorDeMoveisEArtefatosDeMadeira => new Profissao(1435, 774105, "Montador de móveis e artefatos de madeira");
        [NotMapped] public static Profissao MontadorDeSistemasDeCombustivelDeAeronaves => new Profissao(1436, 725610, "Montador de sistemas de combustível de aeronaves");
        [NotMapped] public static Profissao MontadorDeVeiculosLinhaDeMontagem => new Profissao(1437, 725505, "Montador de veículos (linha de montagem)");
        [NotMapped] public static Profissao MontadorDeVeiculosReparacao => new Profissao(1438, 991310, "Montador de veículos (reparação)");
        [NotMapped] public static Profissao MordomoDeHotelaria => new Profissao(1439, 513110, "Mordomo de hotelaria");
        [NotMapped] public static Profissao MordomoDeResidencia => new Profissao(1440, 513105, "Mordomo de residência");
        [NotMapped] public static Profissao Mosaista => new Profissao(1441, 716530, "Mosaísta");
        [NotMapped] public static Profissao Motofretista => new Profissao(1442, 519110, "Motofretista");
        [NotMapped] public static Profissao MotoristaDeCaminhaoRotasRegionaisEInternacionais => new Profissao(1443, 782510, "Motorista de caminhão (rotas regionais e internacionais)");
        [NotMapped] public static Profissao MotoristaDeCarroDePasseio => new Profissao(1444, 782305, "Motorista de carro de passeio");
        [NotMapped] public static Profissao MotoristaDeFurgaoOuVeiculoSimilar => new Profissao(1445, 782310, "Motorista de furgão ou veículo similar");
        [NotMapped] public static Profissao MotoristaDeOnibusRodoviario => new Profissao(1446, 782405, "Motorista de ônibus rodoviário");
        [NotMapped] public static Profissao MotoristaDeOnibusUrbano => new Profissao(1447, 782410, "Motorista de ônibus urbano");
        [NotMapped] public static Profissao MotoristaDeTaxi => new Profissao(1448, 782315, "Motorista de táxi");
        [NotMapped] public static Profissao MotoristaDeTrolebus => new Profissao(1449, 782415, "Motorista de trólebus");
        [NotMapped] public static Profissao MotoristaOperacionalDeGuincho => new Profissao(1450, 782515, "Motorista operacional de guincho");
        [NotMapped] public static Profissao Motorneiro => new Profissao(1451, 782620, "Motorneiro");
        [NotMapped] public static Profissao Mototaxista => new Profissao(1452, 519115, "Mototaxista");
        [NotMapped] public static Profissao Museologo => new Profissao(1453, 261310, "Museólogo");
        [NotMapped] public static Profissao MusicoArranjador => new Profissao(1454, 262610, "Músico arranjador");
        [NotMapped] public static Profissao MusicoInterpreteCantor => new Profissao(1455, 262705, "Músico intérprete cantor");
        [NotMapped] public static Profissao MusicoInterpreteInstrumentista => new Profissao(1456, 262710, "Músico intérprete instrumentista");
        [NotMapped] public static Profissao MusicoRegente => new Profissao(1457, 262615, "Músico regente");
        [NotMapped] public static Profissao Musicologo => new Profissao(1458, 262620, "Musicólogo");
        [NotMapped] public static Profissao Musicoterapeuta => new Profissao(1459, 226305, "Musicoterapeuta");
        [NotMapped] public static Profissao Naturologo => new Profissao(1460, 226320, "Naturólogo");
        [NotMapped] public static Profissao Neuropsicologo => new Profissao(1461, 251545, "Neuropsicólogo");
        [NotMapped] public static Profissao NeuropsicopedagogoClinico => new Profissao(1462, 239440, "Neuropsicopedagogo clinico");
        [NotMapped] public static Profissao NeuropsicopedagogoInstitucional => new Profissao(1463, 239445, "Neuropsicopedagogo institucional");
        [NotMapped] public static Profissao NormalizadorDeMetaisEDeCompositos => new Profissao(1464, 723110, "Normalizador de metais e de compósitos");
        [NotMapped] public static Profissao Numerologo => new Profissao(1465, 516710, "Numerólogo");
        [NotMapped] public static Profissao Nutricionista => new Profissao(1466, 223710, "Nutricionista");
        [NotMapped] public static Profissao Oceanografo => new Profissao(1467, 213440, "Oceanógrafo");
        [NotMapped] public static Profissao OficialDaAeronautica => new Profissao(1468, 10205, "Oficial da aeronáutica");
        [NotMapped] public static Profissao OficialDaMarinha => new Profissao(1469, 10215, "Oficial da marinha");
        [NotMapped] public static Profissao OficialDeInteligencia => new Profissao(1470, 242905, "Oficial de inteligência");
        [NotMapped] public static Profissao OficialDeJustica => new Profissao(1471, 351425, "Oficial de justiça");
        [NotMapped] public static Profissao OficialDeQuartoDeNavegacaoDaMarinhaMercante => new Profissao(1472, 215140, "Oficial de quarto de navegação da marinha mercante");
        [NotMapped] public static Profissao OficialDeRegistroDeContratosMaritimos => new Profissao(1473, 241305, "Oficial de registro de contratos marítimos");
        [NotMapped] public static Profissao OficialDoExercito => new Profissao(1474, 10210, "Oficial do exército");
        [NotMapped] public static Profissao OficialDoRegistroCivilDePessoasJuridicas => new Profissao(1475, 241310, "Oficial do registro civil de pessoas jurídicas");
        [NotMapped] public static Profissao OficialDoRegistroCivilDePessoasNaturais => new Profissao(1476, 241315, "Oficial do registro civil de pessoas naturais");
        [NotMapped] public static Profissao OficialDoRegistroDeDistribuicoes => new Profissao(1477, 241320, "Oficial do registro de distribuições");
        [NotMapped] public static Profissao OficialDoRegistroDeImoveis => new Profissao(1478, 241325, "Oficial do registro de imóveis");
        [NotMapped] public static Profissao OficialDoRegistroDeTitulosEDocumentos => new Profissao(1479, 241330, "Oficial do registro de títulos e documentos");
        [NotMapped] public static Profissao OficialGeneralDaAeronautica => new Profissao(1480, 10105, "Oficial general da aeronáutica");
        [NotMapped] public static Profissao OficialGeneralDaMarinha => new Profissao(1481, 10115, "Oficial general da marinha");
        [NotMapped] public static Profissao OficialGeneralDoExercito => new Profissao(1482, 10110, "Oficial general do exército");
        [NotMapped] public static Profissao OficialSuperiorDeMaquinasDaMarinhaMercante => new Profissao(1483, 215205, "Oficial superior de máquinas da marinha mercante");
        [NotMapped] public static Profissao OficialTecnicoDeInteligencia => new Profissao(1484, 242910, "Oficial técnico de inteligência");
        [NotMapped] public static Profissao OleiroFabricacaoDeTelhas => new Profissao(1485, 828105, "Oleiro (fabricação de telhas)");
        [NotMapped] public static Profissao OleiroFabricacaoDeTijolos => new Profissao(1486, 828110, "Oleiro (fabricação de tijolos)");
        [NotMapped] public static Profissao OperadorDeAbastecimentoDeCombustivelDeAeronave => new Profissao(1487, 862160, "Operador de abastecimento de combustível de aeronave");
        [NotMapped] public static Profissao OperadorDeAberturaFiacao => new Profissao(1488, 761205, "Operador de abertura (fiação)");
        [NotMapped] public static Profissao OperadorDeAcabamentoIndustriaGrafica => new Profissao(1489, 766315, "Operador de acabamento (indústria gráfica)");
        [NotMapped] public static Profissao OperadorDeAcabamentoDePecasFundidas => new Profissao(1490, 722215, "Operador de acabamento de peças fundidas");
        [NotMapped] public static Profissao OperadorDeAciariaBasculamentoDeConvertedor => new Profissao(1491, 821230, "Operador de aciaria (basculamento de convertedor)");
        [NotMapped] public static Profissao OperadorDeAciariaDessulfuracaoDeGusa => new Profissao(1492, 821235, "Operador de aciaria (dessulfuração de gusa)");
        [NotMapped] public static Profissao OperadorDeAciariaRecebimentoDeGusa => new Profissao(1493, 821240, "Operador de aciaria (recebimento de gusa)");
        [NotMapped] public static Profissao OperadorDeAeronavesNaoTripuladas => new Profissao(1494, 781310, "Operador de aeronaves não tripuladas");
        [NotMapped] public static Profissao OperadorDeAlambiqueDeFuncionamentoContinuoProdutosQuimicosExcetoPetroleo => new Profissao(1495, 811415, "Operador de alambique de funcionamento contínuo (produtos químicos, exceto petróleo)");
        [NotMapped] public static Profissao OperadorDeAparelhoDeFlotacao => new Profissao(1496, 712110, "Operador de aparelho de flotação");
        [NotMapped] public static Profissao OperadorDeAparelhoDePrecipitacaoMinasDeOuroOuPrata => new Profissao(1497, 712115, "Operador de aparelho de precipitação (minas de ouro ou prata)");
        [NotMapped] public static Profissao OperadorDeAparelhoDeReacaoEConversaoProdutosQuimicosExcetoPetroleo => new Profissao(1498, 811420, "Operador de aparelho de reação e conversão (produtos químicos, exceto petróleo)");
        [NotMapped] public static Profissao OperadorDeAreaDeCorrida => new Profissao(1499, 821245, "Operador de área de corrida");
        [NotMapped] public static Profissao OperadorDeAtendimentoAeroviario => new Profissao(1500, 342535, "Operador de atendimento aeroviário");
        [NotMapped] public static Profissao OperadorDeAtomizador => new Profissao(1501, 823135, "Operador de atomizador");
        [NotMapped] public static Profissao OperadorDeBanhoMetalicoDeVidroPorFlutuacao => new Profissao(1502, 823235, "Operador de banho metálico de vidro por flutuação");
        [NotMapped] public static Profissao OperadorDeBateEstacas => new Profissao(1503, 715105, "Operador de bate-estacas");
        [NotMapped] public static Profissao OperadorDeBateriaDeGasDeHulha => new Profissao(1504, 862115, "Operador de bateria de gás de hulha");
        [NotMapped] public static Profissao OperadorDeBetoneira => new Profissao(1505, 715405, "Operador de betoneira");
        [NotMapped] public static Profissao OperadorDeBinadeira => new Profissao(1506, 761210, "Operador de binadeira");
        [NotMapped] public static Profissao OperadorDeBobinadeira => new Profissao(1507, 761215, "Operador de bobinadeira");
        [NotMapped] public static Profissao OperadorDeBobinadeiraDeTirasAQuenteNoAcabamentoDeChapasEMetais => new Profissao(1508, 821420, "Operador de bobinadeira de tiras a quente, no acabamento de chapas e metais");
        [NotMapped] public static Profissao OperadorDeBombaDeConcreto => new Profissao(1509, 715410, "Operador de bomba de concreto");
        [NotMapped] public static Profissao OperadorDeBranqueadorDePastaParaFabricacaoDePapel => new Profissao(1510, 831110, "Operador de branqueador de pasta para fabricação de papel");
        [NotMapped] public static Profissao OperadorDeBritadeiraTratamentosQuimicosEAfins => new Profissao(1511, 811115, "Operador de britadeira (tratamentos químicos e afins)");
        [NotMapped] public static Profissao OperadorDeBritadorDeCoque => new Profissao(1512, 811605, "Operador de britador de coque");
        [NotMapped] public static Profissao OperadorDeBritadorDeMandibulas => new Profissao(1513, 712120, "Operador de britador de mandíbulas");
        [NotMapped] public static Profissao OperadorDeCabineDeLaminacaoFioMaquina => new Profissao(1514, 821425, "Operador de cabine de laminação (fio-máquina)");
        [NotMapped] public static Profissao OperadorDeCaixa => new Profissao(1515, 421125, "Operador de caixa");
        [NotMapped] public static Profissao OperadorDeCalandraQuimicaPetroquimicaEAfins => new Profissao(1516, 813110, "Operador de calandra (química, petroquímica e afins)");
        [NotMapped] public static Profissao OperadorDeCalandrasTecidos => new Profissao(1517, 761415, "Operador de calandras (tecidos)");
        [NotMapped] public static Profissao OperadorDeCalcinacaoTratamentoQuimicoEAfins => new Profissao(1518, 811205, "Operador de calcinação (tratamento químico e afins)");
        [NotMapped] public static Profissao OperadorDeCaldeira => new Profissao(1519, 862120, "Operador de caldeira");
        [NotMapped] public static Profissao OperadorDeCamarasFrias => new Profissao(1520, 841456, "Operador de câmaras frias");
        [NotMapped] public static Profissao OperadorDeCameraDeTelevisao => new Profissao(1521, 372115, "Operador de câmera de televisão");
        [NotMapped] public static Profissao OperadorDeCaminhaoMinasEPedreiras => new Profissao(1522, 711205, "Operador de caminhão (minas e pedreiras)");
        [NotMapped] public static Profissao OperadorDeCardas => new Profissao(1523, 761220, "Operador de cardas");
        [NotMapped] public static Profissao OperadorDeCarregadeira => new Profissao(1524, 711210, "Operador de carregadeira");
        [NotMapped] public static Profissao OperadorDeCarroDeApagamentoECoque => new Profissao(1525, 811610, "Operador de carro de apagamento e coque");
        [NotMapped] public static Profissao OperadorDeCeifadeiraNaConservacaoDeViasPermanentes => new Profissao(1526, 992215, "Operador de ceifadeira na conservação de vias permanentes");
        [NotMapped] public static Profissao OperadorDeCentralDeConcreto => new Profissao(1527, 715415, "Operador de central de concreto");
        [NotMapped] public static Profissao OperadorDeCentralHidreletrica => new Profissao(1528, 861105, "Operador de central hidrelétrica");
        [NotMapped] public static Profissao OperadorDeCentralTermoeletrica => new Profissao(1529, 861115, "Operador de central termoelétrica");
        [NotMapped] public static Profissao OperadorDeCentrifugadoraTratamentosQuimicosEAfins => new Profissao(1530, 811305, "Operador de centrifugadora (tratamentos químicos e afins)");
        [NotMapped] public static Profissao OperadorDeCentroDeControle => new Profissao(1531, 821105, "Operador de centro de controle");
        [NotMapped] public static Profissao OperadorDeCentroDeControleFerroviaEMetro => new Profissao(1532, 342410, "Operador de centro de controle (ferrovia e metrô)");
        [NotMapped] public static Profissao OperadorDeCentroDeUsinagemComComandoNumerico => new Profissao(1533, 721405, "Operador de centro de usinagem com comando numérico");
        [NotMapped] public static Profissao OperadorDeCentroDeUsinagemDeMadeiraCnc => new Profissao(1534, 773505, "Operador de centro de usinagem de madeira (cnc)");
        [NotMapped] public static Profissao OperadorDeChamuscadeiraDeTecidos => new Profissao(1535, 761420, "Operador de chamuscadeira de tecidos");
        [NotMapped] public static Profissao OperadorDeCobrancaBancaria => new Profissao(1536, 413230, "Operador de cobrança bancária");
        [NotMapped] public static Profissao OperadorDeColhedorFlorestal => new Profissao(1537, 642005, "Operador de colhedor florestal");
        [NotMapped] public static Profissao OperadorDeColheitadeira => new Profissao(1538, 641005, "Operador de colheitadeira");
        [NotMapped] public static Profissao OperadorDeCompactadoraDeSolos => new Profissao(1539, 715110, "Operador de compactadora de solos");
        [NotMapped] public static Profissao OperadorDeCompressorDeAr => new Profissao(1540, 862130, "Operador de compressor de ar");
        [NotMapped] public static Profissao OperadorDeComputador => new Profissao(1541, 317205, "Operador de computador");
        [NotMapped] public static Profissao OperadorDeConcentracao => new Profissao(1542, 811120, "Operador de concentração");
        [NotMapped] public static Profissao OperadorDeConicaleira => new Profissao(1543, 761225, "Operador de conicaleira");
        [NotMapped] public static Profissao OperadorDeControleMestre => new Profissao(1544, 373135, "Operador de controle mestre");
        [NotMapped] public static Profissao OperadorDeCortadeiraDePapel => new Profissao(1545, 832110, "Operador de cortadeira de papel");
        [NotMapped] public static Profissao OperadorDeCristalizacaoNaRefinacaoDeAcucar => new Profissao(1546, 841305, "Operador de cristalização na refinação de açucar");
        [NotMapped] public static Profissao OperadorDeDesempenadeiraNaUsinagemConvencionalDeMadeira => new Profissao(1547, 773305, "Operador de desempenadeira na usinagem convencional de madeira");
        [NotMapped] public static Profissao OperadorDeDesgaseificacao => new Profissao(1548, 821250, "Operador de desgaseificação");
        [NotMapped] public static Profissao OperadorDeDestilacaoESubprodutosDeCoque => new Profissao(1549, 811615, "Operador de destilação e subprodutos de coque");
        [NotMapped] public static Profissao OperadorDeDigestorDePastaParaFabricacaoDePapel => new Profissao(1550, 831115, "Operador de digestor de pasta para fabricação de papel");
        [NotMapped] public static Profissao OperadorDeDocagem => new Profissao(1551, 782210, "Operador de docagem");
        [NotMapped] public static Profissao OperadorDeDraga => new Profissao(1552, 782105, "Operador de draga");
        [NotMapped] public static Profissao OperadorDeEmpilhadeira => new Profissao(1553, 782220, "Operador de empilhadeira");
        [NotMapped] public static Profissao OperadorDeEnfornamentoEDesenfornamentoDeCoque => new Profissao(1554, 811620, "Operador de enfornamento e desenfornamento de coque");
        [NotMapped] public static Profissao OperadorDeEngomadeiraDeUrdume => new Profissao(1555, 761348, "Operador de engomadeira de urdume");
        [NotMapped] public static Profissao OperadorDeEntalhadeiraUsinagemDeMadeira => new Profissao(1556, 773310, "Operador de entalhadeira (usinagem de madeira)");
        [NotMapped] public static Profissao OperadorDeEquipamentoDeDestilacaoDeAlcool => new Profissao(1557, 811425, "Operador de equipamento de destilação de álcool");
        [NotMapped] public static Profissao OperadorDeEquipamentoDeSecagemDePintura => new Profissao(1558, 723305, "Operador de equipamento de secagem de pintura");
        [NotMapped] public static Profissao OperadorDeEquipamentoParaResfriamento => new Profissao(1559, 723115, "Operador de equipamento para resfriamento");
        [NotMapped] public static Profissao OperadorDeEquipamentosDePreparacaoDeAreia => new Profissao(1560, 722325, "Operador de equipamentos de preparação de areia");
        [NotMapped] public static Profissao OperadorDeEquipamentosDeRefinacaoDeAcucarProcessoContinuo => new Profissao(1561, 841310, "Operador de equipamentos de refinação de açúcar (processo contínuo)");
        [NotMapped] public static Profissao OperadorDeEscavadeira => new Profissao(1562, 715115, "Operador de escavadeira");
        [NotMapped] public static Profissao OperadorDeEscoriaESucata => new Profissao(1563, 821430, "Operador de escória e sucata");
        [NotMapped] public static Profissao OperadorDeEsmaltadeira => new Profissao(1564, 752420, "Operador de esmaltadeira");
        [NotMapped] public static Profissao OperadorDeEspelhamento => new Profissao(1565, 752425, "Operador de espelhamento");
        [NotMapped] public static Profissao OperadorDeEspessador => new Profissao(1566, 712125, "Operador de espessador");
        [NotMapped] public static Profissao OperadorDeEspuladeira => new Profissao(1567, 761351, "Operador de espuladeira");
        [NotMapped] public static Profissao OperadorDeEstacaoDeBombeamento => new Profissao(1568, 862140, "Operador de estação de bombeamento");
        [NotMapped] public static Profissao OperadorDeEstacaoDeCaptacaoTratamentoEDistribuicaoDeAgua => new Profissao(1569, 862205, "Operador de estação de captação, tratamento e distribuição de água");
        [NotMapped] public static Profissao OperadorDeEstacaoDeTratamentoDeAguaEEfluentes => new Profissao(1570, 862305, "Operador de estação de tratamento de água e efluentes");
        [NotMapped] public static Profissao OperadorDeEvaporadorNaDestilacao => new Profissao(1571, 811430, "Operador de evaporador na destilação");
        [NotMapped] public static Profissao OperadorDeExaustorCoqueria => new Profissao(1572, 811625, "Operador de exaustor (coqueria)");
        [NotMapped] public static Profissao OperadorDeExploracaoDePetroleo => new Profissao(1573, 811310, "Operador de exploração de petróleo");
        [NotMapped] public static Profissao OperadorDeExtracaoDeCafeSoluvel => new Profissao(1574, 841620, "Operador de extração de café solúvel");
        [NotMapped] public static Profissao OperadorDeExtrusoraQuimicaPetroquimicaEAfins => new Profissao(1575, 813115, "Operador de extrusora (química, petroquímica e afins)");
        [NotMapped] public static Profissao OperadorDeFilatorio => new Profissao(1576, 761230, "Operador de filatório");
        [NotMapped] public static Profissao OperadorDeFiltroDeSecagemMineracao => new Profissao(1577, 811315, "Operador de filtro de secagem (mineração)");
        [NotMapped] public static Profissao OperadorDeFiltroDeTamborRotativoTratamentosQuimicosEAfins => new Profissao(1578, 811320, "Operador de filtro de tambor rotativo (tratamentos químicos e afins)");
        [NotMapped] public static Profissao OperadorDeFiltroEsteiraMineracao => new Profissao(1579, 811325, "Operador de filtro-esteira (mineração)");
        [NotMapped] public static Profissao OperadorDeFiltroPrensaTratamentosQuimicosEAfins => new Profissao(1580, 811330, "Operador de filtro-prensa (tratamentos químicos e afins)");
        [NotMapped] public static Profissao OperadorDeFiltrosDeParafinaTratamentosQuimicosEAfins => new Profissao(1581, 811335, "Operador de filtros de parafina (tratamentos químicos e afins)");
        [NotMapped] public static Profissao OperadorDeFornoFabricacaoDePaesBiscoitosESimilares => new Profissao(1582, 841805, "Operador de forno (fabricação de pães, biscoitos e similares)");
        [NotMapped] public static Profissao OperadorDeFornoServicosFunerarios => new Profissao(1583, 516605, "Operador de forno (serviços funerários)");
        [NotMapped] public static Profissao OperadorDeFornoDeIncineracaoNoTratamentoDeAguaEfluentesEResiduosIndustriais => new Profissao(1584, 862310, "Operador de forno de incineração no tratamento de água, efluentes e resíduos industriais");
        [NotMapped] public static Profissao OperadorDeFornoDeTratamentoTermicoDeMetais => new Profissao(1585, 723120, "Operador de forno de tratamento térmico de metais");
        [NotMapped] public static Profissao OperadorDeFresadoraUsinagemDeMadeira => new Profissao(1586, 773315, "Operador de fresadora (usinagem de madeira)");
        [NotMapped] public static Profissao OperadorDeFresadoraComComandoNumerico => new Profissao(1587, 721410, "Operador de fresadora com comando numérico");
        [NotMapped] public static Profissao OperadorDeGuilhotinaCorteDePapel => new Profissao(1588, 766320, "Operador de guilhotina (corte de papel)");
        [NotMapped] public static Profissao OperadorDeGuindasteFixo => new Profissao(1589, 782110, "Operador de guindaste (fixo)");
        [NotMapped] public static Profissao OperadorDeGuindasteMovel => new Profissao(1590, 782115, "Operador de guindaste móvel");
        [NotMapped] public static Profissao OperadorDeImpermeabilizadorDeTecidos => new Profissao(1591, 761425, "Operador de impermeabilizador de tecidos");
        [NotMapped] public static Profissao OperadorDeIncubadora => new Profissao(1592, 623315, "Operador de incubadora");
        [NotMapped] public static Profissao OperadorDeInspecaoDeQualidade => new Profissao(1593, 391215, "Operador de inspeção de qualidade");
        [NotMapped] public static Profissao OperadorDeInstalacaoDeArCondicionado => new Profissao(1594, 862515, "Operador de instalação de ar-condicionado");
        [NotMapped] public static Profissao OperadorDeInstalacaoDeExtracaoProcessamentoEnvasamentoEDistribuicaoDeGases => new Profissao(1595, 862405, "Operador de instalação de extração, processamento, envasamento e distribuição de gases");
        [NotMapped] public static Profissao OperadorDeInstalacaoDeRefrigeracao => new Profissao(1596, 862505, "Operador de instalação de refrigeração");
        [NotMapped] public static Profissao OperadorDeJatoAbrasivo => new Profissao(1597, 821435, "Operador de jato abrasivo");
        [NotMapped] public static Profissao OperadorDeJigMinas => new Profissao(1598, 712130, "Operador de jig (minas)");
        [NotMapped] public static Profissao OperadorDeLacosDeCabosDeAco => new Profissao(1599, 724605, "Operador de laços de cabos de aço");
        [NotMapped] public static Profissao OperadorDeLaminadeiraEReunideira => new Profissao(1600, 761235, "Operador de laminadeira e reunideira");
        [NotMapped] public static Profissao OperadorDeLaminador => new Profissao(1601, 821305, "Operador de laminador");
        [NotMapped] public static Profissao OperadorDeLaminadorDeBarrasAFrio => new Profissao(1602, 821310, "Operador de laminador de barras a frio");
        [NotMapped] public static Profissao OperadorDeLaminadorDeBarrasAQuente => new Profissao(1603, 821315, "Operador de laminador de barras a quente");
        [NotMapped] public static Profissao OperadorDeLaminadorDeMetaisNaoFerrosos => new Profissao(1604, 821320, "Operador de laminador de metais não-ferrosos");
        [NotMapped] public static Profissao OperadorDeLaminadorDeTubos => new Profissao(1605, 821325, "Operador de laminador de tubos");
        [NotMapped] public static Profissao OperadorDeLavagemEDepuracaoDePastaParaFabricacaoDePapel => new Profissao(1606, 831120, "Operador de lavagem e depuração de pasta para fabricação de papel");
        [NotMapped] public static Profissao OperadorDeLinhaDeMontagemAparelhosEletricos => new Profissao(1607, 731175, "Operador de linha de montagem (aparelhos elétricos)");
        [NotMapped] public static Profissao OperadorDeLinhaDeMontagemAparelhosEletronicos => new Profissao(1608, 731180, "Operador de linha de montagem (aparelhos eletrônicos)");
        [NotMapped] public static Profissao OperadorDeLixadeiraUsinagemDeMadeira => new Profissao(1609, 773320, "Operador de lixadeira (usinagem de madeira)");
        [NotMapped] public static Profissao OperadorDeMacaroqueira => new Profissao(1610, 761240, "Operador de maçaroqueira");
        [NotMapped] public static Profissao OperadorDeMandriladoraComComandoNumerico => new Profissao(1611, 721415, "Operador de mandriladora com comando numérico");
        [NotMapped] public static Profissao OperadorDeMaquinaFabricacaoDeCigarros => new Profissao(1612, 842125, "Operador de máquina (fabricação de cigarros)");
        [NotMapped] public static Profissao OperadorDeMaquinaBordatriz => new Profissao(1613, 773405, "Operador de máquina bordatriz");
        [NotMapped] public static Profissao OperadorDeMaquinaCopiadoraExcetoOperadorDeGraficaRapida => new Profissao(1614, 415130, "Operador de máquina copiadora (exceto operador de gráfica rápida)");
        [NotMapped] public static Profissao OperadorDeMaquinaCortadoraMinasEPedreiras => new Profissao(1615, 711215, "Operador de máquina cortadora (minas e pedreiras)");
        [NotMapped] public static Profissao OperadorDeMaquinaDeAbrirValas => new Profissao(1616, 715120, "Operador de máquina de abrir valas");
        [NotMapped] public static Profissao OperadorDeMaquinaDeCilindrarChapas => new Profissao(1617, 724505, "Operador de máquina de cilindrar chapas");
        [NotMapped] public static Profissao OperadorDeMaquinaDeCordoalha => new Profissao(1618, 761354, "Operador de máquina de cordoalha");
        [NotMapped] public static Profissao OperadorDeMaquinaDeCortarEDobrarPapelao => new Profissao(1619, 833120, "Operador de máquina de cortar e dobrar papelão");
        [NotMapped] public static Profissao OperadorDeMaquinaDeCortinaDAguaProducaoDeMoveis => new Profissao(1620, 773410, "Operador de máquina de cortina d´água (produção de móveis)");
        [NotMapped] public static Profissao OperadorDeMaquinaDeCosturaDeAcabamento => new Profissao(1621, 763320, "Operador de máquina de costura de acabamento");
        [NotMapped] public static Profissao OperadorDeMaquinaDeDobrarChapas => new Profissao(1622, 724510, "Operador de máquina de dobrar chapas");
        [NotMapped] public static Profissao OperadorDeMaquinaDeEletroerosao => new Profissao(1623, 721205, "Operador de máquina de eletroerosão");
        [NotMapped] public static Profissao OperadorDeMaquinaDeEnvasarLiquidos => new Profissao(1624, 784120, "Operador de máquina de envasar líquidos");
        [NotMapped] public static Profissao OperadorDeMaquinaDeEtiquetar => new Profissao(1625, 784115, "Operador de máquina de etiquetar");
        [NotMapped] public static Profissao OperadorDeMaquinaDeExtracaoContinuaMinasDeCarvao => new Profissao(1626, 711220, "Operador de máquina de extração contínua (minas de carvão)");
        [NotMapped] public static Profissao OperadorDeMaquinaDeFabricacaoDeCosmeticos => new Profissao(1627, 811815, "Operador de máquina de fabricação de cosméticos");
        [NotMapped] public static Profissao OperadorDeMaquinaDeFabricacaoDeProdutosDeHigieneELimpezaSabaoSaboneteEOutros => new Profissao(1628, 811820, "Operador de máquina de fabricação de produtos de higiene e limpeza (sabão, sabonete,fraldas e outros)");
        [NotMapped] public static Profissao OperadorDeMaquinaDeFabricarCharutosECigarrilhas => new Profissao(1629, 842210, "Operador de máquina de fabricar charutos e cigarrilhas");
        [NotMapped] public static Profissao OperadorDeMaquinaDeFabricarPapelFaseUmida => new Profissao(1630, 832115, "Operador de máquina de fabricar papel  (fase úmida)");
        [NotMapped] public static Profissao OperadorDeMaquinaDeFabricarPapelFaseSeca => new Profissao(1631, 832120, "Operador de máquina de fabricar papel (fase seca)");
        [NotMapped] public static Profissao OperadorDeMaquinaDeFabricarPapelEPapelao => new Profissao(1632, 832125, "Operador de máquina de fabricar papel e papelão");
        [NotMapped] public static Profissao OperadorDeMaquinaDeFundicao => new Profissao(1633, 722220, "Operador de máquina de fundição");
        [NotMapped] public static Profissao OperadorDeMaquinaDeFundirSobPressao => new Profissao(1634, 722225, "Operador de máquina de fundir sob pressão");
        [NotMapped] public static Profissao OperadorDeMaquinaDeLavarFiosETecidos => new Profissao(1635, 761430, "Operador de máquina de lavar fios e tecidos");
        [NotMapped] public static Profissao OperadorDeMaquinaDeMoldarAutomatizada => new Profissao(1636, 722330, "Operador de máquina de moldar automatizada");
        [NotMapped] public static Profissao OperadorDeMaquinaDePreparacaoDeMateriaPrimaParaProducaoDeCigarros => new Profissao(1637, 842135, "Operador de máquina de preparação de matéria prima para produção de cigarros");
        [NotMapped] public static Profissao OperadorDeMaquinaDeProdutosFarmaceuticos => new Profissao(1638, 811805, "Operador de máquina de produtos farmacêuticos");
        [NotMapped] public static Profissao OperadorDeMaquinaDeSecarCelulose => new Profissao(1639, 831125, "Operador de máquina de secar celulose");
        [NotMapped] public static Profissao OperadorDeMaquinaDeSinterizar => new Profissao(1640, 821110, "Operador de máquina de sinterizar");
        [NotMapped] public static Profissao OperadorDeMaquinaDeSoprarVidro => new Profissao(1641, 823240, "Operador de máquina de soprar vidro");
        [NotMapped] public static Profissao OperadorDeMaquinaDeUsinagemDeMadeiraProducaoEmSerie => new Profissao(1642, 773415, "Operador de máquina de usinagem de madeira (produção em série)");
        [NotMapped] public static Profissao OperadorDeMaquinaDeUsinagemMadeiraEmGeral => new Profissao(1643, 773325, "Operador de máquina de usinagem madeira, em geral");
        [NotMapped] public static Profissao OperadorDeMaquinaEletroerosaoAFioComComandoNumerico => new Profissao(1644, 721420, "Operador de máquina eletroerosão, à fio, com comando numérico");
        [NotMapped] public static Profissao OperadorDeMaquinaExtrusoraDeVaretasETubosDeVidro => new Profissao(1645, 823245, "Operador de máquina extrusora de varetas e tubos de vidro");
        [NotMapped] public static Profissao OperadorDeMaquinaIntercaladoraDePlacasCompensados => new Profissao(1646, 773205, "Operador de máquina intercaladora de placas (compensados)");
        [NotMapped] public static Profissao OperadorDeMaquinaMisturadeiraTratamentosQuimicosEAfins => new Profissao(1647, 811110, "Operador de máquina misturadeira (tratamentos químicos e afins)");
        [NotMapped] public static Profissao OperadorDeMaquinaPerfuradoraMinasEPedreiras => new Profissao(1648, 711225, "Operador de máquina perfuradora (minas e pedreiras)");
        [NotMapped] public static Profissao OperadorDeMaquinaPerfuratriz => new Profissao(1649, 711230, "Operador de máquina perfuratriz");
        [NotMapped] public static Profissao OperadorDeMaquinaRecobridoraDeArame => new Profissao(1650, 723230, "Operador de máquina recobridora de arame");
        [NotMapped] public static Profissao OperadorDeMaquinaRodoferroviaria => new Profissao(1651, 782120, "Operador de máquina rodoferroviária");
        [NotMapped] public static Profissao OperadorDeMaquinasDeBeneficiamentoDeProdutosAgricolas => new Profissao(1652, 641010, "Operador de máquinas de beneficiamento de produtos agrícolas");
        [NotMapped] public static Profissao OperadorDeMaquinasDeConstrucaoCivilEMineracao => new Profissao(1653, 715125, "Operador de máquinas de construção civil e mineração");
        [NotMapped] public static Profissao OperadorDeMaquinasDeFabricacaoDeChocolatesEAchocolatados => new Profissao(1654, 841815, "Operador de máquinas de fabricação de chocolates e achocolatados");
        [NotMapped] public static Profissao OperadorDeMaquinasDeFabricacaoDeDocesSalgadosEMassasAlimenticias => new Profissao(1655, 841810, "Operador de máquinas de fabricação de doces, salgados e massas alimentícias");
        [NotMapped] public static Profissao OperadorDeMaquinasDeUsinarMadeiraCnc => new Profissao(1656, 773510, "Operador de máquinas de usinar madeira (cnc)");
        [NotMapped] public static Profissao OperadorDeMaquinasDoAcabamentoDeCourosEPeles => new Profissao(1657, 762325, "Operador de máquinas do acabamento de couros e peles");
        [NotMapped] public static Profissao OperadorDeMaquinasEspeciaisEmConservacaoDeViaPermanenteTrilhos => new Profissao(1658, 991115, "Operador de máquinas especiais em conservação de via permanente (trilhos)");
        [NotMapped] public static Profissao OperadorDeMaquinasFixasEmGeral => new Profissao(1659, 862150, "Operador de máquinas fixas, em geral");
        [NotMapped] public static Profissao OperadorDeMaquinasFlorestaisEstaticas => new Profissao(1660, 642010, "Operador de máquinas florestais estáticas");
        [NotMapped] public static Profissao OperadorDeMaquinasOperatrizes => new Profissao(1661, 721210, "Operador de máquinas operatrizes");
        [NotMapped] public static Profissao OperadorDeMaquinasFerramentaConvencionais => new Profissao(1662, 721215, "Operador de máquinas-ferramenta convencionais");
        [NotMapped] public static Profissao OperadorDeMartelete => new Profissao(1663, 717010, "Operador de martelete");
        [NotMapped] public static Profissao OperadorDeMensagensDeTelecomunicacoesCorreios => new Profissao(1664, 412115, "Operador de mensagens de telecomunicações (correios)");
        [NotMapped] public static Profissao OperadorDeMidiaAudiovisual => new Profissao(1665, 373105, "Operador de mídia audiovisual");
        [NotMapped] public static Profissao OperadorDeMoendaNaFabricacaoDeAcucar => new Profissao(1666, 841315, "Operador de moenda na fabricação de açúcar");
        [NotMapped] public static Profissao OperadorDeMolduradoraUsinagemDeMadeira => new Profissao(1667, 773330, "Operador de molduradora (usinagem de madeira)");
        [NotMapped] public static Profissao OperadorDeMontaCargasConstrucaoCivil => new Profissao(1668, 782125, "Operador de monta-cargas (construção civil)");
        [NotMapped] public static Profissao OperadorDeMontagemDeCilindrosEMancais => new Profissao(1669, 821330, "Operador de montagem de cilindros e mancais");
        [NotMapped] public static Profissao OperadorDeMotoniveladora => new Profissao(1670, 715130, "Operador de motoniveladora");
        [NotMapped] public static Profissao OperadorDeMotoniveladoraExtracaoDeMineraisSolidos => new Profissao(1671, 711235, "Operador de motoniveladora (extração de minerais sólidos)");
        [NotMapped] public static Profissao OperadorDeMotosserra => new Profissao(1672, 632120, "Operador de motosserra");
        [NotMapped] public static Profissao OperadorDeNegocios => new Profissao(1673, 253225, "Operador de negócios");
        [NotMapped] public static Profissao OperadorDeOpenEnd => new Profissao(1674, 761245, "Operador de open-end");
        [NotMapped] public static Profissao OperadorDePaCarregadeira => new Profissao(1675, 715135, "Operador de pá carregadeira");
        [NotMapped] public static Profissao OperadorDePainelDeControle => new Profissao(1676, 811630, "Operador de painel de controle");
        [NotMapped] public static Profissao OperadorDePainelDeControleRefinacaoDePetroleo => new Profissao(1677, 811505, "Operador de painel de controle (refinação de petróleo)");
        [NotMapped] public static Profissao OperadorDePassadorFiacao => new Profissao(1678, 761250, "Operador de passador (fiação)");
        [NotMapped] public static Profissao OperadorDePavimentadoraAsfaltoConcretoEMateriaisSimilares => new Profissao(1679, 715140, "Operador de pavimentadora (asfalto, concreto e materiais similares)");
        [NotMapped] public static Profissao OperadorDePeneirasHidraulicas => new Profissao(1680, 712135, "Operador de peneiras hidráulicas");
        [NotMapped] public static Profissao OperadorDePenteadeira => new Profissao(1681, 761255, "Operador de penteadeira");
        [NotMapped] public static Profissao OperadorDePlainaDesengrossadeira => new Profissao(1682, 773335, "Operador de plaina desengrossadeira");
        [NotMapped] public static Profissao OperadorDePonteRolante => new Profissao(1683, 782130, "Operador de ponte rolante");
        [NotMapped] public static Profissao OperadorDePorticoRolante => new Profissao(1684, 782135, "Operador de pórtico rolante");
        [NotMapped] public static Profissao OperadorDePrensaDeAltaFrequenciaNaUsinagemDeMadeira => new Profissao(1685, 773420, "Operador de prensa de alta freqüência na usinagem de madeira");
        [NotMapped] public static Profissao OperadorDePrensaDeEmbutirPapelao => new Profissao(1686, 833125, "Operador de prensa de embutir papelão");
        [NotMapped] public static Profissao OperadorDePrensaDeEnfardamento => new Profissao(1687, 784125, "Operador de prensa de enfardamento");
        [NotMapped] public static Profissao OperadorDePrensaDeMaterialReciclavel => new Profissao(1688, 519215, "Operador de prensa de material reciclável");
        [NotMapped] public static Profissao OperadorDePrensaDeMoldarVidro => new Profissao(1689, 823250, "Operador de prensa de moldar vidro");
        [NotMapped] public static Profissao OperadorDePreparacaoDeGraosVegetaisOleosEGorduras => new Profissao(1690, 841460, "Operador de preparação de grãos vegetais (óleos e gorduras)");
        [NotMapped] public static Profissao OperadorDePreservacaoEControleTermico => new Profissao(1691, 811635, "Operador de preservação e controle térmico");
        [NotMapped] public static Profissao OperadorDeProcessoQuimicaPetroquimicaEAfins => new Profissao(1692, 813120, "Operador de processo (química, petroquímica e afins)");
        [NotMapped] public static Profissao OperadorDeProcessoDeMoagem => new Profissao(1693, 841115, "Operador de processo de moagem");
        [NotMapped] public static Profissao OperadorDeProcessoDeTratamentoDeImagem => new Profissao(1694, 766150, "Operador de processo de tratamento de imagem");
        [NotMapped] public static Profissao OperadorDeProcessosQuimicosEPetroquimicos => new Profissao(1695, 811005, "Operador de processos químicos e petroquímicos");
        [NotMapped] public static Profissao OperadorDeProducaoQuimicaPetroquimicaEAfins => new Profissao(1696, 813125, "Operador de produção (química, petroquímica e afins)");
        [NotMapped] public static Profissao OperadorDeProjetorCinematografico => new Profissao(1697, 374305, "Operador de projetor cinematográfico");
        [NotMapped] public static Profissao OperadorDeQuadroDeDistribuicaoDeEnergiaEletrica => new Profissao(1698, 861110, "Operador de quadro de distribuição de energia elétrica");
        [NotMapped] public static Profissao OperadorDeRadioChamada => new Profissao(1699, 422220, "Operador de rádio-chamada");
        [NotMapped] public static Profissao OperadorDeRameuse => new Profissao(1700, 761435, "Operador de rameuse");
        [NotMapped] public static Profissao OperadorDeReatorDeCoqueDePetroleo => new Profissao(1701, 811640, "Operador de reator de coque de petróleo");
        [NotMapped] public static Profissao OperadorDeReatorNuclear => new Profissao(1702, 861120, "Operador de reator nuclear");
        [NotMapped] public static Profissao OperadorDeRebobinadeiraNaFabricacaoDePapelEPapelao => new Profissao(1703, 832135, "Operador de rebobinadeira na fabricação de papel e papelão");
        [NotMapped] public static Profissao OperadorDeRedeDeTeleprocessamento => new Profissao(1704, 372205, "Operador de rede de teleprocessamento");
        [NotMapped] public static Profissao OperadorDeRefrigeracaoCoqueria => new Profissao(1705, 811645, "Operador de refrigeração (coqueria)");
        [NotMapped] public static Profissao OperadorDeRefrigeracaoComAmonia => new Profissao(1706, 862510, "Operador de refrigeração com amônia");
        [NotMapped] public static Profissao OperadorDeRetificadoraComComandoNumerico => new Profissao(1707, 721425, "Operador de retificadora com comando numérico");
        [NotMapped] public static Profissao OperadorDeRetorcedeira => new Profissao(1708, 761260, "Operador de retorcedeira");
        [NotMapped] public static Profissao OperadorDeSalaDeControleDeInstalacoesQuimicasPetroquimicasEAfins => new Profissao(1709, 811010, "Operador de sala de controle de instalações químicas, petroquímicas e afins");
        [NotMapped] public static Profissao OperadorDeSalinaSalMarinho => new Profissao(1710, 711410, "Operador de salina (sal marinho)");
        [NotMapped] public static Profissao OperadorDeSchutthecar => new Profissao(1711, 711240, "Operador de schutthecar");
        [NotMapped] public static Profissao OperadorDeSerrasUsinagemDeMadeira => new Profissao(1712, 773340, "Operador de serras (usinagem de madeira)");
        [NotMapped] public static Profissao OperadorDeSerrasNoDesdobramentoDeMadeira => new Profissao(1713, 773110, "Operador de serras no desdobramento de madeira");
        [NotMapped] public static Profissao OperadorDeSistemaDeReversaoCoqueria => new Profissao(1714, 811650, "Operador de sistema de reversão (coqueria)");
        [NotMapped] public static Profissao OperadorDeSistemasDeProvaAnalogicoEDigital => new Profissao(1715, 766145, "Operador de sistemas de prova (analógico e digital)");
        [NotMapped] public static Profissao OperadorDeSondaDePercussao => new Profissao(1716, 711305, "Operador de sonda de percussão");
        [NotMapped] public static Profissao OperadorDeSondaRotativa => new Profissao(1717, 711310, "Operador de sonda rotativa");
        [NotMapped] public static Profissao OperadorDeSubestacao => new Profissao(1718, 861205, "Operador de subestação");
        [NotMapped] public static Profissao OperadorDeTalhaEletrica => new Profissao(1719, 782140, "Operador de talha elétrica");
        [NotMapped] public static Profissao OperadorDeTelefericoPassageiros => new Profissao(1720, 782630, "Operador de teleférico (passageiros)");
        [NotMapped] public static Profissao OperadorDeTelemarketingAtivo => new Profissao(1721, 422305, "Operador de telemarketing ativo");
        [NotMapped] public static Profissao OperadorDeTelemarketingAtivoEReceptivo => new Profissao(1722, 422310, "Operador de telemarketing ativo e receptivo");
        [NotMapped] public static Profissao OperadorDeTelemarketingReceptivo => new Profissao(1723, 422315, "Operador de telemarketing receptivo");
        [NotMapped] public static Profissao OperadorDeTelemarketingTecnico => new Profissao(1724, 422320, "Operador de telemarketing técnico");
        [NotMapped] public static Profissao OperadorDeTesouraMecanicaEMaquinaDeCorteNoAcabamentoDeChapasEMetais => new Profissao(1725, 821440, "Operador de tesoura mecânica e máquina de corte, no acabamento de chapas e metais");
        [NotMapped] public static Profissao OperadorDeTimeDeMontagem => new Profissao(1726, 725510, "Operador de time de montagem");
        [NotMapped] public static Profissao OperadorDeTornoAutomaticoUsinagemDeMadeira => new Profissao(1727, 773345, "Operador de torno automático (usinagem de madeira)");
        [NotMapped] public static Profissao OperadorDeTornoComComandoNumerico => new Profissao(1728, 721430, "Operador de torno com comando numérico");
        [NotMapped] public static Profissao OperadorDeTransferenciaEEstocagemNaRefinacaoDoPetroleo => new Profissao(1729, 811510, "Operador de transferência e estocagem - na refinação do petróleo");
        [NotMapped] public static Profissao OperadorDeTransporteMultimodal => new Profissao(1730, 342110, "Operador de transporte multimodal");
        [NotMapped] public static Profissao OperadorDeTratamentoDeCaldaNaRefinacaoDeAcucar => new Profissao(1731, 841320, "Operador de tratamento de calda na refinação de açúcar");
        [NotMapped] public static Profissao OperadorDeTratamentoQuimicoDeMateriaisRadioativos => new Profissao(1732, 811215, "Operador de tratamento químico de materiais radioativos");
        [NotMapped] public static Profissao OperadorDeTratorMinasEPedreiras => new Profissao(1733, 711245, "Operador de trator (minas e pedreiras)");
        [NotMapped] public static Profissao OperadorDeTratorDeLamina => new Profissao(1734, 715145, "Operador de trator de lâmina");
        [NotMapped] public static Profissao OperadorDeTratorFlorestal => new Profissao(1735, 642015, "Operador de trator florestal");
        [NotMapped] public static Profissao OperadorDeTremDeMetro => new Profissao(1736, 782605, "Operador de trem de metrô");
        [NotMapped] public static Profissao OperadorDeTriagemETransbordo => new Profissao(1737, 415210, "Operador de triagem e transbordo");
        [NotMapped] public static Profissao OperadorDeTupiaUsinagemDeMadeira => new Profissao(1738, 773350, "Operador de tupia (usinagem de madeira)");
        [NotMapped] public static Profissao OperadorDeTurismo => new Profissao(1739, 354810, "Operador de turismo");
        [NotMapped] public static Profissao OperadorDeUrdideira => new Profissao(1740, 761357, "Operador de urdideira");
        [NotMapped] public static Profissao OperadorDeUsinagemConvencionalPorAbrasao => new Profissao(1741, 721220, "Operador de usinagem convencional por abrasão");
        [NotMapped] public static Profissao OperadorDeUtilidadeProducaoEDistribuicaoDeVaporGasOleoCombustivelEnergiaOxigenio => new Profissao(1742, 862155, "Operador de utilidade (produção e distribuição de vapor, gás, óleo, combustível, energia, oxigênio)");
        [NotMapped] public static Profissao OperadorDeVazamentoLingotamento => new Profissao(1743, 722230, "Operador de vazamento (lingotamento)");
        [NotMapped] public static Profissao OperadorDeVeiculosSubaquaticosControladosRemotamente => new Profissao(1744, 781305, "Operador de veículos subaquáticos controlados remotamente");
        [NotMapped] public static Profissao OperadorDeZincagemProcessoEletrolitico => new Profissao(1745, 723235, "Operador de zincagem (processo eletrolítico)");
        [NotMapped] public static Profissao OperadorEletromecanico => new Profissao(1746, 954125, "Operador eletromecânico");
        [NotMapped] public static Profissao OperadorPolivalenteDaIndustriaTextil => new Profissao(1747, 761005, "Operador polivalente da indústria têxtil");
        [NotMapped] public static Profissao OperadorMantenedorDeProjetorCinematografico => new Profissao(1748, 374310, "Operador-mantenedor de projetor cinematográfico");
        [NotMapped] public static Profissao OrganizadorDeEvento => new Profissao(1749, 354820, "Organizador de evento");
        [NotMapped] public static Profissao OrientadorEducacional => new Profissao(1750, 239410, "Orientador educacional");
        [NotMapped] public static Profissao Ortoptista => new Profissao(1751, 223910, "Ortoptista");
        [NotMapped] public static Profissao Osteopata => new Profissao(1752, 226110, "Osteopata");
        [NotMapped] public static Profissao Ourives => new Profissao(1753, 751125, "Ourives");
        [NotMapped] public static Profissao Ouvidor => new Profissao(1754, 142340, "Ouvidor");
        [NotMapped] public static Profissao OxicortadorAMaoEAMaquina => new Profissao(1755, 724310, "Oxicortador a mão e a  máquina");
        [NotMapped] public static Profissao Oxidador => new Profissao(1756, 723240, "Oxidador");
        [NotMapped] public static Profissao Padeiro => new Profissao(1757, 848305, "Padeiro");
        [NotMapped] public static Profissao Paginador => new Profissao(1758, 768620, "Paginador");
        [NotMapped] public static Profissao PalecionadorDeCourosEPeles => new Profissao(1759, 762335, "Palecionador de couros e peles");
        [NotMapped] public static Profissao Paleontologo => new Profissao(1760, 213430, "Paleontólogo");
        [NotMapped] public static Profissao Palhaco => new Profissao(1761, 376245, "Palhaço");
        [NotMapped] public static Profissao PapiloscopistaPolicial => new Profissao(1762, 351815, "Papiloscopista policial");
        [NotMapped] public static Profissao Paranormal => new Profissao(1763, 516810, "Paranormal");
        [NotMapped] public static Profissao ParteiraLeiga => new Profissao(1764, 515115, "Parteira leiga");
        [NotMapped] public static Profissao PassadeiraDePecasConfeccionadas => new Profissao(1765, 763325, "Passadeira de peças confeccionadas");
        [NotMapped] public static Profissao PassadorDeRoupasEmGeral => new Profissao(1766, 516325, "Passador de roupas em geral");
        [NotMapped] public static Profissao PassadorDeRoupasAMao => new Profissao(1767, 516415, "Passador de roupas, à mão");
        [NotMapped] public static Profissao PassamaneiroAMaquina => new Profissao(1768, 761360, "Passamaneiro a  máquina");
        [NotMapped] public static Profissao Pasteurizador => new Profissao(1769, 848205, "Pasteurizador");
        [NotMapped] public static Profissao Pastilheiro => new Profissao(1770, 716515, "Pastilheiro");
        [NotMapped] public static Profissao PatraoDePescaDeAltoMar => new Profissao(1771, 341220, "Patrão de pesca de alto-mar");
        [NotMapped] public static Profissao PatraoDePescaNaNavegacaoInterior => new Profissao(1772, 341225, "Patrão de pesca na navegação interior");
        [NotMapped] public static Profissao Pedagogo => new Profissao(1773, 239415, "Pedagogo");
        [NotMapped] public static Profissao Pedicure => new Profissao(1774, 516140, "Pedicure");
        [NotMapped] public static Profissao Pedreiro => new Profissao(1775, 715210, "Pedreiro");
        [NotMapped] public static Profissao PedreiroChaminesIndustriais => new Profissao(1776, 715215, "Pedreiro (chaminés industriais)");
        [NotMapped] public static Profissao PedreiroMaterialRefratario => new Profissao(1777, 715220, "Pedreiro (material refratário)");
        [NotMapped] public static Profissao PedreiroMineracao => new Profissao(1778, 715225, "Pedreiro (mineração)");
        [NotMapped] public static Profissao PedreiroDeConservacaoDeViasPermanentesExcetoTrilhos => new Profissao(1779, 992220, "Pedreiro de conservação de vias permanentes (exceto trilhos)");
        [NotMapped] public static Profissao PedreiroDeEdificacoes => new Profissao(1780, 715230, "Pedreiro de edificações");
        [NotMapped] public static Profissao Perfumista => new Profissao(1781, 325015, "Perfumista");
        [NotMapped] public static Profissao Perfusionista => new Profissao(1782, 223570, "Perfusionista");
        [NotMapped] public static Profissao PeritoContabil => new Profissao(1783, 252215, "Perito contábil");
        [NotMapped] public static Profissao PeritoCriminal => new Profissao(1784, 204105, "Perito criminal");
        [NotMapped] public static Profissao PescadorArtesanalDeAguaDoce => new Profissao(1785, 631105, "Pescador artesanal de água doce");
        [NotMapped] public static Profissao PescadorArtesanalDeLagostas => new Profissao(1786, 631015, "Pescador artesanal de lagostas");
        [NotMapped] public static Profissao PescadorArtesanalDePeixesECamaroes => new Profissao(1787, 631020, "Pescador artesanal de peixes e camarões");
        [NotMapped] public static Profissao PescadorIndustrial => new Profissao(1788, 631205, "Pescador industrial");
        [NotMapped] public static Profissao PescadorProfissional => new Profissao(1789, 631210, "Pescador profissional");
        [NotMapped] public static Profissao PesquisadorDeClinicaMedica => new Profissao(1790, 203305, "Pesquisador de clínica médica");
        [NotMapped] public static Profissao PesquisadorDeEngenhariaCivil => new Profissao(1791, 203205, "Pesquisador de engenharia civil");
        [NotMapped] public static Profissao PesquisadorDeEngenhariaETecnologiaOutrasAreasDaEngenharia => new Profissao(1792, 203210, "Pesquisador de engenharia e tecnologia (outras áreas da engenharia)");
        [NotMapped] public static Profissao PesquisadorDeEngenhariaEletricaEEletronica => new Profissao(1793, 203215, "Pesquisador de engenharia elétrica e eletrônica");
        [NotMapped] public static Profissao PesquisadorDeEngenhariaMecanica => new Profissao(1794, 203220, "Pesquisador de engenharia mecânica");
        [NotMapped] public static Profissao PesquisadorDeEngenhariaMetalurgicaDeMinasEDeMateriais => new Profissao(1795, 203225, "Pesquisador de engenharia metalúrgica, de minas e de materiais");
        [NotMapped] public static Profissao PesquisadorDeEngenhariaQuimica => new Profissao(1796, 203230, "Pesquisador de engenharia química");
        [NotMapped] public static Profissao PesquisadorDeMedicinaBasica => new Profissao(1797, 203310, "Pesquisador de medicina básica");
        [NotMapped] public static Profissao PesquisadorEmBiologiaAmbiental => new Profissao(1798, 203005, "Pesquisador em biologia ambiental");
        [NotMapped] public static Profissao PesquisadorEmBiologiaAnimal => new Profissao(1799, 203010, "Pesquisador em biologia animal");
        [NotMapped] public static Profissao PesquisadorEmBiologiaDeMicroorganismosEParasitas => new Profissao(1800, 203015, "Pesquisador em biologia de microorganismos e parasitas");
        [NotMapped] public static Profissao PesquisadorEmBiologiaHumana => new Profissao(1801, 203020, "Pesquisador em biologia humana");
        [NotMapped] public static Profissao PesquisadorEmBiologiaVegetal => new Profissao(1802, 203025, "Pesquisador em biologia vegetal");
        [NotMapped] public static Profissao PesquisadorEmCienciasAgronomicas => new Profissao(1803, 203405, "Pesquisador em ciências agronômicas");
        [NotMapped] public static Profissao PesquisadorEmCienciasDaComputacaoEInformatica => new Profissao(1804, 203105, "Pesquisador em ciências da computação e informática");
        [NotMapped] public static Profissao PesquisadorEmCienciasDaEducacao => new Profissao(1805, 203515, "Pesquisador em ciências da educação");
        [NotMapped] public static Profissao PesquisadorEmCienciasDaPescaEAquicultura => new Profissao(1806, 203410, "Pesquisador em ciências da pesca e aqüicultura");
        [NotMapped] public static Profissao PesquisadorEmCienciasDaTerraEMeioAmbiente => new Profissao(1807, 203110, "Pesquisador em ciências da terra e meio ambiente");
        [NotMapped] public static Profissao PesquisadorEmCienciasDaZootecnia => new Profissao(1808, 203415, "Pesquisador em ciências da zootecnia");
        [NotMapped] public static Profissao PesquisadorEmCienciasFlorestais => new Profissao(1809, 203420, "Pesquisador em ciências florestais");
        [NotMapped] public static Profissao PesquisadorEmCienciasSociaisEHumanas => new Profissao(1810, 203505, "Pesquisador em ciências sociais e humanas");
        [NotMapped] public static Profissao PesquisadorEmEconomia => new Profissao(1811, 203510, "Pesquisador em economia");
        [NotMapped] public static Profissao PesquisadorEmFisica => new Profissao(1812, 203115, "Pesquisador em física");
        [NotMapped] public static Profissao PesquisadorEmHistoria => new Profissao(1813, 203520, "Pesquisador em história");
        [NotMapped] public static Profissao PesquisadorEmMatematica => new Profissao(1814, 203120, "Pesquisador em matemática");
        [NotMapped] public static Profissao PesquisadorEmMedicinaVeterinaria => new Profissao(1815, 203315, "Pesquisador em medicina veterinária");
        [NotMapped] public static Profissao PesquisadorEmMetrologia => new Profissao(1816, 201205, "Pesquisador em metrologia");
        [NotMapped] public static Profissao PesquisadorEmPsicologia => new Profissao(1817, 203525, "Pesquisador em psicologia");
        [NotMapped] public static Profissao PesquisadorEmQuimica => new Profissao(1818, 203125, "Pesquisador em química");
        [NotMapped] public static Profissao PesquisadorEmSaudeColetiva => new Profissao(1819, 203320, "Pesquisador em saúde coletiva");
        [NotMapped] public static Profissao Petrografo => new Profissao(1820, 213435, "Petrógrafo");
        [NotMapped] public static Profissao PicotadorDeCartoesJacquard => new Profissao(1821, 761366, "Picotador de cartões jacquard");
        [NotMapped] public static Profissao PilotoAgricola => new Profissao(1822, 341120, "Piloto agrícola");
        [NotMapped] public static Profissao PilotoComercialExcetoLinhasAereas => new Profissao(1823, 341105, "Piloto comercial (exceto linhas aéreas)");
        [NotMapped] public static Profissao PilotoComercialDeHelicopteroExcetoLinhasAereas => new Profissao(1824, 341110, "Piloto comercial de helicóptero (exceto linhas aéreas)");
        [NotMapped] public static Profissao PilotoDeAeronaves => new Profissao(1825, 215305, "Piloto de aeronaves");
        [NotMapped] public static Profissao PilotoDeCompeticaoAutomobilistica => new Profissao(1826, 377135, "Piloto de competição automobilística");
        [NotMapped] public static Profissao PilotoDeEnsaiosEmVoo => new Profissao(1827, 215310, "Piloto de ensaios em vôo");
        [NotMapped] public static Profissao PilotoFluvial => new Profissao(1828, 341230, "Piloto fluvial");
        [NotMapped] public static Profissao PintorAPincelERoloExcetoObrasEEstruturasMetalicas => new Profissao(1829, 723310, "Pintor a pincel e rolo (exceto obras e estruturas metálicas)");
        [NotMapped] public static Profissao PintorDeCeramicaAPincel => new Profissao(1830, 752430, "Pintor de cerâmica, a  pincel");
        [NotMapped] public static Profissao PintorDeEstruturasMetalicas => new Profissao(1831, 723315, "Pintor de estruturas metálicas");
        [NotMapped] public static Profissao PintorDeLetreiros => new Profissao(1832, 768625, "Pintor de letreiros");
        [NotMapped] public static Profissao PintorDeObras => new Profissao(1833, 716610, "Pintor de obras");
        [NotMapped] public static Profissao PintorDeVeiculosFabricacao => new Profissao(1834, 723320, "Pintor de veículos (fabricação)");
        [NotMapped] public static Profissao PintorDeVeiculosReparacao => new Profissao(1835, 991315, "Pintor de veículos (reparação)");
        [NotMapped] public static Profissao PintorPorImersao => new Profissao(1836, 723325, "Pintor por imersão");
        [NotMapped] public static Profissao PintorAPistolaExcetoObrasEEstruturasMetalicas => new Profissao(1837, 723330, "Pintor, a  pistola (exceto obras e estruturas metálicas)");
        [NotMapped] public static Profissao PipoqueiroAmbulante => new Profissao(1838, 524310, "Pipoqueiro ambulante");
        [NotMapped] public static Profissao Pirotecnico => new Profissao(1839, 812105, "Pirotécnico");
        [NotMapped] public static Profissao Pizzaiolo => new Profissao(1840, 513610, "Pizzaiolo");
        [NotMapped] public static Profissao Planejista => new Profissao(1841, 391120, "Planejista");
        [NotMapped] public static Profissao PlataformistaPetroleo => new Profissao(1842, 711325, "Plataformista (petróleo)");
        [NotMapped] public static Profissao PoceiroEdificacoes => new Profissao(1843, 717015, "Poceiro (edificações)");
        [NotMapped] public static Profissao Podologo => new Profissao(1844, 322110, "Podólogo");
        [NotMapped] public static Profissao Poeta => new Profissao(1845, 261525, "Poeta");
        [NotMapped] public static Profissao PolicialLegislativo => new Profissao(1846, 517225, "Policial legislativo");
        [NotMapped] public static Profissao PolicialRodoviarioFederal => new Profissao(1847, 517210, "Policial rodoviário federal");
        [NotMapped] public static Profissao PolidorDeMetais => new Profissao(1848, 721325, "Polidor de metais");
        [NotMapped] public static Profissao PolidorDePedras => new Profissao(1849, 712220, "Polidor de pedras");
        [NotMapped] public static Profissao PorteiroHotel => new Profissao(1850, 517405, "Porteiro (hotel)");
        [NotMapped] public static Profissao PorteiroDeEdificios => new Profissao(1851, 517410, "Porteiro de edifícios");
        [NotMapped] public static Profissao PracaDaAeronautica => new Profissao(1852, 10305, "Praça da aeronáutica");
        [NotMapped] public static Profissao PracaDaMarinha => new Profissao(1853, 10315, "Praça da marinha");
        [NotMapped] public static Profissao PracaDoExercito => new Profissao(1854, 10310, "Praça do exército");
        [NotMapped] public static Profissao PraticoDePortosDaMarinhaMercante => new Profissao(1855, 215145, "Prático de portos da marinha mercante");
        [NotMapped] public static Profissao Prefeito => new Profissao(1856, 111250, "Prefeito");
        [NotMapped] public static Profissao PrensadorDeCourosEPeles => new Profissao(1857, 762330, "Prensador de couros e peles");
        [NotMapped] public static Profissao PrensadorDeFrutasExcetoOleaginosas => new Profissao(1858, 841464, "Prensador de frutas (exceto oleaginosas)");
        [NotMapped] public static Profissao PrensistaOperadorDePrensa => new Profissao(1859, 724515, "Prensista (operador de prensa)");
        [NotMapped] public static Profissao PrensistaDeAglomerados => new Profissao(1860, 773210, "Prensista de aglomerados");
        [NotMapped] public static Profissao PrensistaDeCompensados => new Profissao(1861, 773215, "Prensista de compensados");
        [NotMapped] public static Profissao PreparadorDeAditivos => new Profissao(1862, 823130, "Preparador de aditivos");
        [NotMapped] public static Profissao PreparadorDeAglomerantes => new Profissao(1863, 773220, "Preparador de aglomerantes");
        [NotMapped] public static Profissao PreparadorDeAtleta => new Profissao(1864, 224115, "Preparador de atleta");
        [NotMapped] public static Profissao PreparadorDeBarbotina => new Profissao(1865, 823120, "Preparador de barbotina");
        [NotMapped] public static Profissao PreparadorDeCalcados => new Profissao(1866, 764115, "Preparador de calçados");
        [NotMapped] public static Profissao PreparadorDeCourosCurtidos => new Profissao(1867, 762340, "Preparador de couros curtidos");
        [NotMapped] public static Profissao PreparadorDeEsmaltesCeramica => new Profissao(1868, 823125, "Preparador de esmaltes (cerâmica)");
        [NotMapped] public static Profissao PreparadorDeEstruturasMetalicas => new Profissao(1869, 724220, "Preparador de estruturas metálicas");
        [NotMapped] public static Profissao PreparadorDeFumoNaFabricacaoDeCharutos => new Profissao(1870, 842205, "Preparador de fumo na fabricação de charutos");
        [NotMapped] public static Profissao PreparadorDeMaquinasFerramenta => new Profissao(1871, 721225, "Preparador de máquinas-ferramenta");
        [NotMapped] public static Profissao PreparadorDeMassaFabricacaoDeAbrasivos => new Profissao(1872, 823105, "Preparador de massa (fabricação de abrasivos)");
        [NotMapped] public static Profissao PreparadorDeMassaFabricacaoDeVidro => new Profissao(1873, 823110, "Preparador de massa (fabricação de vidro)");
        [NotMapped] public static Profissao PreparadorDeMassaDeArgila => new Profissao(1874, 823115, "Preparador de massa de argila");
        [NotMapped] public static Profissao PreparadorDeMatrizesDeCorteEVinco => new Profissao(1875, 766325, "Preparador de matrizes de corte e vinco");
        [NotMapped] public static Profissao PreparadorDeMeladoEEssenciaDeFumo => new Profissao(1876, 842105, "Preparador de melado e essência de fumo");
        [NotMapped] public static Profissao PreparadorDePanelasLingotamento => new Profissao(1877, 722235, "Preparador de panelas (lingotamento)");
        [NotMapped] public static Profissao PreparadorDeRacoes => new Profissao(1878, 841468, "Preparador de rações");
        [NotMapped] public static Profissao PreparadorDeSolasEPalmilhas => new Profissao(1879, 764120, "Preparador de solas e palmilhas");
        [NotMapped] public static Profissao PreparadorDeSucataEAparas => new Profissao(1880, 821445, "Preparador de sucata e aparas");
        [NotMapped] public static Profissao PreparadorDeTintas => new Profissao(1881, 311715, "Preparador de tintas");
        [NotMapped] public static Profissao PreparadorDeTintasFabricaDeTecidos => new Profissao(1882, 311720, "Preparador de tintas (fábrica de tecidos)");
        [NotMapped] public static Profissao PreparadorFisico => new Profissao(1883, 224120, "Preparador físico");
        [NotMapped] public static Profissao PresidenteDaRepublica => new Profissao(1884, 111205, "Presidente da república");
        [NotMapped] public static Profissao PrimeiroOficialDeMaquinasDaMarinhaMercante => new Profissao(1885, 215210, "Primeiro oficial de máquinas da marinha mercante");
        [NotMapped] public static Profissao PrimeiroTenenteDePoliciaMilitar => new Profissao(1886, 20305, "Primeiro tenente de polícia militar");
        [NotMapped] public static Profissao ProcessadorDeFumo => new Profissao(1887, 842110, "Processador de fumo");
        [NotMapped] public static Profissao ProcuradorAutarquico => new Profissao(1888, 241210, "Procurador autárquico");
        [NotMapped] public static Profissao ProcuradorDaAssistenciaJudiciaria => new Profissao(1889, 242410, "Procurador da assistência judiciária");
        [NotMapped] public static Profissao ProcuradorDaFazendaNacional => new Profissao(1890, 241215, "Procurador da fazenda nacional");
        [NotMapped] public static Profissao ProcuradorDaRepublica => new Profissao(1891, 242205, "Procurador da república");
        [NotMapped] public static Profissao ProcuradorDeJustica => new Profissao(1892, 242210, "Procurador de justiça");
        [NotMapped] public static Profissao ProcuradorDeJusticaMilitar => new Profissao(1893, 242215, "Procurador de justiça militar");
        [NotMapped] public static Profissao ProcuradorDoEstado => new Profissao(1894, 241220, "Procurador do estado");
        [NotMapped] public static Profissao ProcuradorDoMunicipio => new Profissao(1895, 241225, "Procurador do município");
        [NotMapped] public static Profissao ProcuradorDoTrabalho => new Profissao(1896, 242220, "Procurador do trabalho");
        [NotMapped] public static Profissao ProcuradorFederal => new Profissao(1897, 241230, "Procurador federal");
        [NotMapped] public static Profissao ProcuradorFundacional => new Profissao(1898, 241235, "Procurador fundacional");
        [NotMapped] public static Profissao ProcuradorRegionalDaRepublica => new Profissao(1899, 242225, "Procurador regional da república");
        [NotMapped] public static Profissao ProcuradorRegionalDoTrabalho => new Profissao(1900, 242230, "Procurador regional do trabalho");
        [NotMapped] public static Profissao ProdutorAgricolaPolivalente => new Profissao(1901, 612005, "Produtor agrícola polivalente");
        [NotMapped] public static Profissao ProdutorAgropecuarioEmGeral => new Profissao(1902, 611005, "Produtor agropecuário, em geral");
        [NotMapped] public static Profissao ProdutorCinematografico => new Profissao(1903, 262110, "Produtor cinematográfico");
        [NotMapped] public static Profissao ProdutorCultural => new Profissao(1904, 262105, "Produtor cultural");
        [NotMapped] public static Profissao ProdutorDaCulturaDeAmendoim => new Profissao(1905, 612705, "Produtor da cultura de amendoim");
        [NotMapped] public static Profissao ProdutorDaCulturaDeCanola => new Profissao(1906, 612710, "Produtor da cultura de canola");
        [NotMapped] public static Profissao ProdutorDaCulturaDeCocoDaBaia => new Profissao(1907, 612715, "Produtor da cultura de coco-da-baia");
        [NotMapped] public static Profissao ProdutorDaCulturaDeDende => new Profissao(1908, 612720, "Produtor da cultura de dendê");
        [NotMapped] public static Profissao ProdutorDaCulturaDeGirassol => new Profissao(1909, 612725, "Produtor da cultura de girassol");
        [NotMapped] public static Profissao ProdutorDaCulturaDeLinho => new Profissao(1910, 612730, "Produtor da cultura de linho");
        [NotMapped] public static Profissao ProdutorDaCulturaDeMamona => new Profissao(1911, 612735, "Produtor da cultura de mamona");
        [NotMapped] public static Profissao ProdutorDaCulturaDeSoja => new Profissao(1912, 612740, "Produtor da cultura de soja");
        [NotMapped] public static Profissao ProdutorDeAlgodao => new Profissao(1913, 612205, "Produtor de algodão");
        [NotMapped] public static Profissao ProdutorDeArroz => new Profissao(1914, 612105, "Produtor de arroz");
        [NotMapped] public static Profissao ProdutorDeArvoresFrutiferas => new Profissao(1915, 612505, "Produtor de árvores frutíferas");
        [NotMapped] public static Profissao ProdutorDeCacau => new Profissao(1916, 612610, "Produtor de cacau");
        [NotMapped] public static Profissao ProdutorDeCanaDeAcucar => new Profissao(1917, 612110, "Produtor de cana-de-açúcar");
        [NotMapped] public static Profissao ProdutorDeCereaisDeInverno => new Profissao(1918, 612115, "Produtor de cereais de inverno");
        [NotMapped] public static Profissao ProdutorDeCuraua => new Profissao(1919, 612210, "Produtor de curauá");
        [NotMapped] public static Profissao ProdutorDeErvaMate => new Profissao(1920, 612615, "Produtor de erva-mate");
        [NotMapped] public static Profissao ProdutorDeEspeciarias => new Profissao(1921, 612805, "Produtor de especiarias");
        [NotMapped] public static Profissao ProdutorDeEspeciesFrutiferasRasteiras => new Profissao(1922, 612510, "Produtor de espécies frutíferas rasteiras");
        [NotMapped] public static Profissao ProdutorDeEspeciesFrutiferasTrepadeiras => new Profissao(1923, 612515, "Produtor de espécies frutíferas trepadeiras");
        [NotMapped] public static Profissao ProdutorDeFloresDeCorte => new Profissao(1924, 612405, "Produtor de flores de corte");
        [NotMapped] public static Profissao ProdutorDeFloresEmVaso => new Profissao(1925, 612410, "Produtor de flores em vaso");
        [NotMapped] public static Profissao ProdutorDeForracoes => new Profissao(1926, 612415, "Produtor de forrações");
        [NotMapped] public static Profissao ProdutorDeFumo => new Profissao(1927, 612620, "Produtor de fumo");
        [NotMapped] public static Profissao ProdutorDeGramineasForrageiras => new Profissao(1928, 612120, "Produtor de gramíneas forrageiras");
        [NotMapped] public static Profissao ProdutorDeGuarana => new Profissao(1929, 612625, "Produtor de guaraná");
        [NotMapped] public static Profissao ProdutorDeJuta => new Profissao(1930, 612215, "Produtor de juta");
        [NotMapped] public static Profissao ProdutorDeMilhoESorgo => new Profissao(1931, 612125, "Produtor de milho e sorgo");
        [NotMapped] public static Profissao ProdutorDeModa => new Profissao(1932, 375125, "Produtor de moda");
        [NotMapped] public static Profissao ProdutorDePlantasAromaticasEMedicinais => new Profissao(1933, 612810, "Produtor de plantas aromáticas e medicinais");
        [NotMapped] public static Profissao ProdutorDePlantasOrnamentais => new Profissao(1934, 612420, "Produtor de plantas ornamentais");
        [NotMapped] public static Profissao ProdutorDeRadio => new Profissao(1935, 262115, "Produtor de rádio");
        [NotMapped] public static Profissao ProdutorDeRami => new Profissao(1936, 612220, "Produtor de rami");
        [NotMapped] public static Profissao ProdutorDeSisal => new Profissao(1937, 612225, "Produtor de sisal");
        [NotMapped] public static Profissao ProdutorDeTeatro => new Profissao(1938, 262120, "Produtor de teatro");
        [NotMapped] public static Profissao ProdutorDeTelevisao => new Profissao(1939, 262125, "Produtor de televisão");
        [NotMapped] public static Profissao ProdutorDeTexto => new Profissao(1940, 261130, "Produtor de texto");
        [NotMapped] public static Profissao ProdutorNaOlericulturaDeFrutosESementes => new Profissao(1941, 612320, "Produtor na olericultura de frutos e sementes");
        [NotMapped] public static Profissao ProdutorNaOlericulturaDeLegumes => new Profissao(1942, 612305, "Produtor na olericultura de legumes");
        [NotMapped] public static Profissao ProdutorNaOlericulturaDeRaizesBulbosETuberculos => new Profissao(1943, 612310, "Produtor na olericultura de raízes, bulbos e tubérculos");
        [NotMapped] public static Profissao ProdutorNaOlericulturaDeTalosFolhasEFlores => new Profissao(1944, 612315, "Produtor na olericultura de talos, folhas e flores");
        [NotMapped] public static Profissao Proeiro => new Profissao(1945, 631415, "Proeiro");
        [NotMapped] public static Profissao ProfessorDaEducacaoDeJovensEAdultosDoEnsinoFundamentalPrimeiraAQuartaSerie => new Profissao(1946, 231205, "Professor da  educação de jovens e adultos do ensino fundamental (primeira a quarta série)");
        [NotMapped] public static Profissao ProfessorDaAreaDeMeioAmbiente => new Profissao(1947, 233105, "Professor da área de meio ambiente");
        [NotMapped] public static Profissao ProfessorDeAdministracao => new Profissao(1948, 234810, "Professor de administração");
        [NotMapped] public static Profissao ProfessorDeAlunosComDeficienciaAuditivaESurdos => new Profissao(1949, 239205, "Professor de alunos com deficiência auditiva e surdos");
        [NotMapped] public static Profissao ProfessorDeAlunosComDeficienciaFisica => new Profissao(1950, 239210, "Professor de alunos com deficiência física");
        [NotMapped] public static Profissao ProfessorDeAlunosComDeficienciaMental => new Profissao(1951, 239215, "Professor de alunos com deficiência mental");
        [NotMapped] public static Profissao ProfessorDeAlunosComDeficienciaMultipla => new Profissao(1952, 239220, "Professor de alunos com deficiência múltipla");
        [NotMapped] public static Profissao ProfessorDeAlunosComDeficienciaVisual => new Profissao(1953, 239225, "Professor de alunos com deficiência visual");
        [NotMapped] public static Profissao ProfessorDeAntropologiaDoEnsinoSuperior => new Profissao(1954, 234705, "Professor de antropologia do ensino superior");
        [NotMapped] public static Profissao ProfessorDeArquitetura => new Profissao(1955, 234305, "Professor de arquitetura");
        [NotMapped] public static Profissao ProfessorDeArquivologiaDoEnsinoSuperior => new Profissao(1956, 234710, "Professor de arquivologia do ensino superior");
        [NotMapped] public static Profissao ProfessorDeArtesDoEspetaculoNoEnsinoSuperior => new Profissao(1957, 234905, "Professor de artes do espetáculo no ensino superior");
        [NotMapped] public static Profissao ProfessorDeArtesNoEnsinoMedio => new Profissao(1958, 232105, "Professor de artes no ensino médio");
        [NotMapped] public static Profissao ProfessorDeArtesVisuaisNoEnsinoSuperiorArtesPlasticasEMultimidia => new Profissao(1959, 234910, "Professor de artes visuais no ensino superior (artes plásticas e multimídia)");
        [NotMapped] public static Profissao ProfessorDeAstronomiaEnsinoSuperior => new Profissao(1960, 234215, "Professor de astronomia (ensino superior)");
        [NotMapped] public static Profissao ProfessorDeBiblioteconomiaDoEnsinoSuperior => new Profissao(1961, 234715, "Professor de biblioteconomia do ensino superior");
        [NotMapped] public static Profissao ProfessorDeBiologiaNoEnsinoMedio => new Profissao(1962, 232110, "Professor de biologia no ensino médio");
        [NotMapped] public static Profissao ProfessorDeCienciaPoliticaDoEnsinoSuperior => new Profissao(1963, 234720, "Professor de ciência política do ensino superior");
        [NotMapped] public static Profissao ProfessorDeCienciasBiologicasDoEnsinoSuperior => new Profissao(1964, 234405, "Professor de ciências biológicas do ensino superior");
        [NotMapped] public static Profissao ProfessorDeCienciasExatasENaturaisDoEnsinoFundamental => new Profissao(1965, 231305, "Professor de ciências exatas e naturais do ensino fundamental");
        [NotMapped] public static Profissao ProfessorDeComputacaoNoEnsinoSuperior => new Profissao(1966, 234120, "Professor de computação (no ensino superior)");
        [NotMapped] public static Profissao ProfessorDeComunicacaoSocialDoEnsinoSuperior => new Profissao(1967, 234725, "Professor de comunicação social do ensino superior");
        [NotMapped] public static Profissao ProfessorDeContabilidade => new Profissao(1968, 234815, "Professor de contabilidade");
        [NotMapped] public static Profissao ProfessorDeDanca => new Profissao(1969, 262830, "Professor de dança");
        [NotMapped] public static Profissao ProfessorDeDesenhoTecnico => new Profissao(1970, 233110, "Professor de desenho técnico");
        [NotMapped] public static Profissao ProfessorDeDireitoDoEnsinoSuperior => new Profissao(1971, 234730, "Professor de direito do ensino superior");
        [NotMapped] public static Profissao ProfessorDeDisciplinasPedagogicasNoEnsinoMedio => new Profissao(1972, 232115, "Professor de disciplinas pedagógicas no ensino médio");
        [NotMapped] public static Profissao ProfessorDeEconomia => new Profissao(1973, 234805, "Professor de economia");
        [NotMapped] public static Profissao ProfessorDeEducacaoArtisticaDoEnsinoFundamental => new Profissao(1974, 231310, "Professor de educação artística do ensino fundamental");
        [NotMapped] public static Profissao ProfessorDeEducacaoFisicaDoEnsinoFundamental => new Profissao(1975, 231315, "Professor de educação física do ensino fundamental");
        [NotMapped] public static Profissao ProfessorDeEducacaoFisicaNoEnsinoMedio => new Profissao(1976, 232120, "Professor de educação física no ensino médio");
        [NotMapped] public static Profissao ProfessorDeEducacaoFisicaNoEnsinoSuperior => new Profissao(1977, 234410, "Professor de educação física no ensino superior");
        [NotMapped] public static Profissao ProfessorDeEnfermagemDoEnsinoSuperior => new Profissao(1978, 234415, "Professor de enfermagem do ensino superior");
        [NotMapped] public static Profissao ProfessorDeEngenharia => new Profissao(1979, 234310, "Professor de engenharia");
        [NotMapped] public static Profissao ProfessorDeEnsinoSuperiorNaAreaDeDidatica => new Profissao(1980, 234505, "Professor de ensino superior na área de didática");
        [NotMapped] public static Profissao ProfessorDeEnsinoSuperiorNaAreaDeOrientacaoEducacional => new Profissao(1981, 234510, "Professor de ensino superior na área de orientação educacional");
        [NotMapped] public static Profissao ProfessorDeEnsinoSuperiorNaAreaDePesquisaEducacional => new Profissao(1982, 234515, "Professor de ensino superior na área de pesquisa educacional");
        [NotMapped] public static Profissao ProfessorDeEnsinoSuperiorNaAreaDePraticaDeEnsino => new Profissao(1983, 234520, "Professor de ensino superior na área de prática de ensino");
        [NotMapped] public static Profissao ProfessorDeEstatisticaNoEnsinoSuperior => new Profissao(1984, 234115, "Professor de estatística (no ensino superior)");
        [NotMapped] public static Profissao ProfessorDeFarmaciaEBioquimica => new Profissao(1985, 234420, "Professor de farmácia e bioquímica");
        [NotMapped] public static Profissao ProfessorDeFilologiaECriticaTextual => new Profissao(1986, 234676, "Professor de filologia e crítica textual");
        [NotMapped] public static Profissao ProfessorDeFilosofiaDoEnsinoSuperior => new Profissao(1987, 234735, "Professor de filosofia do ensino superior");
        [NotMapped] public static Profissao ProfessorDeFilosofiaNoEnsinoMedio => new Profissao(1988, 232125, "Professor de filosofia no ensino médio");
        [NotMapped] public static Profissao ProfessorDeFisicaEnsinoSuperior => new Profissao(1989, 234205, "Professor de física (ensino superior)");
        [NotMapped] public static Profissao ProfessorDeFisicaNoEnsinoMedio => new Profissao(1990, 232130, "Professor de física no ensino médio");
        [NotMapped] public static Profissao ProfessorDeFisioterapia => new Profissao(1991, 234425, "Professor de fisioterapia");
        [NotMapped] public static Profissao ProfessorDeFonoaudiologia => new Profissao(1992, 234430, "Professor de fonoaudiologia");
        [NotMapped] public static Profissao ProfessorDeGeofisica => new Profissao(1993, 234315, "Professor de geofísica");
        [NotMapped] public static Profissao ProfessorDeGeografiaDoEnsinoFundamental => new Profissao(1994, 231320, "Professor de geografia do ensino fundamental");
        [NotMapped] public static Profissao ProfessorDeGeografiaDoEnsinoSuperior => new Profissao(1995, 234740, "Professor de geografia do ensino superior");
        [NotMapped] public static Profissao ProfessorDeGeografiaNoEnsinoMedio => new Profissao(1996, 232135, "Professor de geografia no ensino médio");
        [NotMapped] public static Profissao ProfessorDeGeologia => new Profissao(1997, 234320, "Professor de geologia");
        [NotMapped] public static Profissao ProfessorDeHistoriaDoEnsinoFundamental => new Profissao(1998, 231325, "Professor de história do ensino fundamental");
        [NotMapped] public static Profissao ProfessorDeHistoriaDoEnsinoSuperior => new Profissao(1999, 234745, "Professor de história do ensino superior");
        [NotMapped] public static Profissao ProfessorDeHistoriaNoEnsinoMedio => new Profissao(2000, 232140, "Professor de história no ensino médio");
        [NotMapped] public static Profissao ProfessorDeJornalismo => new Profissao(2001, 234750, "Professor de jornalismo");
        [NotMapped] public static Profissao ProfessorDeLinguaAlema => new Profissao(2002, 234604, "Professor de língua alemã");
        [NotMapped] public static Profissao ProfessorDeLinguaELiteraturaBrasileiraNoEnsinoMedio => new Profissao(2003, 232145, "Professor de língua e literatura brasileira no ensino médio");
        [NotMapped] public static Profissao ProfessorDeLinguaEspanhola => new Profissao(2004, 234620, "Professor de língua espanhola");
        [NotMapped] public static Profissao ProfessorDeLinguaEstrangeiraModernaDoEnsinoFundamental => new Profissao(2005, 231330, "Professor de língua estrangeira moderna do ensino fundamental");
        [NotMapped] public static Profissao ProfessorDeLinguaEstrangeiraModernaNoEnsinoMedio => new Profissao(2006, 232150, "Professor de língua estrangeira moderna no ensino médio");
        [NotMapped] public static Profissao ProfessorDeLinguaFrancesa => new Profissao(2007, 234612, "Professor de língua francesa");
        [NotMapped] public static Profissao ProfessorDeLinguaInglesa => new Profissao(2008, 234616, "Professor de língua inglesa");
        [NotMapped] public static Profissao ProfessorDeLinguaItaliana => new Profissao(2009, 234608, "Professor de língua italiana");
        [NotMapped] public static Profissao ProfessorDeLinguaPortuguesa => new Profissao(2010, 234624, "Professor de língua portuguesa");
        [NotMapped] public static Profissao ProfessorDeLinguaPortuguesaDoEnsinoFundamental => new Profissao(2011, 231335, "Professor de língua portuguesa do ensino fundamental");
        [NotMapped] public static Profissao ProfessorDeLinguasEstrangeirasModernas => new Profissao(2012, 234668, "Professor de línguas estrangeiras modernas");
        [NotMapped] public static Profissao ProfessorDeLinguisticaELinguisticaAplicada => new Profissao(2013, 234672, "Professor de lingüística e lingüística aplicada");
        [NotMapped] public static Profissao ProfessorDeLiteraturaAlema => new Profissao(2014, 234636, "Professor de literatura alemã");
        [NotMapped] public static Profissao ProfessorDeLiteraturaBrasileira => new Profissao(2015, 234628, "Professor de literatura brasileira");
        [NotMapped] public static Profissao ProfessorDeLiteraturaComparada => new Profissao(2016, 234640, "Professor de literatura comparada");
        [NotMapped] public static Profissao ProfessorDeLiteraturaDeLinguasEstrangeirasModernas => new Profissao(2017, 234660, "Professor de literatura de línguas estrangeiras modernas");
        [NotMapped] public static Profissao ProfessorDeLiteraturaEspanhola => new Profissao(2018, 234644, "Professor de literatura espanhola");
        [NotMapped] public static Profissao ProfessorDeLiteraturaFrancesa => new Profissao(2019, 234648, "Professor de literatura francesa");
        [NotMapped] public static Profissao ProfessorDeLiteraturaInglesa => new Profissao(2020, 234652, "Professor de literatura inglesa");
        [NotMapped] public static Profissao ProfessorDeLiteraturaItaliana => new Profissao(2021, 234656, "Professor de literatura italiana");
        [NotMapped] public static Profissao ProfessorDeLiteraturaPortuguesa => new Profissao(2022, 234632, "Professor de literatura portuguesa");
        [NotMapped] public static Profissao ProfessorDeMatematicaAplicadaNoEnsinoSuperior => new Profissao(2023, 234105, "Professor de matemática aplicada (no ensino superior)");
        [NotMapped] public static Profissao ProfessorDeMatematicaDoEnsinoFundamental => new Profissao(2024, 231340, "Professor de matemática do ensino fundamental");
        [NotMapped] public static Profissao ProfessorDeMatematicaNoEnsinoMedio => new Profissao(2025, 232155, "Professor de matemática no ensino médio");
        [NotMapped] public static Profissao ProfessorDeMatematicaPuraNoEnsinoSuperior => new Profissao(2026, 234110, "Professor de matemática pura (no ensino superior)");
        [NotMapped] public static Profissao ProfessorDeMedicina => new Profissao(2027, 234435, "Professor de medicina");
        [NotMapped] public static Profissao ProfessorDeMedicinaVeterinaria => new Profissao(2028, 234440, "Professor de medicina veterinária");
        [NotMapped] public static Profissao ProfessorDeMuseologiaDoEnsinoSuperior => new Profissao(2029, 234755, "Professor de museologia do ensino superior");
        [NotMapped] public static Profissao ProfessorDeMusicaNoEnsinoSuperior => new Profissao(2030, 234915, "Professor de música no ensino superior");
        [NotMapped] public static Profissao ProfessorDeNivelMedioNaEducacaoInfantil => new Profissao(2031, 331105, "Professor de nível médio na educação infantil");
        [NotMapped] public static Profissao ProfessorDeNivelMedioNoEnsinoFundamental => new Profissao(2032, 331205, "Professor de nível médio no ensino fundamental");
        [NotMapped] public static Profissao ProfessorDeNivelMedioNoEnsinoProfissionalizante => new Profissao(2033, 331305, "Professor de nível médio no ensino profissionalizante");
        [NotMapped] public static Profissao ProfessorDeNivelSuperiorDoEnsinoFundamentalPrimeiraAQuartaSerie => new Profissao(2034, 231210, "Professor de nível superior do ensino fundamental (primeira a quarta série)");
        [NotMapped] public static Profissao ProfessorDeNivelSuperiorNaEducacaoInfantilQuatroASeisAnos => new Profissao(2035, 231105, "Professor de nível superior na educação infantil (quatro a seis anos)");
        [NotMapped] public static Profissao ProfessorDeNivelSuperiorNaEducacaoInfantilZeroATresAnos => new Profissao(2036, 231110, "Professor de nível superior na educação infantil (zero a três anos)");
        [NotMapped] public static Profissao ProfessorDeNutricao => new Profissao(2037, 234445, "Professor de nutrição");
        [NotMapped] public static Profissao ProfessorDeOdontologia => new Profissao(2038, 234450, "Professor de odontologia");
        [NotMapped] public static Profissao ProfessorDeOutrasLinguasELiteraturas => new Profissao(2039, 234664, "Professor de outras línguas e literaturas");
        [NotMapped] public static Profissao ProfessorDePesquisaOperacionalNoEnsinoSuperior => new Profissao(2040, 234125, "Professor de pesquisa operacional (no ensino superior)");
        [NotMapped] public static Profissao ProfessorDePsicologiaDoEnsinoSuperior => new Profissao(2041, 234760, "Professor de psicologia do ensino superior");
        [NotMapped] public static Profissao ProfessorDePsicologiaNoEnsinoMedio => new Profissao(2042, 232160, "Professor de psicologia no ensino médio");
        [NotMapped] public static Profissao ProfessorDeQuimicaEnsinoSuperior => new Profissao(2043, 234210, "Professor de química (ensino superior)");
        [NotMapped] public static Profissao ProfessorDeQuimicaNoEnsinoMedio => new Profissao(2044, 232165, "Professor de química no ensino médio");
        [NotMapped] public static Profissao ProfessorDeSemiotica => new Profissao(2045, 234680, "Professor de semiótica");
        [NotMapped] public static Profissao ProfessorDeServicoSocialDoEnsinoSuperior => new Profissao(2046, 234765, "Professor de serviço social do ensino superior");
        [NotMapped] public static Profissao ProfessorDeSociologiaDoEnsinoSuperior => new Profissao(2047, 234770, "Professor de sociologia do ensino superior");
        [NotMapped] public static Profissao ProfessorDeSociologiaNoEnsinoMedio => new Profissao(2048, 232170, "Professor de sociologia no ensino médio");
        [NotMapped] public static Profissao ProfessorDeTecnicasAgricolas => new Profissao(2049, 233115, "Professor de técnicas agrícolas");
        [NotMapped] public static Profissao ProfessorDeTecnicasComerciaisESecretariais => new Profissao(2050, 233120, "Professor de técnicas comerciais e secretariais");
        [NotMapped] public static Profissao ProfessorDeTecnicasDeEnfermagem => new Profissao(2051, 233125, "Professor de técnicas de enfermagem");
        [NotMapped] public static Profissao ProfessorDeTecnicasERecursosAudiovisuais => new Profissao(2052, 239420, "Professor de técnicas e recursos audiovisuais");
        [NotMapped] public static Profissao ProfessorDeTecnicasIndustriais => new Profissao(2053, 233130, "Professor de técnicas industriais");
        [NotMapped] public static Profissao ProfessorDeTecnologiaECalculoTecnico => new Profissao(2054, 233135, "Professor de tecnologia e cálculo técnico");
        [NotMapped] public static Profissao ProfessorDeTeoriaDaLiteratura => new Profissao(2055, 234684, "Professor de teoria da literatura");
        [NotMapped] public static Profissao ProfessorDeTerapiaOcupacional => new Profissao(2056, 234455, "Professor de terapia ocupacional");
        [NotMapped] public static Profissao ProfessorDeZootecniaDoEnsinoSuperior => new Profissao(2057, 234460, "Professor de zootecnia do ensino superior");
        [NotMapped] public static Profissao ProfessorInstrutorDeEnsinoEAprendizagemAgroflorestal => new Profissao(2058, 233220, "Professor instrutor de ensino e aprendizagem agroflorestal");
        [NotMapped] public static Profissao ProfessorInstrutorDeEnsinoEAprendizagemEmServicos => new Profissao(2059, 233225, "Professor instrutor de ensino e aprendizagem em serviços");
        [NotMapped] public static Profissao ProfessorLeigoNoEnsinoFundamental => new Profissao(2060, 332105, "Professor leigo no ensino fundamental");
        [NotMapped] public static Profissao ProfessorPraticoNoEnsinoProfissionalizante => new Profissao(2061, 332205, "Professor prático no ensino profissionalizante");
        [NotMapped] public static Profissao ProfessoresDeCursosLivres => new Profissao(2062, 333115, "Professores de cursos livres");
        [NotMapped] public static Profissao ProfissionalDeAtletismo => new Profissao(2063, 377140, "Profissional de atletismo");
        [NotMapped] public static Profissao ProfissionalDeEducacaoFisicaNaSaude => new Profissao(2064, 224140, "Profissional de educação física na saúde");
        [NotMapped] public static Profissao ProfissionalDeRelacoesComInvestidores => new Profissao(2065, 252550, "Profissional de relações com investidores");
        [NotMapped] public static Profissao ProfissionalDeRelacoesInstitucionaisEGovernamentais => new Profissao(2066, 142345, "Profissional de relações institucionais e governamentais");
        [NotMapped] public static Profissao ProfissionalDoSexo => new Profissao(2067, 519805, "Profissional do sexo");
        [NotMapped] public static Profissao ProfissonalDeRelacoesInternacionais => new Profissao(2068, 142350, "Profissonal de relações internacionais");
        [NotMapped] public static Profissao ProgramadorDeMaquinasFerramentaComComandoNumerico => new Profissao(2069, 317115, "Programador de máquinas - ferramenta com comando numérico");
        [NotMapped] public static Profissao ProgramadorVisualGrafico => new Profissao(2070, 766155, "Programador visual gráfico");
        [NotMapped] public static Profissao ProjetistaDeMoveis => new Profissao(2071, 318805, "Projetista de móveis");
        [NotMapped] public static Profissao ProjetistaDeSistemasDeAudio => new Profissao(2072, 374135, "Projetista de sistemas de áudio");
        [NotMapped] public static Profissao ProjetistaDeSom => new Profissao(2073, 374120, "Projetista de som");
        [NotMapped] public static Profissao PromotorDeJustica => new Profissao(2074, 242235, "Promotor de justiça");
        [NotMapped] public static Profissao PromotorDeVendas => new Profissao(2075, 521115, "Promotor de vendas");
        [NotMapped] public static Profissao PromotorDeVendasEspecializado => new Profissao(2076, 354130, "Promotor de vendas especializado");
        [NotMapped] public static Profissao PropagandistaDeProdutosFamaceuticos => new Profissao(2077, 354150, "Propagandista de produtos famacêuticos");
        [NotMapped] public static Profissao ProteticoDentario => new Profissao(2078, 322410, "Protético dentário");
        [NotMapped] public static Profissao Psicanalista => new Profissao(2079, 251550, "Psicanalista");
        [NotMapped] public static Profissao PsicologoAcupunturista => new Profissao(2080, 251555, "Psicólogo acupunturista");
        [NotMapped] public static Profissao PsicologoClinico => new Profissao(2081, 251510, "Psicólogo clínico");
        [NotMapped] public static Profissao PsicologoDoEsporte => new Profissao(2082, 251515, "Psicólogo do esporte");
        [NotMapped] public static Profissao PsicologoDoTrabalho => new Profissao(2083, 251540, "Psicólogo do trabalho");
        [NotMapped] public static Profissao PsicologoDoTransito => new Profissao(2084, 251535, "Psicólogo do trânsito");
        [NotMapped] public static Profissao PsicologoEducacional => new Profissao(2085, 251505, "Psicólogo educacional");
        [NotMapped] public static Profissao PsicologoHospitalar => new Profissao(2086, 251520, "Psicólogo hospitalar");
        [NotMapped] public static Profissao PsicologoJuridico => new Profissao(2087, 251525, "Psicólogo jurídico");
        [NotMapped] public static Profissao PsicologoSocial => new Profissao(2088, 251530, "Psicólogo social");
        [NotMapped] public static Profissao Psicomotricista => new Profissao(2089, 223915, "Psicomotricista");
        [NotMapped] public static Profissao Psicopedagogo => new Profissao(2090, 239425, "Psicopedagogo");
        [NotMapped] public static Profissao Publicitario => new Profissao(2091, 253115, "Publicitário");
        [NotMapped] public static Profissao Pugilista => new Profissao(2092, 377145, "Pugilista");
        [NotMapped] public static Profissao QueijeiroNaFabricacaoDeLaticinio => new Profissao(2093, 848210, "Queijeiro na fabricação de laticínio");
        [NotMapped] public static Profissao Quimico => new Profissao(2094, 213205, "Químico");
        [NotMapped] public static Profissao QuimicoIndustrial => new Profissao(2095, 213210, "Químico industrial");
        [NotMapped] public static Profissao Quiropraxista => new Profissao(2096, 226105, "Quiropraxista");
        [NotMapped] public static Profissao RachadorDeCourosEPeles => new Profissao(2097, 762125, "Rachador de couros e peles");
        [NotMapped] public static Profissao Radiotelegrafista => new Profissao(2098, 372210, "Radiotelegrafista");
        [NotMapped] public static Profissao Raizeiro => new Profissao(2099, 632010, "Raizeiro");
        [NotMapped] public static Profissao RebaixadorDeCouros => new Profissao(2100, 762220, "Rebaixador de couros");
        [NotMapped] public static Profissao RebarbadorDeMetal => new Profissao(2101, 821450, "Rebarbador de metal");
        [NotMapped] public static Profissao RebitadorAMarteloPneumatico => new Profissao(2102, 724215, "Rebitador a  martelo pneumático");
        [NotMapped] public static Profissao RebitadorAMao => new Profissao(2103, 724230, "Rebitador, a  mão");
        [NotMapped] public static Profissao RecebedorDeApostasLoteria => new Profissao(2104, 421205, "Recebedor de apostas (loteria)");
        [NotMapped] public static Profissao RecebedorDeApostasTurfe => new Profissao(2105, 421210, "Recebedor de apostas (turfe)");
        [NotMapped] public static Profissao RecepcionistaDeBanco => new Profissao(2106, 422125, "Recepcionista de banco");
        [NotMapped] public static Profissao RecepcionistaDeCasasDeEspetaculos => new Profissao(2107, 519945, "Recepcionista de casas de espetáculos");
        [NotMapped] public static Profissao RecepcionistaDeConsultorioMedicoOuDentario => new Profissao(2108, 422110, "Recepcionista de consultório médico ou dentário");
        [NotMapped] public static Profissao RecepcionistaDeHotel => new Profissao(2109, 422120, "Recepcionista de hotel");
        [NotMapped] public static Profissao RecepcionistaDeSeguroSaude => new Profissao(2110, 422115, "Recepcionista de seguro saúde");
        [NotMapped] public static Profissao RecepcionistaEmGeral => new Profissao(2111, 422105, "Recepcionista, em geral");
        [NotMapped] public static Profissao Recreador => new Profissao(2112, 371410, "Recreador");
        [NotMapped] public static Profissao RecreadorDeAcantonamento => new Profissao(2113, 371405, "Recreador de acantonamento");
        [NotMapped] public static Profissao RecuperadorDeGuiasECilindros => new Profissao(2114, 821335, "Recuperador de guias e cilindros");
        [NotMapped] public static Profissao RedatorDePublicidade => new Profissao(2115, 253110, "Redator de publicidade");
        [NotMapped] public static Profissao RedatorDeTextosTecnicos => new Profissao(2116, 261530, "Redator de textos técnicos");
        [NotMapped] public static Profissao Redeiro => new Profissao(2117, 768120, "Redeiro");
        [NotMapped] public static Profissao RedeiroPesca => new Profissao(2118, 631420, "Redeiro (pesca)");
        [NotMapped] public static Profissao RefinadorDeOleoEGordura => new Profissao(2119, 841472, "Refinador de óleo e gordura");
        [NotMapped] public static Profissao RefinadorDeSal => new Profissao(2120, 841210, "Refinador de sal");
        [NotMapped] public static Profissao RegistradorDeCancer => new Profissao(2121, 415305, "Registrador de câncer");
        [NotMapped] public static Profissao RejuntadorDeRevestimentos => new Profissao(2122, 716540, "Rejuntador de revestimentos");
        [NotMapped] public static Profissao RelacoesPublicas => new Profissao(2123, 142325, "Relações públicas");
        [NotMapped] public static Profissao RelojoeiroFabricacao => new Profissao(2124, 741120, "Relojoeiro (fabricação)");
        [NotMapped] public static Profissao RelojoeiroReparacao => new Profissao(2125, 741125, "Relojoeiro (reparação)");
        [NotMapped] public static Profissao RemetedorDeFios => new Profissao(2126, 761363, "Remetedor de fios");
        [NotMapped] public static Profissao ReparadorDeAparelhosDeTelecomunicacoesEmLaboratorio => new Profissao(2127, 731330, "Reparador de aparelhos de telecomunicações em laboratório");
        [NotMapped] public static Profissao ReparadorDeAparelhosEletrodomesticosExcetoImagemESom => new Profissao(2128, 954205, "Reparador de aparelhos eletrodomésticos (exceto imagem e som)");
        [NotMapped] public static Profissao ReparadorDeEquipamentosDeEscritorio => new Profissao(2129, 954305, "Reparador de equipamentos de escritório");
        [NotMapped] public static Profissao ReparadorDeEquipamentosFotograficos => new Profissao(2130, 915405, "Reparador de equipamentos fotográficos");
        [NotMapped] public static Profissao ReparadorDeInstrumentosMusicais => new Profissao(2131, 915210, "Reparador de instrumentos musicais");
        [NotMapped] public static Profissao ReparadorDeRadioTvESom => new Profissao(2132, 954210, "Reparador de rádio, tv e som");
        [NotMapped] public static Profissao ReporterExclusiveRadioETelevisao => new Profissao(2133, 261135, "Repórter (exclusive rádio e televisão)");
        [NotMapped] public static Profissao ReporterDeMidiasAudiovisuais => new Profissao(2134, 261730, "Repórter de mídias audiovisuais");
        [NotMapped] public static Profissao ReporterFotografico => new Profissao(2135, 261820, "Repórter fotográfico");
        [NotMapped] public static Profissao RepositorDeMercadorias => new Profissao(2136, 521125, "Repositor de mercadorias");
        [NotMapped] public static Profissao RepresentanteComercialAutonomo => new Profissao(2137, 354705, "Representante comercial autônomo");
        [NotMapped] public static Profissao RestauradorDeInstrumentosMusicaisExcetoCordasArcadas => new Profissao(2138, 915205, "Restaurador de instrumentos musicais (exceto cordas arcadas)");
        [NotMapped] public static Profissao RestauradorDeLivros => new Profissao(2139, 768710, "Restaurador de livros");
        [NotMapped] public static Profissao RetalhadorDeCarne => new Profissao(2140, 848525, "Retalhador de carne");
        [NotMapped] public static Profissao ReveladorDeFilmesFotograficosEmCores => new Profissao(2141, 766415, "Revelador de filmes fotográficos, em cores");
        [NotMapped] public static Profissao ReveladorDeFilmesFotograficosEmPretoEBranco => new Profissao(2142, 766410, "Revelador de filmes fotográficos, em preto e branco");
        [NotMapped] public static Profissao RevestidorDeInterioresPapelMaterialPlasticoEEmborrachados => new Profissao(2143, 716615, "Revestidor de interiores (papel, material plástico e emborrachados)");
        [NotMapped] public static Profissao RevestidorDeSuperficiesDeConcreto => new Profissao(2144, 716110, "Revestidor de superfícies de concreto");
        [NotMapped] public static Profissao RevisorDeFiosProducaoTextil => new Profissao(2145, 761810, "Revisor de fios (produção têxtil)");
        [NotMapped] public static Profissao RevisorDeTecidosAcabados => new Profissao(2146, 761815, "Revisor de tecidos acabados");
        [NotMapped] public static Profissao RevisorDeTecidosCrus => new Profissao(2147, 761820, "Revisor de tecidos crus");
        [NotMapped] public static Profissao RevisorDeTexto => new Profissao(2148, 261140, "Revisor de texto");
        [NotMapped] public static Profissao RiscadorDeEstruturasMetalicas => new Profissao(2149, 724225, "Riscador de estruturas metálicas");
        [NotMapped] public static Profissao RiscadorDeRoupas => new Profissao(2150, 763120, "Riscador de roupas");
        [NotMapped] public static Profissao Sacristao => new Profissao(2151, 514115, "Sacristão");
        [NotMapped] public static Profissao SalgadorDeAlimentos => new Profissao(2152, 848110, "Salgador de alimentos");
        [NotMapped] public static Profissao SalsicheiroFabricacaoDeLinguicaSalsichaEProdutosSimilares => new Profissao(2153, 848115, "Salsicheiro (fabricação de lingüiça, salsicha e produtos similares)");
        [NotMapped] public static Profissao SalvaVidas => new Profissao(2154, 517115, "Salva-vidas");
        [NotMapped] public static Profissao Sanitarista => new Profissao(2155, 131225, "Sanitarista");
        [NotMapped] public static Profissao SapateiroCalcadosSobMedida => new Profissao(2156, 768320, "Sapateiro (calçados sob medida)");
        [NotMapped] public static Profissao SargentoBombeiroMilitar => new Profissao(2157, 31110, "Sargento bombeiro militar");
        [NotMapped] public static Profissao SargentoDaPoliciaMilitar => new Profissao(2158, 21110, "Sargento da policia militar");
        [NotMapped] public static Profissao SecadorDeMadeira => new Profissao(2159, 772115, "Secador de madeira");
        [NotMapped] public static Profissao SecretariaTrilingue => new Profissao(2160, 252315, "Secretária trilíngüe");
        [NotMapped] public static Profissao SecretariaOExecutivaO => new Profissao(2161, 252305, "Secretária(o) executiva(o)");
        [NotMapped] public static Profissao SecretarioBilingue => new Profissao(2162, 252310, "Secretário  bilíngüe");
        [NotMapped] public static Profissao SecretarioExecutivo => new Profissao(2163, 111220, "Secretário - executivo");
        [NotMapped] public static Profissao SegundoOficialDeMaquinasDaMarinhaMercante => new Profissao(2164, 215215, "Segundo oficial de máquinas da marinha mercante");
        [NotMapped] public static Profissao SegundoTenenteDePoliciaMilitar => new Profissao(2165, 20310, "Segundo tenente de polícia militar");
        [NotMapped] public static Profissao SelecionadorDeMaterialReciclavel => new Profissao(2166, 519210, "Selecionador de material reciclável");
        [NotMapped] public static Profissao Seleiro => new Profissao(2167, 768325, "Seleiro");
        [NotMapped] public static Profissao Senador => new Profissao(2168, 111105, "Senador");
        [NotMapped] public static Profissao Sepultador => new Profissao(2169, 516610, "Sepultador");
        [NotMapped] public static Profissao Sericultor => new Profissao(2170, 613420, "Sericultor");
        [NotMapped] public static Profissao Seringueiro => new Profissao(2171, 632205, "Seringueiro");
        [NotMapped] public static Profissao SerradorDeBordasNoDesdobramentoDeMadeira => new Profissao(2172, 773115, "Serrador de bordas no desdobramento de madeira");
        [NotMapped] public static Profissao SerradorDeMadeira => new Profissao(2173, 773120, "Serrador de madeira");
        [NotMapped] public static Profissao SerradorDeMadeiraSerraCircularMultipla => new Profissao(2174, 773125, "Serrador de madeira (serra circular múltipla)");
        [NotMapped] public static Profissao SerradorDeMadeiraSerraDeFitaMultipla => new Profissao(2175, 773130, "Serrador de madeira (serra de fita múltipla)");
        [NotMapped] public static Profissao Serralheiro => new Profissao(2176, 724440, "Serralheiro");
        [NotMapped] public static Profissao ServenteDeObras => new Profissao(2177, 717020, "Servente de obras");
        [NotMapped] public static Profissao Sexador => new Profissao(2178, 623325, "Sexador");
        [NotMapped] public static Profissao SinaleiroPonteRolante => new Profissao(2179, 782145, "Sinaleiro (ponte-rolante)");
        [NotMapped] public static Profissao Socioeducador => new Profissao(2180, 515325, "Sócioeducador");
        [NotMapped] public static Profissao Sociologo => new Profissao(2181, 251120, "Sociólogo");
        [NotMapped] public static Profissao SocorristaExcetoMedicosEEnfermeiros => new Profissao(2182, 515135, "Socorrista (exceto médicos e enfermeiros)");
        [NotMapped] public static Profissao SoldadoBombeiroMilitar => new Profissao(2183, 31210, "Soldado bombeiro militar");
        [NotMapped] public static Profissao SoldadoDaPoliciaMilitar => new Profissao(2184, 21210, "Soldado da polícia militar");
        [NotMapped] public static Profissao Soldador => new Profissao(2185, 724315, "Soldador");
        [NotMapped] public static Profissao SoldadorAOxigas => new Profissao(2186, 724320, "Soldador a  oxigás");
        [NotMapped] public static Profissao SoldadorAluminotermicoEmConservacaoDeTrilhos => new Profissao(2187, 991120, "Soldador aluminotérmico em conservação de trilhos");
        [NotMapped] public static Profissao SoldadorEletrico => new Profissao(2188, 724325, "Soldador elétrico");
        [NotMapped] public static Profissao SondadorPocosDePetroleoEGas => new Profissao(2189, 711315, "Sondador (poços de petróleo e gás)");
        [NotMapped] public static Profissao SondadorDePocosExcetoDePetroleoEGas => new Profissao(2190, 711320, "Sondador de poços (exceto de petróleo e gás)");
        [NotMapped] public static Profissao Sonoplasta => new Profissao(2191, 374150, "Sonoplasta");
        [NotMapped] public static Profissao SopradorDeConvertedor => new Profissao(2192, 821255, "Soprador de convertedor");
        [NotMapped] public static Profissao SopradorDeVidro => new Profissao(2193, 752115, "Soprador de vidro");
        [NotMapped] public static Profissao SubprocuradorDeJusticaMilitar => new Profissao(2194, 242240, "Subprocurador de justiça militar");
        [NotMapped] public static Profissao SubprocuradorGeralDaRepublica => new Profissao(2195, 242245, "Subprocurador-geral da república");
        [NotMapped] public static Profissao SubprocuradorGeralDoTrabalho => new Profissao(2196, 242250, "Subprocurador-geral do trabalho");
        [NotMapped] public static Profissao SubtenenteBombeiroMilitar => new Profissao(2197, 31105, "Subtenente bombeiro militar");
        [NotMapped] public static Profissao SubtenenteDaPoliciaMilitar => new Profissao(2198, 21105, "Subtenente da policia militar");
        [NotMapped] public static Profissao SuperintendenteTecnicoNoTransporteAquaviario => new Profissao(2199, 215220, "Superintendente técnico no transporte aquaviário");
        [NotMapped] public static Profissao SupervisorIndustriaDeCalcadosEArtefatosDeCouro => new Profissao(2200, 760405, "Supervisor  (indústria de calçados e artefatos de couro)");
        [NotMapped] public static Profissao SupervisorAdministrativo => new Profissao(2201, 410105, "Supervisor administrativo");
        [NotMapped] public static Profissao SupervisorDaAdministracaoDeAeroportos => new Profissao(2202, 342540, "Supervisor da administração de aeroportos");
        [NotMapped] public static Profissao SupervisorDaAquicultura => new Profissao(2203, 630105, "Supervisor da aqüicultura");
        [NotMapped] public static Profissao SupervisorDaAreaFlorestal => new Profissao(2204, 630110, "Supervisor da área florestal");
        [NotMapped] public static Profissao SupervisorDaConfeccaoDeArtefatosDeTecidosCourosEAfins => new Profissao(2205, 760505, "Supervisor da confecção de artefatos de tecidos, couros e afins");
        [NotMapped] public static Profissao SupervisorDaIndustriaDeBebidas => new Profissao(2206, 840110, "Supervisor da indústria de bebidas");
        [NotMapped] public static Profissao SupervisorDaIndustriaDeFumo => new Profissao(2207, 840115, "Supervisor da indústria de fumo");
        [NotMapped] public static Profissao SupervisorDaIndustriaDeMineraisNaoMetalicosExcetoOsDerivadosDePetroleoECarvao => new Profissao(2208, 750205, "Supervisor da indústria de minerais não metálicos (exceto os derivados de petróleo e carvão)");
        [NotMapped] public static Profissao SupervisorDaManutencaoEReparacaoDeVeiculosLeves => new Profissao(2209, 910205, "Supervisor da manutenção e reparação de veículos leves");
        [NotMapped] public static Profissao SupervisorDaManutencaoEReparacaoDeVeiculosPesados => new Profissao(2210, 910210, "Supervisor da manutenção e reparação de veículos pesados");
        [NotMapped] public static Profissao SupervisorDaMecanicaDePrecisao => new Profissao(2211, 740105, "Supervisor da mecânica de precisão");
        [NotMapped] public static Profissao SupervisorDasArtesGraficasIndustriaEditorialEGrafica => new Profissao(2212, 760605, "Supervisor das artes gráficas  (indústria editorial e gráfica)");
        [NotMapped] public static Profissao SupervisorDeAlmoxarifado => new Profissao(2213, 410205, "Supervisor de almoxarifado");
        [NotMapped] public static Profissao SupervisorDeAndar => new Profissao(2214, 510115, "Supervisor de andar");
        [NotMapped] public static Profissao SupervisorDeApoioOperacionalNaMineracao => new Profissao(2215, 710105, "Supervisor de apoio operacional na mineração");
        [NotMapped] public static Profissao SupervisorDeBombeiros => new Profissao(2216, 510305, "Supervisor de bombeiros");
        [NotMapped] public static Profissao SupervisorDeCaixasEBilheteirosExcetoCaixaDeBanco => new Profissao(2217, 420105, "Supervisor de caixas e bilheteiros (exceto caixa de banco)");
        [NotMapped] public static Profissao SupervisorDeCambio => new Profissao(2218, 410210, "Supervisor de câmbio");
        [NotMapped] public static Profissao SupervisorDeCargaEDescarga => new Profissao(2219, 342315, "Supervisor de carga e descarga");
        [NotMapped] public static Profissao SupervisorDeCobranca => new Profissao(2220, 420110, "Supervisor de cobrança");
        [NotMapped] public static Profissao SupervisorDeColetadoresDeApostasEDeJogos => new Profissao(2221, 420115, "Supervisor de coletadores de apostas e de jogos");
        [NotMapped] public static Profissao SupervisorDeCompras => new Profissao(2222, 354210, "Supervisor de compras");
        [NotMapped] public static Profissao SupervisorDeContasAPagar => new Profissao(2223, 410215, "Supervisor de contas a pagar");
        [NotMapped] public static Profissao SupervisorDeControleDeTratamentoTermico => new Profissao(2224, 720160, "Supervisor de controle de tratamento térmico");
        [NotMapped] public static Profissao SupervisorDeControlePatrimonial => new Profissao(2225, 410220, "Supervisor de controle patrimonial");
        [NotMapped] public static Profissao SupervisorDeCreditoECobranca => new Profissao(2226, 410225, "Supervisor de crédito e cobrança");
        [NotMapped] public static Profissao SupervisorDeCurtimento => new Profissao(2227, 760205, "Supervisor de curtimento");
        [NotMapped] public static Profissao SupervisorDeDigitacaoEOperacao => new Profissao(2228, 412120, "Supervisor de digitação e operação");
        [NotMapped] public static Profissao SupervisorDeEmbalagemEEtiquetagem => new Profissao(2229, 780105, "Supervisor de embalagem e etiquetagem");
        [NotMapped] public static Profissao SupervisorDeEmpresaAereaEmAeroportos => new Profissao(2230, 342545, "Supervisor de empresa aérea em aeroportos");
        [NotMapped] public static Profissao SupervisorDeEnsino => new Profissao(2231, 239430, "Supervisor de ensino");
        [NotMapped] public static Profissao SupervisorDeEntrevistadoresERecenseadores => new Profissao(2232, 420120, "Supervisor de entrevistadores e recenseadores");
        [NotMapped] public static Profissao SupervisorDeExploracaoAgricola => new Profissao(2233, 620105, "Supervisor de exploração agrícola");
        [NotMapped] public static Profissao SupervisorDeExploracaoAgropecuaria => new Profissao(2234, 620110, "Supervisor de exploração agropecuária");
        [NotMapped] public static Profissao SupervisorDeExploracaoPecuaria => new Profissao(2235, 620115, "Supervisor de exploração pecuária");
        [NotMapped] public static Profissao SupervisorDeExtracaoDeSal => new Profissao(2236, 710110, "Supervisor de extração de sal");
        [NotMapped] public static Profissao SupervisorDeFabricacaoDeInstrumentosMusicais => new Profissao(2237, 740110, "Supervisor de fabricação de instrumentos musicais");
        [NotMapped] public static Profissao SupervisorDeFabricacaoDeProdutosCeramicosPorcelanatosEAfins => new Profissao(2238, 820205, "Supervisor de fabricação de produtos cerâmicos, porcelanatos e afins");
        [NotMapped] public static Profissao SupervisorDeFabricacaoDeProdutosDeVidro => new Profissao(2239, 820210, "Supervisor de fabricação de produtos de vidro");
        [NotMapped] public static Profissao SupervisorDeJoalheria => new Profissao(2240, 750105, "Supervisor de joalheria");
        [NotMapped] public static Profissao SupervisorDeLavanderia => new Profissao(2241, 510205, "Supervisor de lavanderia");
        [NotMapped] public static Profissao SupervisorDeLogistica => new Profissao(2242, 410240, "Supervisor de logística");
        [NotMapped] public static Profissao SupervisorDeManutencaoDeAparelhosTermicosDeClimatizacaoEDeRefrigeracao => new Profissao(2243, 910110, "Supervisor de manutenção de aparelhos térmicos, de climatização e de refrigeração");
        [NotMapped] public static Profissao SupervisorDeManutencaoDeBombasMotoresCompressoresEEquipamentosDeTransmissao => new Profissao(2244, 910115, "Supervisor de manutenção de bombas, motores, compressores e equipamentos de transmissão");
        [NotMapped] public static Profissao SupervisorDeManutencaoDeMaquinasGraficas => new Profissao(2245, 910120, "Supervisor de manutenção de máquinas gráficas");
        [NotMapped] public static Profissao SupervisorDeManutencaoDeMaquinasIndustriaisTexteis => new Profissao(2246, 910125, "Supervisor de manutenção de máquinas industriais têxteis");
        [NotMapped] public static Profissao SupervisorDeManutencaoDeMaquinasOperatrizesEDeUsinagem => new Profissao(2247, 910130, "Supervisor de manutenção de máquinas operatrizes e de usinagem");
        [NotMapped] public static Profissao SupervisorDeManutencaoDeViasFerreas => new Profissao(2248, 910910, "Supervisor de manutenção de vias férreas");
        [NotMapped] public static Profissao SupervisorDeManutencaoEletricaDeAltaTensaoIndustrial => new Profissao(2249, 950105, "Supervisor de manutenção elétrica de alta tensão industrial");
        [NotMapped] public static Profissao SupervisorDeManutencaoEletromecanica => new Profissao(2250, 950305, "Supervisor de manutenção eletromecânica");
        [NotMapped] public static Profissao SupervisorDeManutencaoEletromecanicaUtilidades => new Profissao(2251, 860105, "Supervisor de manutenção eletromecânica (utilidades)");
        [NotMapped] public static Profissao SupervisorDeManutencaoEletromecanicaIndustrialComercialEPredial => new Profissao(2252, 950110, "Supervisor de manutenção eletromecânica industrial, comercial e predial");
        [NotMapped] public static Profissao SupervisorDeMontagemEInstalacaoEletroeletronica => new Profissao(2253, 730105, "Supervisor de montagem e instalação eletroeletrônica");
        [NotMapped] public static Profissao SupervisorDeOperacaoDeFluidosDistribuicaoCaptacaoTratamentoDeAguaGasesVapor => new Profissao(2254, 860110, "Supervisor de operação de fluidos (distribuição, captação, tratamento de água, gases, vapor)");
        [NotMapped] public static Profissao SupervisorDeOperacaoEletricaGeracaoTransmissaoEDistribuicaoDeEnergiaEletrica => new Profissao(2255, 860115, "Supervisor de operação elétrica (geração, transmissão e distribuição de energia elétrica)");
        [NotMapped] public static Profissao SupervisorDeOperacoesMidiasAudiovisuais => new Profissao(2256, 373225, "Supervisor de operações (mídias audiovisuais)");
        [NotMapped] public static Profissao SupervisorDeOperacoesPortuarias => new Profissao(2257, 342610, "Supervisor de operações portuárias");
        [NotMapped] public static Profissao SupervisorDeOrcamento => new Profissao(2258, 410230, "Supervisor de orçamento");
        [NotMapped] public static Profissao SupervisorDePerfuracaoEDesmonte => new Profissao(2259, 710115, "Supervisor de perfuração e desmonte");
        [NotMapped] public static Profissao SupervisorDeProducaoDaIndustriaAlimenticia => new Profissao(2260, 840105, "Supervisor de produção da indústria alimentícia");
        [NotMapped] public static Profissao SupervisorDeProducaoNaMineracao => new Profissao(2261, 710120, "Supervisor de produção na mineração");
        [NotMapped] public static Profissao SupervisorDeRecepcionistas => new Profissao(2262, 420125, "Supervisor de recepcionistas");
        [NotMapped] public static Profissao SupervisorDeReparosLinhasFerreas => new Profissao(2263, 910905, "Supervisor de reparos linhas férreas");
        [NotMapped] public static Profissao SupervisorDeTelefonistas => new Profissao(2264, 420130, "Supervisor de telefonistas");
        [NotMapped] public static Profissao SupervisorDeTelemarketingEAtendimento => new Profissao(2265, 420135, "Supervisor de telemarketing e atendimento");
        [NotMapped] public static Profissao SupervisorDeTesouraria => new Profissao(2266, 410235, "Supervisor de tesouraria");
        [NotMapped] public static Profissao SupervisorDeTransporteNaMineracao => new Profissao(2267, 710125, "Supervisor de transporte na mineração");
        [NotMapped] public static Profissao SupervisorDeTransportes => new Profissao(2268, 510105, "Supervisor de transportes");
        [NotMapped] public static Profissao SupervisorDeUsinaDeConcreto => new Profissao(2269, 710220, "Supervisor de usina de concreto");
        [NotMapped] public static Profissao SupervisorDeVendasComercial => new Profissao(2270, 520110, "Supervisor de vendas comercial");
        [NotMapped] public static Profissao SupervisorDeVendasDeServicos => new Profissao(2271, 520105, "Supervisor de vendas de serviços");
        [NotMapped] public static Profissao SupervisorDeVigilantes => new Profissao(2272, 510310, "Supervisor de vigilantes");
        [NotMapped] public static Profissao SupervisorTecnicoMidiasAudiovisuais => new Profissao(2273, 373230, "Supervisor técnico (mídias audiovisuais)");
        [NotMapped] public static Profissao SupervisorTecnicoOperacionalDeSistemasDeTelevisaoEProdutorasDeVideo => new Profissao(2274, 373220, "Supervisor técnico operacional de sistemas de televisão e produtoras de vídeo");
        [NotMapped] public static Profissao Surfassagista => new Profissao(2275, 752235, "Surfassagista");
        [NotMapped] public static Profissao Sushiman => new Profissao(2276, 513615, "Sushiman");
        [NotMapped] public static Profissao TabeliaoDeNotas => new Profissao(2277, 241335, "Tabelião de notas");
        [NotMapped] public static Profissao TabeliaoDeProtestos => new Profissao(2278, 241340, "Tabelião de protestos");
        [NotMapped] public static Profissao TaifeiroExcetoMilitares => new Profissao(2279, 511115, "Taifeiro (exceto militares)");
        [NotMapped] public static Profissao Tanoeiro => new Profissao(2280, 771120, "Tanoeiro");
        [NotMapped] public static Profissao TapeceiroDeAutos => new Profissao(2281, 765240, "Tapeceiro de autos");
        [NotMapped] public static Profissao Taqueiro => new Profissao(2282, 716535, "Taqueiro");
        [NotMapped] public static Profissao Taquigrafo => new Profissao(2283, 351510, "Taquígrafo");
        [NotMapped] public static Profissao Taxidermista => new Profissao(2284, 328110, "Taxidermista");
        [NotMapped] public static Profissao TecelaoRedes => new Profissao(2285, 761303, "Tecelão (redes)");
        [NotMapped] public static Profissao TecelaoRendasEBordados => new Profissao(2286, 761306, "Tecelão (rendas e bordados)");
        [NotMapped] public static Profissao TecelaoTearAutomatico => new Profissao(2287, 761309, "Tecelão (tear automático)");
        [NotMapped] public static Profissao TecelaoTearJacquard => new Profissao(2288, 761312, "Tecelão (tear jacquard)");
        [NotMapped] public static Profissao TecelaoTearManual => new Profissao(2289, 768105, "Tecelão (tear manual)");
        [NotMapped] public static Profissao TecelaoTearMecanicoDeMaquineta => new Profissao(2290, 761315, "Tecelão (tear mecânico de maquineta)");
        [NotMapped] public static Profissao TecelaoTearMecanicoDeXadrez => new Profissao(2291, 761318, "Tecelão (tear mecânico de xadrez)");
        [NotMapped] public static Profissao TecelaoTearMecanicoLiso => new Profissao(2292, 761321, "Tecelão (tear mecânico liso)");
        [NotMapped] public static Profissao TecelaoTearMecanicoExcetoJacquard => new Profissao(2293, 761324, "Tecelão (tear mecânico, exceto jacquard)");
        [NotMapped] public static Profissao TecelaoDeMalhasMaquinaCircular => new Profissao(2294, 761330, "Tecelão de malhas (máquina circular)");
        [NotMapped] public static Profissao TecelaoDeMalhasMaquinaRetilinea => new Profissao(2295, 761333, "Tecelão de malhas (máquina retilínea)");
        [NotMapped] public static Profissao TecelaoDeMalhasAMaquina => new Profissao(2296, 761327, "Tecelão de malhas, a  máquina");
        [NotMapped] public static Profissao TecelaoDeMeiasMaquinaCircular => new Profissao(2297, 761339, "Tecelão de meias (máquina circular)");
        [NotMapped] public static Profissao TecelaoDeMeiasMaquinaRetilinea => new Profissao(2298, 761342, "Tecelão de meias (máquina retilínea)");
        [NotMapped] public static Profissao TecelaoDeMeiasAMaquina => new Profissao(2299, 761336, "Tecelão de meias, a  máquina");
        [NotMapped] public static Profissao TecelaoDeTapetesAMao => new Profissao(2300, 768110, "Tecelão de tapetes, a  mão");
        [NotMapped] public static Profissao TecelaoDeTapetesAMaquina => new Profissao(2301, 761345, "Tecelão de tapetes, a  máquina");
        [NotMapped] public static Profissao TecnicoAgricola => new Profissao(2302, 321105, "Técnico agrícola");
        [NotMapped] public static Profissao TecnicoAgropecuario => new Profissao(2303, 321110, "Técnico agropecuário");
        [NotMapped] public static Profissao TecnicoDaReceitaFederal => new Profissao(2304, 254110, "Técnico da receita federal");
        [NotMapped] public static Profissao TecnicoDeAcabamentoEmSiderurgia => new Profissao(2305, 314705, "Técnico de acabamento em siderurgia");
        [NotMapped] public static Profissao TecnicoDeAciariaEmSiderurgia => new Profissao(2306, 314710, "Técnico de aciaria em siderurgia");
        [NotMapped] public static Profissao TecnicoDeAlimentos => new Profissao(2307, 325205, "Técnico de alimentos");
        [NotMapped] public static Profissao TecnicoDeApoioABioengenharia => new Profissao(2308, 301205, "Técnico de apoio à bioengenharia");
        [NotMapped] public static Profissao TecnicoDeApoioEmPesquisaEDesenvolvimentoExcetoAgropecuarioEFlorestal => new Profissao(2309, 395105, "Técnico de apoio em pesquisa e desenvolvimento (exceto agropecuário e florestal)");
        [NotMapped] public static Profissao TecnicoDeApoioEmPesquisaEDesenvolvimentoAgropecuarioFlorestal => new Profissao(2310, 395110, "Técnico de apoio em pesquisa e desenvolvimento agropecuário florestal");
        [NotMapped] public static Profissao TecnicoDeCeluloseEPapel => new Profissao(2311, 311110, "Técnico de celulose e papel");
        [NotMapped] public static Profissao TecnicoDeComunicacaoDeDados => new Profissao(2312, 313305, "Técnico de comunicação de dados");
        [NotMapped] public static Profissao TecnicoDeContabilidade => new Profissao(2313, 351105, "Técnico de contabilidade");
        [NotMapped] public static Profissao TecnicoDeControleDeMeioAmbiente => new Profissao(2314, 311505, "Técnico de controle de meio ambiente");
        [NotMapped] public static Profissao TecnicoDeDesportoIndividualEColetivoExcetoFutebol => new Profissao(2315, 224125, "Técnico de desporto individual e coletivo (exceto futebol)");
        [NotMapped] public static Profissao TecnicoDeEnfermagem => new Profissao(2316, 322205, "Técnico de enfermagem");
        [NotMapped] public static Profissao TecnicoDeEnfermagemDaEstrategiaDeSaudeDaFamilia => new Profissao(2317, 322245, "Técnico de enfermagem da estratégia de saúde da família");
        [NotMapped] public static Profissao TecnicoDeEnfermagemDeTerapiaIntensiva => new Profissao(2318, 322210, "Técnico de enfermagem de terapia intensiva");
        [NotMapped] public static Profissao TecnicoDeEnfermagemDoTrabalho => new Profissao(2319, 322215, "Técnico de enfermagem do trabalho");
        [NotMapped] public static Profissao TecnicoDeEnfermagemPsiquiatrica => new Profissao(2320, 322220, "Técnico de enfermagem psiquiátrica");
        [NotMapped] public static Profissao TecnicoDeEstradas => new Profissao(2321, 312205, "Técnico de estradas");
        [NotMapped] public static Profissao TecnicoDeFundicaoEmSiderurgia => new Profissao(2322, 314715, "Técnico de fundição em siderurgia");
        [NotMapped] public static Profissao TecnicoDeGarantiaDaQualidade => new Profissao(2323, 391210, "Técnico de garantia da qualidade");
        [NotMapped] public static Profissao TecnicoDeImobilizacaoOrtopedica => new Profissao(2324, 322605, "Técnico de imobilização ortopédica");
        [NotMapped] public static Profissao TecnicoDeLaboratorioDeAnalisesFisicoQuimicasMateriaisDeConstrucao => new Profissao(2325, 301110, "Técnico de laboratório de análises físico-químicas (materiais de construção)");
        [NotMapped] public static Profissao TecnicoDeLaboratorioEFiscalizacaoDesportiva => new Profissao(2326, 224130, "Técnico de laboratório e fiscalização desportiva");
        [NotMapped] public static Profissao TecnicoDeLaboratorioIndustrial => new Profissao(2327, 301105, "Técnico de laboratório industrial");
        [NotMapped] public static Profissao TecnicoDeLaminacaoEmSiderurgia => new Profissao(2328, 314720, "Técnico de laminação em siderurgia");
        [NotMapped] public static Profissao TecnicoDeManutencaoDeSistemasEInstrumentos => new Profissao(2329, 314405, "Técnico de manutenção de sistemas e instrumentos");
        [NotMapped] public static Profissao TecnicoDeManutencaoEletrica => new Profissao(2330, 313120, "Técnico de manutenção elétrica");
        [NotMapped] public static Profissao TecnicoDeManutencaoEletricaDeMaquina => new Profissao(2331, 313125, "Técnico de manutenção elétrica de máquina");
        [NotMapped] public static Profissao TecnicoDeManutencaoEletronica => new Profissao(2332, 313205, "Técnico de manutenção eletrônica");
        [NotMapped] public static Profissao TecnicoDeManutencaoEletronicaCircuitosDeMaquinasComComandoNumerico => new Profissao(2333, 313210, "Técnico de manutenção eletrônica (circuitos de máquinas com comando numérico)");
        [NotMapped] public static Profissao TecnicoDeMateriaPrimaEMaterial => new Profissao(2334, 391135, "Técnico de matéria-prima e material");
        [NotMapped] public static Profissao TecnicoDeMeteorologia => new Profissao(2335, 311510, "Técnico de meteorologia");
        [NotMapped] public static Profissao TecnicoDeMineracao => new Profissao(2336, 316305, "Técnico de mineração");
        [NotMapped] public static Profissao TecnicoDeMineracaoOleoEPetroleo => new Profissao(2337, 316310, "Técnico de mineração (óleo e petróleo)");
        [NotMapped] public static Profissao TecnicoDeObrasCivis => new Profissao(2338, 312105, "Técnico de obras civis");
        [NotMapped] public static Profissao TecnicoDeOperacaoQuimicaPetroquimicaEAfins => new Profissao(2339, 813130, "Técnico de operação (química, petroquímica e afins)");
        [NotMapped] public static Profissao TecnicoDeOperacoesEServicosBancariosCambio => new Profissao(2340, 353205, "Técnico de operações e serviços bancários - câmbio");
        [NotMapped] public static Profissao TecnicoDeOperacoesEServicosBancariosCreditoImobiliario => new Profissao(2341, 353210, "Técnico de operações e serviços bancários - crédito imobiliário");
        [NotMapped] public static Profissao TecnicoDeOperacoesEServicosBancariosCreditoRural => new Profissao(2342, 353215, "Técnico de operações e serviços bancários - crédito rural");
        [NotMapped] public static Profissao TecnicoDeOperacoesEServicosBancariosLeasing => new Profissao(2343, 353220, "Técnico de operações e serviços bancários - leasing");
        [NotMapped] public static Profissao TecnicoDeOperacoesEServicosBancariosRendaFixaEVariavel => new Profissao(2344, 353225, "Técnico de operações e serviços bancários - renda fixa e variável");
        [NotMapped] public static Profissao TecnicoDeOrtopedia => new Profissao(2345, 322505, "Técnico de ortopedia");
        [NotMapped] public static Profissao TecnicoDePainelDeControle => new Profissao(2346, 391220, "Técnico de painel de controle");
        [NotMapped] public static Profissao TecnicoDePlanejamentoDeProducao => new Profissao(2347, 391125, "Técnico de planejamento de produção");
        [NotMapped] public static Profissao TecnicoDePlanejamentoEProgramacaoDaManutencao => new Profissao(2348, 391130, "Técnico de planejamento e programação da manutenção");
        [NotMapped] public static Profissao TecnicoDeProducaoEmRefinoDePetroleo => new Profissao(2349, 316325, "Técnico de produção em refino de petróleo");
        [NotMapped] public static Profissao TecnicoDeRedeTelecomunicacoes => new Profissao(2350, 313310, "Técnico de rede (telecomunicações)");
        [NotMapped] public static Profissao TecnicoDeReducaoNaSiderurgiaPrimeiraFusao => new Profissao(2351, 314725, "Técnico de redução na siderurgia (primeira fusão)");
        [NotMapped] public static Profissao TecnicoDeRefratarioEmSiderurgia => new Profissao(2352, 314730, "Técnico de refratário em siderurgia");
        [NotMapped] public static Profissao TecnicoDeResseguros => new Profissao(2353, 351735, "Técnico de resseguros");
        [NotMapped] public static Profissao TecnicoDeSaneamento => new Profissao(2354, 312210, "Técnico de saneamento");
        [NotMapped] public static Profissao TecnicoDeSeguros => new Profissao(2355, 351740, "Técnico de seguros");
        [NotMapped] public static Profissao TecnicoDeSistemasAudiovisuais => new Profissao(2356, 373130, "Técnico de sistemas audiovisuais");
        [NotMapped] public static Profissao TecnicoDeSuporteAoUsuarioDeTecnologiaDaInformacao => new Profissao(2357, 317210, "Técnico de suporte ao usuário de tecnologia da informação");
        [NotMapped] public static Profissao TecnicoDeTelecomunicacoesTelefonia => new Profissao(2358, 313315, "Técnico de telecomunicações (telefonia)");
        [NotMapped] public static Profissao TecnicoDeTransmissaoTelecomunicacoes => new Profissao(2359, 313320, "Técnico de transmissão (telecomunicações)");
        [NotMapped] public static Profissao TecnicoDeTributosEstadual => new Profissao(2360, 254415, "Técnico de tributos estadual");
        [NotMapped] public static Profissao TecnicoDeTributosMunicipal => new Profissao(2361, 254420, "Técnico de tributos municipal");
        [NotMapped] public static Profissao TecnicoDeUtilidadeProducaoEDistribuicaoDeVaporGasesOleosCombustiveisEnergia => new Profissao(2362, 311515, "Técnico de utilidade (produção e distribuição de vapor, gases, óleos, combustíveis, energia)");
        [NotMapped] public static Profissao TecnicoDeVendas => new Profissao(2363, 354135, "Técnico de vendas");
        [NotMapped] public static Profissao TecnicoDoMobiliario => new Profissao(2364, 319205, "Técnico do mobiliário");
        [NotMapped] public static Profissao TecnicoEletricista => new Profissao(2365, 313130, "Técnico eletricista");
        [NotMapped] public static Profissao TecnicoEletronico => new Profissao(2366, 313215, "Técnico eletrônico");
        [NotMapped] public static Profissao TecnicoEmAcupuntura => new Profissao(2367, 322105, "Técnico em acupuntura");
        [NotMapped] public static Profissao TecnicoEmAdministracao => new Profissao(2368, 351305, "Técnico em administração");
        [NotMapped] public static Profissao TecnicoEmAdministracaoDeComercioExterior => new Profissao(2369, 351310, "Técnico em administração de comércio exterior");
        [NotMapped] public static Profissao TecnicoEmAgrimensura => new Profissao(2370, 312305, "Técnico em agrimensura");
        [NotMapped] public static Profissao TecnicoEmAtendimentoEVendas => new Profissao(2371, 354140, "Técnico em atendimento e vendas");
        [NotMapped] public static Profissao TecnicoEmAutomobilistica => new Profissao(2372, 314305, "Técnico em automobilística");
        [NotMapped] public static Profissao TecnicoEmBiblioteconomia => new Profissao(2373, 371110, "Técnico em biblioteconomia");
        [NotMapped] public static Profissao TecnicoEmBiotecnologia => new Profissao(2374, 325305, "Técnico em biotecnologia");
        [NotMapped] public static Profissao TecnicoEmBioterismo => new Profissao(2375, 320105, "Técnico em bioterismo");
        [NotMapped] public static Profissao TecnicoEmBorracha => new Profissao(2376, 311405, "Técnico em borracha");
        [NotMapped] public static Profissao TecnicoEmCalcadosEArtefatosDeCouro => new Profissao(2377, 319105, "Técnico em calçados e artefatos de couro");
        [NotMapped] public static Profissao TecnicoEmCaldeiraria => new Profissao(2378, 314610, "Técnico em caldeiraria");
        [NotMapped] public static Profissao TecnicoEmCalibracao => new Profissao(2379, 313405, "Técnico em calibração");
        [NotMapped] public static Profissao TecnicoEmCarcinicultura => new Profissao(2380, 321310, "Técnico em carcinicultura");
        [NotMapped] public static Profissao TecnicoEmConfeccoesDoVestuario => new Profissao(2381, 319110, "Técnico em confecções do vestuário");
        [NotMapped] public static Profissao TecnicoEmCurtimento => new Profissao(2382, 311115, "Técnico em curtimento");
        [NotMapped] public static Profissao TecnicoEmDireitosAutorais => new Profissao(2383, 352420, "Técnico em direitos autorais");
        [NotMapped] public static Profissao TecnicoEmEletromecanica => new Profissao(2384, 300305, "Técnico em eletromecânica");
        [NotMapped] public static Profissao TecnicoEmEspirometria => new Profissao(2385, 324130, "Técnico em espirometria");
        [NotMapped] public static Profissao TecnicoEmEstruturasMetalicas => new Profissao(2386, 314615, "Técnico em estruturas metálicas");
        [NotMapped] public static Profissao TecnicoEmFarmacia => new Profissao(2387, 325115, "Técnico em farmácia");
        [NotMapped] public static Profissao TecnicoEmFotonica => new Profissao(2388, 313505, "Técnico em fotônica");
        [NotMapped] public static Profissao TecnicoEmGeodesiaECartografia => new Profissao(2389, 312310, "Técnico em geodésia e cartografia");
        [NotMapped] public static Profissao TecnicoEmGeofisica => new Profissao(2390, 316105, "Técnico em geofísica");
        [NotMapped] public static Profissao TecnicoEmGeologia => new Profissao(2391, 316110, "Técnico em geologia");
        [NotMapped] public static Profissao TecnicoEmGeoquimica => new Profissao(2392, 316115, "Técnico em geoquímica");
        [NotMapped] public static Profissao TecnicoEmGeotecnia => new Profissao(2393, 316120, "Técnico em geotecnia");
        [NotMapped] public static Profissao TecnicoEmGravacaoDeAudio => new Profissao(2394, 374105, "Técnico em gravação de áudio");
        [NotMapped] public static Profissao TecnicoEmHemoterapia => new Profissao(2395, 324220, "Técnico em hemoterapia");
        [NotMapped] public static Profissao TecnicoEmHidrografia => new Profissao(2396, 312315, "Técnico em hidrografia");
        [NotMapped] public static Profissao TecnicoEmHigieneOcupacional => new Profissao(2397, 351610, "Técnico em higiene ocupacional");
        [NotMapped] public static Profissao TecnicoEmHistologia => new Profissao(2398, 320110, "Técnico em histologia");
        [NotMapped] public static Profissao TecnicoEmImunobiologicos => new Profissao(2399, 325310, "Técnico em imunobiológicos");
        [NotMapped] public static Profissao TecnicoEmInstalacaoDeEquipamentosDeAudio => new Profissao(2400, 374110, "Técnico em instalação de equipamentos de áudio");
        [NotMapped] public static Profissao TecnicoEmInstrumentacao => new Profissao(2401, 313410, "Técnico em instrumentação");
        [NotMapped] public static Profissao TecnicoEmLaboratorioDeFarmacia => new Profissao(2402, 325110, "Técnico em laboratório de farmácia");
        [NotMapped] public static Profissao TecnicoEmMadeira => new Profissao(2403, 321205, "Técnico em madeira");
        [NotMapped] public static Profissao TecnicoEmManutencaoDeBalancas => new Profissao(2404, 915115, "Técnico em manutenção de balanças");
        [NotMapped] public static Profissao TecnicoEmManutencaoDeEquipamentosDeInformatica => new Profissao(2405, 313220, "Técnico em manutenção de equipamentos de informática");
        [NotMapped] public static Profissao TecnicoEmManutencaoDeEquipamentosEInstrumentosMedicoHospitalares => new Profissao(2406, 915305, "Técnico em manutenção de equipamentos e instrumentos médico-hospitalares");
        [NotMapped] public static Profissao TecnicoEmManutencaoDeHidrometros => new Profissao(2407, 915110, "Técnico em manutenção de hidrômetros");
        [NotMapped] public static Profissao TecnicoEmManutencaoDeInstrumentosDeMedicaoEPrecisao => new Profissao(2408, 915105, "Técnico em manutenção de instrumentos de medição e precisão");
        [NotMapped] public static Profissao TecnicoEmManutencaoDeMaquinas => new Profissao(2409, 314410, "Técnico em manutenção de máquinas");
        [NotMapped] public static Profissao TecnicoEmMasterizacaoDeAudio => new Profissao(2410, 374115, "Técnico em masterização de áudio");
        [NotMapped] public static Profissao TecnicoEmMateriaisProdutosCeramicosEVidros => new Profissao(2411, 311305, "Técnico em materiais, produtos cerâmicos e vidros");
        [NotMapped] public static Profissao TecnicoEmMecanicaDePrecisao => new Profissao(2412, 314105, "Técnico em mecânica de precisão");
        [NotMapped] public static Profissao TecnicoEmMecatronicaAutomacaoDaManufatura => new Profissao(2413, 300105, "Técnico em mecatrônica - automação da manufatura");
        [NotMapped] public static Profissao TecnicoEmMecatronicaRobotica => new Profissao(2414, 300110, "Técnico em mecatrônica - robótica");
        [NotMapped] public static Profissao TecnicoEmMetodosEletrograficosEmEncefalografia => new Profissao(2415, 324105, "Técnico em métodos eletrográficos em encefalografia");
        [NotMapped] public static Profissao TecnicoEmMetodosGraficosEmCardiologia => new Profissao(2416, 324110, "Técnico em métodos gráficos em cardiologia");
        [NotMapped] public static Profissao TecnicoEmMitilicultura => new Profissao(2417, 321315, "Técnico em mitilicultura");
        [NotMapped] public static Profissao TecnicoEmMixagemDeAudio => new Profissao(2418, 374130, "Técnico em mixagem de áudio");
        [NotMapped] public static Profissao TecnicoEmMuseologia => new Profissao(2419, 371210, "Técnico em museologia");
        [NotMapped] public static Profissao TecnicoEmNutricaoEDietetica => new Profissao(2420, 325210, "Técnico em nutrição e dietética");
        [NotMapped] public static Profissao TecnicoEmOpticaEOptometria => new Profissao(2421, 322305, "Técnico em óptica e optometria");
        [NotMapped] public static Profissao TecnicoEmPatologiaClinica => new Profissao(2422, 324205, "Técnico em patologia clínica");
        [NotMapped] public static Profissao TecnicoEmPecuaria => new Profissao(2423, 323105, "Técnico em pecuária");
        [NotMapped] public static Profissao TecnicoEmPesquisaMineral => new Profissao(2424, 316320, "Técnico em pesquisa mineral");
        [NotMapped] public static Profissao TecnicoEmPetroquimica => new Profissao(2425, 311205, "Técnico em petroquímica");
        [NotMapped] public static Profissao TecnicoEmPiscicultura => new Profissao(2426, 321305, "Técnico em piscicultura");
        [NotMapped] public static Profissao TecnicoEmPlanejamentoDeLavraDeMinas => new Profissao(2427, 316330, "Técnico em planejamento de lavra de minas");
        [NotMapped] public static Profissao TecnicoEmPlastico => new Profissao(2428, 311410, "Técnico em plástico");
        [NotMapped] public static Profissao TecnicoEmPolissonografia => new Profissao(2429, 324135, "Técnico em polissonografia");
        [NotMapped] public static Profissao TecnicoEmProcessamentoMineralExcetoPetroleo => new Profissao(2430, 316315, "Técnico em processamento mineral (exceto petróleo)");
        [NotMapped] public static Profissao TecnicoEmProgramacaoVisual => new Profissao(2431, 371305, "Técnico em programação visual");
        [NotMapped] public static Profissao TecnicoEmQuiropraxia => new Profissao(2432, 322115, "Técnico em quiropraxia");
        [NotMapped] public static Profissao TecnicoEmRadiologiaEImagenologia => new Profissao(2433, 324115, "Técnico em radiologia e imagenologia");
        [NotMapped] public static Profissao TecnicoEmRanicultura => new Profissao(2434, 321320, "Técnico em ranicultura");
        [NotMapped] public static Profissao TecnicoEmSaudeBucal => new Profissao(2435, 322405, "Técnico em saúde bucal");
        [NotMapped] public static Profissao TecnicoEmSaudeBucalDaEstrategiaDeSaudeDaFamilia => new Profissao(2436, 322425, "Técnico em saúde bucal da estratégia de saúde da família");
        [NotMapped] public static Profissao TecnicoEmSecretariado => new Profissao(2437, 351505, "Técnico em secretariado");
        [NotMapped] public static Profissao TecnicoEmSegurancaDoTrabalho => new Profissao(2438, 351605, "Técnico em segurança do trabalho");
        [NotMapped] public static Profissao TecnicoEmSinaisNavais => new Profissao(2439, 341245, "Técnico em sinais navais");
        [NotMapped] public static Profissao TecnicoEmSinalizacaoNautica => new Profissao(2440, 341235, "Técnico em sinalização náutica");
        [NotMapped] public static Profissao TecnicoEmSoldagem => new Profissao(2441, 314620, "Técnico em soldagem");
        [NotMapped] public static Profissao TecnicoEmSonorizacao => new Profissao(2442, 374125, "Técnico em sonorização");
        [NotMapped] public static Profissao TecnicoEmTratamentoDeEfluentes => new Profissao(2443, 311520, "Técnico em tratamento de efluentes");
        [NotMapped] public static Profissao TecnicoEmTurismo => new Profissao(2444, 354805, "Técnico em turismo");
        [NotMapped] public static Profissao TecnicoFlorestal => new Profissao(2445, 321210, "Técnico florestal");
        [NotMapped] public static Profissao TecnicoGrafico => new Profissao(2446, 371310, "Técnico gráfico");
        [NotMapped] public static Profissao TecnicoMecanico => new Profissao(2447, 314110, "Técnico mecânico");
        [NotMapped] public static Profissao TecnicoMecanicoAeronaves => new Profissao(2448, 314310, "Técnico mecânico (aeronaves)");
        [NotMapped] public static Profissao TecnicoMecanicoCalefacaoVentilacaoERefrigeracao => new Profissao(2449, 314115, "Técnico mecânico (calefação, ventilação e refrigeração)");
        [NotMapped] public static Profissao TecnicoMecanicoEmbarcacoes => new Profissao(2450, 314315, "Técnico mecânico (embarcações)");
        [NotMapped] public static Profissao TecnicoMecanicoMaquinas => new Profissao(2451, 314120, "Técnico mecânico (máquinas)");
        [NotMapped] public static Profissao TecnicoMecanicoMotores => new Profissao(2452, 314125, "Técnico mecânico (motores)");
        [NotMapped] public static Profissao TecnicoMecanicoNaFabricacaoDeFerramentas => new Profissao(2453, 314205, "Técnico mecânico na fabricação de ferramentas");
        [NotMapped] public static Profissao TecnicoMecanicoNaManutencaoDeFerramentas => new Profissao(2454, 314210, "Técnico mecânico na manutenção de ferramentas");
        [NotMapped] public static Profissao TecnicoOperacionalDeServicosDeCorreios => new Profissao(2455, 391230, "Técnico operacional de serviços de correios");
        [NotMapped] public static Profissao TecnicoQuimico => new Profissao(2456, 311105, "Técnico químico");
        [NotMapped] public static Profissao TecnicoQuimicoDePetroleo => new Profissao(2457, 301115, "Técnico químico de petróleo");
        [NotMapped] public static Profissao TecnicoTextil => new Profissao(2458, 311605, "Técnico têxtil");
        [NotMapped] public static Profissao TecnicoTextilTratamentosQuimicos => new Profissao(2459, 311610, "Técnico têxtil (tratamentos químicos)");
        [NotMapped] public static Profissao TecnicoTextilDeFiacao => new Profissao(2460, 311615, "Técnico têxtil de fiação");
        [NotMapped] public static Profissao TecnicoTextilDeMalharia => new Profissao(2461, 311620, "Técnico têxtil de malharia");
        [NotMapped] public static Profissao TecnicoTextilDeTecelagem => new Profissao(2462, 311625, "Técnico têxtil de tecelagem");
        [NotMapped] public static Profissao TecnicosEmManobrasEmEquipamentosDeConves => new Profissao(2463, 341240, "Técnicos em manobras em equipamentos de convés");
        [NotMapped] public static Profissao TecnologoEmAlimentos => new Profissao(2464, 222215, "Tecnólogo em alimentos");
        [NotMapped] public static Profissao TecnologoEmAutomacaoIndustrial => new Profissao(2465, 202120, "Tecnólogo em automação industrial");
        [NotMapped] public static Profissao TecnologoEmConstrucaoCivil => new Profissao(2466, 214280, "Tecnólogo em construção civil");
        [NotMapped] public static Profissao TecnologoEmEletricidade => new Profissao(2467, 214360, "Tecnólogo em eletricidade");
        [NotMapped] public static Profissao TecnologoEmEletronica => new Profissao(2468, 214365, "Tecnólogo em eletrônica");
        [NotMapped] public static Profissao TecnologoEmFabricacaoMecanica => new Profissao(2469, 214435, "Tecnólogo em fabricação mecânica");
        [NotMapped] public static Profissao TecnologoEmGastronomia => new Profissao(2470, 271110, "Tecnólogo em gastronomia");
        [NotMapped] public static Profissao TecnologoEmGestaoAdministrativoFinanceira => new Profissao(2471, 142120, "Tecnólogo em gestão administrativo- financeira");
        [NotMapped] public static Profissao TecnologoEmGestaoDaTecnologiaDaInformacao => new Profissao(2472, 142535, "Tecnólogo em gestão da tecnologia da informação");
        [NotMapped] public static Profissao TecnologoEmGestaoHospitalar => new Profissao(2473, 131215, "Tecnólogo em gestão hospitalar");
        [NotMapped] public static Profissao TecnologoEmLogisticaDeTransporte => new Profissao(2474, 342125, "Tecnólogo em logística de transporte");
        [NotMapped] public static Profissao TecnologoEmMecatronica => new Profissao(2475, 202115, "Tecnólogo em mecatrônica");
        [NotMapped] public static Profissao TecnologoEmMeioAmbiente => new Profissao(2476, 214010, "Tecnólogo em meio ambiente");
        [NotMapped] public static Profissao TecnologoEmMetalurgia => new Profissao(2477, 214615, "Tecnólogo em metalurgia");
        [NotMapped] public static Profissao TecnologoEmPetroleoEGas => new Profissao(2478, 214745, "Tecnólogo em petróleo e gás");
        [NotMapped] public static Profissao TecnologoEmProcessosQuimicos => new Profissao(2479, 213215, "Tecnólogo em processos químicos");
        [NotMapped] public static Profissao TecnologoEmProducaoAudiovisual => new Profissao(2480, 262135, "Tecnólogo em produção audiovisual");
        [NotMapped] public static Profissao TecnologoEmProducaoFonografica => new Profissao(2481, 262130, "Tecnólogo em produção fonográfica");
        [NotMapped] public static Profissao TecnologoEmProducaoIndustrial => new Profissao(2482, 214930, "Tecnólogo em produção industrial");
        [NotMapped] public static Profissao TecnologoEmProducaoSulcroalcooleira => new Profissao(2483, 214535, "Tecnólogo em produção sulcroalcooleira");
        [NotMapped] public static Profissao TecnologoEmRadiologia => new Profissao(2484, 324120, "Tecnólogo em radiologia");
        [NotMapped] public static Profissao TecnologoEmRochasOrnamentais => new Profissao(2485, 214750, "Tecnólogo em rochas ornamentais");
        [NotMapped] public static Profissao TecnologoEmSecretariadoEscolar => new Profissao(2486, 252320, "Tecnólogo em secretariado escolar");
        [NotMapped] public static Profissao TecnologoEmSegurancaDoTrabalho => new Profissao(2487, 214935, "Tecnólogo em segurança do trabalho");
        [NotMapped] public static Profissao TecnologoEmSistemasBiomedicos => new Profissao(2488, 142710, "Tecnólogo em sistemas biomédicos");
        [NotMapped] public static Profissao TecnologoEmSoldagem => new Profissao(2489, 314625, "Tecnólogo em soldagem");
        [NotMapped] public static Profissao TecnologoEmTelecomunicacoes => new Profissao(2490, 214370, "Tecnólogo em telecomunicações");
        [NotMapped] public static Profissao TecnologoOftalmico => new Profissao(2491, 324125, "Tecnólogo oftálmico");
        [NotMapped] public static Profissao TeleatendenteDeEmergencia => new Profissao(2492, 422330, "Teleatendente de emergência");
        [NotMapped] public static Profissao Telefonista => new Profissao(2493, 422205, "Telefonista");
        [NotMapped] public static Profissao Teleoperador => new Profissao(2494, 422210, "Teleoperador");
        [NotMapped] public static Profissao TelhadorTelhasDeArgilaEMateriaisSimilares => new Profissao(2495, 716205, "Telhador (telhas de argila e materiais similares)");
        [NotMapped] public static Profissao TelhadorTelhasDeCimentoAmianto => new Profissao(2496, 716210, "Telhador (telhas de cimento-amianto)");
        [NotMapped] public static Profissao TelhadorTelhasMetalicas => new Profissao(2497, 716215, "Telhador (telhas metálicas)");
        [NotMapped] public static Profissao TelhadorTelhasPlasticas => new Profissao(2498, 716220, "Telhador (telhas plásticas)");
        [NotMapped] public static Profissao TemperadorDeMetaisEDeCompositos => new Profissao(2499, 723125, "Temperador de metais e de compósitos");
        [NotMapped] public static Profissao TemperadorDeVidro => new Profissao(2500, 823255, "Temperador de vidro");
        [NotMapped] public static Profissao TenenteDoCorpoDeBombeirosMilitar => new Profissao(2501, 30305, "Tenente do corpo de bombeiros militar");
        [NotMapped] public static Profissao TenenteCoronelBombeiroMilitar => new Profissao(2502, 30115, "Tenente-coronel bombeiro militar");
        [NotMapped] public static Profissao TenenteCoronelDaPoliciaMilitar => new Profissao(2503, 20110, "Tenente-coronel da polícia militar");
        [NotMapped] public static Profissao Teologo => new Profissao(2504, 263115, "Teólogo");
        [NotMapped] public static Profissao TerapeutaHolistico => new Profissao(2505, 322125, "Terapeuta holístico");
        [NotMapped] public static Profissao TerapeutaOcupacional => new Profissao(2506, 223905, "Terapeuta ocupacional");
        [NotMapped] public static Profissao TesoureiroDeBanco => new Profissao(2507, 353230, "Tesoureiro de banco");
        [NotMapped] public static Profissao TingidorDeCourosEPeles => new Profissao(2508, 311725, "Tingidor de couros e peles");
        [NotMapped] public static Profissao TingidorDeRoupas => new Profissao(2509, 516330, "Tingidor de roupas");
        [NotMapped] public static Profissao Tipografo => new Profissao(2510, 768605, "Tipógrafo");
        [NotMapped] public static Profissao Titeriteiro => new Profissao(2511, 376250, "Titeriteiro");
        [NotMapped] public static Profissao Topografo => new Profissao(2512, 312320, "Topógrafo");
        [NotMapped] public static Profissao TorneiroLavraDePedra => new Profissao(2513, 712225, "Torneiro (lavra de pedra)");
        [NotMapped] public static Profissao TorneiroNaUsinagemConvencionalDeMadeira => new Profissao(2514, 773355, "Torneiro na usinagem convencional de madeira");
        [NotMapped] public static Profissao TorradorDeCacau => new Profissao(2515, 841625, "Torrador de cacau");
        [NotMapped] public static Profissao TorradorDeCafe => new Profissao(2516, 841610, "Torrador de café");
        [NotMapped] public static Profissao TorristaPetroleo => new Profissao(2517, 711330, "Torrista (petróleo)");
        [NotMapped] public static Profissao TosadorDeAnimaisDomesticos => new Profissao(2518, 519320, "Tosador de animais domésticos");
        [NotMapped] public static Profissao TrabalhadorAgropecuarioEmGeral => new Profissao(2519, 621005, "Trabalhador agropecuário em geral");
        [NotMapped] public static Profissao TrabalhadorDaAviculturaDeCorte => new Profissao(2520, 623305, "Trabalhador da avicultura de corte");
        [NotMapped] public static Profissao TrabalhadorDaAviculturaDePostura => new Profissao(2521, 623310, "Trabalhador da avicultura de postura");
        [NotMapped] public static Profissao TrabalhadorDaCaprinocultura => new Profissao(2522, 623205, "Trabalhador da caprinocultura");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeAlgodao => new Profissao(2523, 622205, "Trabalhador da cultura de algodão");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeArroz => new Profissao(2524, 622105, "Trabalhador da cultura de arroz");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeCacau => new Profissao(2525, 622605, "Trabalhador da cultura de cacau");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeCafe => new Profissao(2526, 622610, "Trabalhador da cultura de café");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeCanaDeAcucar => new Profissao(2527, 622110, "Trabalhador da cultura de cana-de-açúcar");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeErvaMate => new Profissao(2528, 622615, "Trabalhador da cultura de erva-mate");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeEspeciarias => new Profissao(2529, 622805, "Trabalhador da cultura de especiarias");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeFumo => new Profissao(2530, 622620, "Trabalhador da cultura de fumo");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeGuarana => new Profissao(2531, 622625, "Trabalhador da cultura de guaraná");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeMilhoESorgo => new Profissao(2532, 622115, "Trabalhador da cultura de milho e sorgo");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDePlantasAromaticasEMedicinais => new Profissao(2533, 622810, "Trabalhador da cultura de plantas aromáticas e medicinais");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeSisal => new Profissao(2534, 622210, "Trabalhador da cultura de sisal");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDeTrigoAveiaCevadaETriticale => new Profissao(2535, 622120, "Trabalhador da cultura de trigo, aveia, cevada e triticale");
        [NotMapped] public static Profissao TrabalhadorDaCulturaDoRami => new Profissao(2536, 622215, "Trabalhador da cultura do rami");
        [NotMapped] public static Profissao TrabalhadorDaCunicultura => new Profissao(2537, 623320, "Trabalhador da cunicultura");
        [NotMapped] public static Profissao TrabalhadorDaElaboracaoDePreFabricadosCimentoAmianto => new Profissao(2538, 823320, "Trabalhador da elaboração de pré-fabricados (cimento amianto)");
        [NotMapped] public static Profissao TrabalhadorDaElaboracaoDePreFabricadosConcretoArmado => new Profissao(2539, 823325, "Trabalhador da elaboração de pré-fabricados (concreto armado)");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeAcai => new Profissao(2540, 632405, "Trabalhador da exploração de açaí");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeAndiroba => new Profissao(2541, 632305, "Trabalhador da exploração de andiroba");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeArvoresEArbustosProdutoresDeSubstanciasAromatMedicEToxicas => new Profissao(2542, 632505, "Trabalhador da exploração de árvores e arbustos produtores de substâncias aromát., Medic. E tóxicas");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeBabacu => new Profissao(2543, 632310, "Trabalhador da exploração de babaçu");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeBacaba => new Profissao(2544, 632315, "Trabalhador da exploração de bacaba");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeBuriti => new Profissao(2545, 632320, "Trabalhador da exploração de buriti");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeCarnauba => new Profissao(2546, 632325, "Trabalhador da exploração de carnaúba");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeCastanha => new Profissao(2547, 632410, "Trabalhador da exploração de castanha");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeCiposProdutoresDeSubstanciasAromaticasMedicinaisEToxicas => new Profissao(2548, 632510, "Trabalhador da exploração de cipós produtores de substâncias aromáticas, medicinais e tóxicas");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeCocoDaPraia => new Profissao(2549, 632330, "Trabalhador da exploração de coco-da-praia");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeCopaiba => new Profissao(2550, 632335, "Trabalhador da exploração de copaíba");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeEspeciesProdutorasDeGomasNaoElasticas => new Profissao(2551, 632210, "Trabalhador da exploração de espécies produtoras de gomas não elásticas");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeMadeirasTanantes => new Profissao(2552, 632515, "Trabalhador da exploração de madeiras tanantes");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeMalvaPaina => new Profissao(2553, 632340, "Trabalhador da exploração de malva (pãina)");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeMurumuru => new Profissao(2554, 632345, "Trabalhador da exploração de murumuru");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeOiticica => new Profissao(2555, 632350, "Trabalhador da exploração de oiticica");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeOuricuri => new Profissao(2556, 632355, "Trabalhador da exploração de ouricuri");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDePequi => new Profissao(2557, 632360, "Trabalhador da exploração de pequi");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDePiacava => new Profissao(2558, 632365, "Trabalhador da exploração de piaçava");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDePinhao => new Profissao(2559, 632415, "Trabalhador da exploração de pinhão");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDePupunha => new Profissao(2560, 632420, "Trabalhador da exploração de pupunha");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeRaizesProdutorasDeSubstanciasAromaticasMedicinaisEToxicas => new Profissao(2561, 632520, "Trabalhador da exploração de raízes produtoras de substâncias aromáticas, medicinais e tóxicas");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeResinas => new Profissao(2562, 632215, "Trabalhador da exploração de resinas");
        [NotMapped] public static Profissao TrabalhadorDaExploracaoDeTucum => new Profissao(2563, 632370, "Trabalhador da exploração de tucum");
        [NotMapped] public static Profissao TrabalhadorDaExtracaoDeSubstanciasAromaticasMedicinaisEToxicasEmGeral => new Profissao(2564, 632525, "Trabalhador da extração de substâncias aromáticas, medicinais e tóxicas, em geral");
        [NotMapped] public static Profissao TrabalhadorDaFabricacaoDeMunicaoEExplosivos => new Profissao(2565, 812110, "Trabalhador da fabricação de munição e explosivos");
        [NotMapped] public static Profissao TrabalhadorDaFabricacaoDePedrasArtificiais => new Profissao(2566, 823330, "Trabalhador da fabricação de pedras artificiais");
        [NotMapped] public static Profissao TrabalhadorDaFabricacaoDeResinasEVernizes => new Profissao(2567, 811125, "Trabalhador da fabricação de resinas e vernizes");
        [NotMapped] public static Profissao TrabalhadorDaManutencaoDeEdificacoes => new Profissao(2568, 514325, "Trabalhador da manutenção de edificações");
        [NotMapped] public static Profissao TrabalhadorDaOvinocultura => new Profissao(2569, 623210, "Trabalhador da ovinocultura");
        [NotMapped] public static Profissao TrabalhadorDaPecuariaAsininosEMuares => new Profissao(2570, 623105, "Trabalhador da pecuária (asininos e muares)");
        [NotMapped] public static Profissao TrabalhadorDaPecuariaBovinosCorte => new Profissao(2571, 623110, "Trabalhador da pecuária (bovinos corte)");
        [NotMapped] public static Profissao TrabalhadorDaPecuariaBovinosLeite => new Profissao(2572, 623115, "Trabalhador da pecuária (bovinos leite)");
        [NotMapped] public static Profissao TrabalhadorDaPecuariaBubalinos => new Profissao(2573, 623120, "Trabalhador da pecuária (bubalinos)");
        [NotMapped] public static Profissao TrabalhadorDaPecuariaEquinos => new Profissao(2574, 623125, "Trabalhador da pecuária (eqüinos)");
        [NotMapped] public static Profissao TrabalhadorDaSuinocultura => new Profissao(2575, 623215, "Trabalhador da suinocultura");
        [NotMapped] public static Profissao TrabalhadorDeExtracaoFlorestalEmGeral => new Profissao(2576, 632125, "Trabalhador de extração florestal, em geral");
        [NotMapped] public static Profissao TrabalhadorDeFabricacaoDeMargarina => new Profissao(2577, 841476, "Trabalhador de fabricação de margarina");
        [NotMapped] public static Profissao TrabalhadorDeFabricacaoDeSorvete => new Profissao(2578, 848325, "Trabalhador de fabricação de sorvete");
        [NotMapped] public static Profissao TrabalhadorDeFabricacaoDeTintas => new Profissao(2579, 811130, "Trabalhador de fabricação de tintas");
        [NotMapped] public static Profissao TrabalhadorDeFabricacaoDeVinhos => new Profissao(2580, 841720, "Trabalhador de fabricação de vinhos");
        [NotMapped] public static Profissao TrabalhadorDePecuariaPolivalente => new Profissao(2581, 623015, "Trabalhador de pecuária polivalente");
        [NotMapped] public static Profissao TrabalhadorDePreparacaoDePescadosLimpeza => new Profissao(2582, 841484, "Trabalhador de preparação de pescados (limpeza)");
        [NotMapped] public static Profissao TrabalhadorDeServicosDeLimpezaEConservacaoDeAreasPublicas => new Profissao(2583, 514225, "Trabalhador de serviços de limpeza e conservação de áreas públicas");
        [NotMapped] public static Profissao TrabalhadorDeTratamentoDoLeiteEFabricacaoDeLaticiniosEAfins => new Profissao(2584, 841505, "Trabalhador de tratamento do leite e fabricação de laticínios e afins");
        [NotMapped] public static Profissao TrabalhadorDoAcabamentoDeArtefatosDeTecidosECouros => new Profissao(2585, 765405, "Trabalhador do acabamento de artefatos de tecidos e couros");
        [NotMapped] public static Profissao TrabalhadorDoBeneficiamentoDeFumo => new Profissao(2586, 848605, "Trabalhador do beneficiamento de fumo");
        [NotMapped] public static Profissao TrabalhadorEmCriatoriosDeAnimaisProdutoresDeVeneno => new Profissao(2587, 623405, "Trabalhador em criatórios de animais produtores de veneno");
        [NotMapped] public static Profissao TrabalhadorNaApicultura => new Profissao(2588, 623410, "Trabalhador na apicultura");
        [NotMapped] public static Profissao TrabalhadorNaCulturaDeAmendoim => new Profissao(2589, 622705, "Trabalhador na cultura de amendoim");
        [NotMapped] public static Profissao TrabalhadorNaCulturaDeCanola => new Profissao(2590, 622710, "Trabalhador na cultura de canola");
        [NotMapped] public static Profissao TrabalhadorNaCulturaDeCocoDaBaia => new Profissao(2591, 622715, "Trabalhador na cultura de coco-da-baía");
        [NotMapped] public static Profissao TrabalhadorNaCulturaDeDende => new Profissao(2592, 622720, "Trabalhador na cultura de dendê");
        [NotMapped] public static Profissao TrabalhadorNaCulturaDeMamona => new Profissao(2593, 622725, "Trabalhador na cultura de mamona");
        [NotMapped] public static Profissao TrabalhadorNaCulturaDeSoja => new Profissao(2594, 622730, "Trabalhador na cultura de soja");
        [NotMapped] public static Profissao TrabalhadorNaCulturaDoGirassol => new Profissao(2595, 622735, "Trabalhador na cultura do girassol");
        [NotMapped] public static Profissao TrabalhadorNaCulturaDoLinho => new Profissao(2596, 622740, "Trabalhador na cultura do linho");
        [NotMapped] public static Profissao TrabalhadorNaFabricacaoDeProdutosAbrasivos => new Profissao(2597, 823265, "Trabalhador na fabricação de produtos abrasivos");
        [NotMapped] public static Profissao TrabalhadorNaMinhocultura => new Profissao(2598, 623415, "Trabalhador na minhocultura");
        [NotMapped] public static Profissao TrabalhadorNaOlericulturaFrutosESementes => new Profissao(2599, 622305, "Trabalhador na olericultura (frutos e sementes)");
        [NotMapped] public static Profissao TrabalhadorNaOlericulturaLegumes => new Profissao(2600, 622310, "Trabalhador na olericultura (legumes)");
        [NotMapped] public static Profissao TrabalhadorNaOlericulturaRaizesBulbosETuberculos => new Profissao(2601, 622315, "Trabalhador na olericultura (raízes, bulbos e tubérculos)");
        [NotMapped] public static Profissao TrabalhadorNaOlericulturaTalosFolhasEFlores => new Profissao(2602, 622320, "Trabalhador na olericultura (talos, folhas e flores)");
        [NotMapped] public static Profissao TrabalhadorNaOperacaoDeSistemaDeIrrigacaoLocalizadaMicroaspersaoEGotejamento => new Profissao(2603, 643005, "Trabalhador na operação de sistema de irrigação localizada (microaspersão e gotejamento)");
        [NotMapped] public static Profissao TrabalhadorNaOperacaoDeSistemaDeIrrigacaoPorAspersaoPivoCentral => new Profissao(2604, 643010, "Trabalhador na operação de sistema de irrigação por aspersão (pivô central)");
        [NotMapped] public static Profissao TrabalhadorNaOperacaoDeSistemasConvencionaisDeIrrigacaoPorAspersao => new Profissao(2605, 643015, "Trabalhador na operação de sistemas convencionais de irrigação por aspersão");
        [NotMapped] public static Profissao TrabalhadorNaOperacaoDeSistemasDeIrrigacaoEAspersaoAltoPropelido => new Profissao(2606, 643020, "Trabalhador na operação de sistemas de irrigação e aspersão (alto propelido)");
        [NotMapped] public static Profissao TrabalhadorNaOperacaoDeSistemasDeIrrigacaoPorSuperficieEDrenagem => new Profissao(2607, 643025, "Trabalhador na operação de sistemas de irrigação por superfície e drenagem");
        [NotMapped] public static Profissao TrabalhadorNaProducaoDeMudasESementes => new Profissao(2608, 622015, "Trabalhador na produção de mudas e sementes");
        [NotMapped] public static Profissao TrabalhadorNaSericicultura => new Profissao(2609, 623420, "Trabalhador na sericicultura");
        [NotMapped] public static Profissao TrabalhadorNoCultivoDeArvoresFrutiferas => new Profissao(2610, 622505, "Trabalhador no cultivo de árvores frutíferas");
        [NotMapped] public static Profissao TrabalhadorNoCultivoDeEspeciesFrutiferasRasteiras => new Profissao(2611, 622510, "Trabalhador no cultivo de espécies frutíferas rasteiras");
        [NotMapped] public static Profissao TrabalhadorNoCultivoDeFloresEFolhagensDeCorte => new Profissao(2612, 622405, "Trabalhador no cultivo de flores e folhagens de corte");
        [NotMapped] public static Profissao TrabalhadorNoCultivoDeFloresEmVaso => new Profissao(2613, 622410, "Trabalhador no cultivo de flores em vaso");
        [NotMapped] public static Profissao TrabalhadorNoCultivoDeForracoes => new Profissao(2614, 622415, "Trabalhador no cultivo de forrações");
        [NotMapped] public static Profissao TrabalhadorNoCultivoDeMudas => new Profissao(2615, 622420, "Trabalhador no cultivo de mudas");
        [NotMapped] public static Profissao TrabalhadorNoCultivoDePlantasOrnamentais => new Profissao(2616, 622425, "Trabalhador no cultivo de plantas ornamentais");
        [NotMapped] public static Profissao TrabalhadorNoCultivoDeTrepadeirasFrutiferas => new Profissao(2617, 622515, "Trabalhador no cultivo de trepadeiras frutíferas");
        [NotMapped] public static Profissao TrabalhadorPolivalenteDaConfeccaoDeCalcados => new Profissao(2618, 764005, "Trabalhador polivalente da confecção de calçados");
        [NotMapped] public static Profissao TrabalhadorPolivalenteDoCurtimentoDeCourosEPeles => new Profissao(2619, 762005, "Trabalhador polivalente do curtimento de couros e peles");
        [NotMapped] public static Profissao TrabalhadorPortuarioDeCapatazia => new Profissao(2620, 783235, "Trabalhador portuário de capatazia");
        [NotMapped] public static Profissao TrabalhadorVolanteDaAgricultura => new Profissao(2621, 622020, "Trabalhador volante da agricultura");
        [NotMapped] public static Profissao TracadorDePedras => new Profissao(2622, 712230, "Traçador de pedras");
        [NotMapped] public static Profissao Tradutor => new Profissao(2623, 261420, "Tradutor");
        [NotMapped] public static Profissao TrancadorDeCabosDeAco => new Profissao(2624, 724610, "Trançador de cabos de aço");
        [NotMapped] public static Profissao TransformadorDeTubosDeVidro => new Profissao(2625, 752120, "Transformador de tubos de vidro");
        [NotMapped] public static Profissao Trapezista => new Profissao(2626, 376255, "Trapezista");
        [NotMapped] public static Profissao TratadorDeAnimais => new Profissao(2627, 623020, "Tratador de animais");
        [NotMapped] public static Profissao TratoristaAgricola => new Profissao(2628, 641015, "Tratorista agrícola");
        [NotMapped] public static Profissao TrefiladorJoalheriaEOurivesaria => new Profissao(2629, 751130, "Trefilador (joalheria e ourivesaria)");
        [NotMapped] public static Profissao TrefiladorDeBorracha => new Profissao(2630, 811775, "Trefilador de borracha");
        [NotMapped] public static Profissao TrefiladorDeMetaisAMaquina => new Profissao(2631, 722415, "Trefilador de metais, à máquina");
        [NotMapped] public static Profissao TreinadorProfissionalDeFutebol => new Profissao(2632, 224135, "Treinador profissional de futebol");
        [NotMapped] public static Profissao TricoteiroAMao => new Profissao(2633, 768115, "Tricoteiro, à mão");
        [NotMapped] public static Profissao Tropeiro => new Profissao(2634, 782810, "Tropeiro");
        [NotMapped] public static Profissao Turismologo => new Profissao(2635, 122520, "Turismólogo");
        [NotMapped] public static Profissao Urbanista => new Profissao(2636, 214130, "Urbanista");
        [NotMapped] public static Profissao VaqueadorDeCourosEPeles => new Profissao(2637, 762345, "Vaqueador de couros e peles");
        [NotMapped] public static Profissao VarredorDeRua => new Profissao(2638, 514215, "Varredor de rua");
        [NotMapped] public static Profissao Vassoureiro => new Profissao(2639, 776430, "Vassoureiro");
        [NotMapped] public static Profissao VendedorPermissionario => new Profissao(2640, 524215, "Vendedor  permissionário");
        [NotMapped] public static Profissao VendedorAmbulante => new Profissao(2641, 524305, "Vendedor ambulante");
        [NotMapped] public static Profissao VendedorDeComercioVarejista => new Profissao(2642, 521110, "Vendedor de comércio varejista");
        [NotMapped] public static Profissao VendedorEmComercioAtacadista => new Profissao(2643, 521105, "Vendedor em comércio atacadista");
        [NotMapped] public static Profissao VendedorEmDomicilio => new Profissao(2644, 524105, "Vendedor em domicílio");
        [NotMapped] public static Profissao VendedorPracista => new Profissao(2645, 354145, "Vendedor pracista");
        [NotMapped] public static Profissao Vereador => new Profissao(2646, 111120, "Vereador");
        [NotMapped] public static Profissao Vibradorista => new Profissao(2647, 717025, "Vibradorista");
        [NotMapped] public static Profissao ViceGovernadorDeEstado => new Profissao(2648, 111240, "Vice-governador de estado");
        [NotMapped] public static Profissao ViceGovernadorDoDistritoFederal => new Profissao(2649, 111245, "Vice-governador do distrito federal");
        [NotMapped] public static Profissao VicePrefeito => new Profissao(2650, 111255, "Vice-prefeito");
        [NotMapped] public static Profissao VicePresidenteDaRepublica => new Profissao(2651, 111210, "Vice-presidente da república");
        [NotMapped] public static Profissao Vidraceiro => new Profissao(2652, 716305, "Vidraceiro");
        [NotMapped] public static Profissao VidraceiroEdificacoes => new Profissao(2653, 716310, "Vidraceiro (edificações)");
        [NotMapped] public static Profissao VidraceiroVitrais => new Profissao(2654, 716315, "Vidraceiro (vitrais)");
        [NotMapped] public static Profissao Vigia => new Profissao(2655, 517420, "Vigia");
        [NotMapped] public static Profissao VigiaFlorestal => new Profissao(2656, 517320, "Vigia florestal");
        [NotMapped] public static Profissao VigiaPortuario => new Profissao(2657, 517325, "Vigia portuário");
        [NotMapped] public static Profissao Vigilante => new Profissao(2658, 517330, "Vigilante");
        [NotMapped] public static Profissao Vinagreiro => new Profissao(2659, 841740, "Vinagreiro");
        [NotMapped] public static Profissao VisitadorSanitario => new Profissao(2660, 515120, "Visitador sanitário");
        [NotMapped] public static Profissao VistoriadorNaval => new Profissao(2661, 215150, "Vistoriador naval");
        [NotMapped] public static Profissao VisualMerchandiser => new Profissao(2662, 375115, "Visual merchandiser");
        [NotMapped] public static Profissao ViveiristaFlorestal => new Profissao(2663, 632015, "Viveirista florestal");
        [NotMapped] public static Profissao Xaropeiro => new Profissao(2664, 841745, "Xaropeiro");
        [NotMapped] public static Profissao ZeladorDeEdificio => new Profissao(2665, 514120, "Zelador de edifício");
        [NotMapped] public static Profissao Zootecnista => new Profissao(2666, 223310, "Zootecnista");
        [NotMapped] public static Profissao Balconista => new Profissao(2667, 999999, "Balconista");
        [NotMapped] public static Profissao Aposentado => new Profissao(2668, 999998, "Aposentado");
        [NotMapped] public static Profissao Pensionista => new Profissao(2669, 999997, "Pensionista");
        [NotMapped] public static Profissao Autonomo => new Profissao(2670, 999996, "Autônomo");
        [NotMapped] public static Profissao DoLar => new Profissao(2671, 999995, "Do Lar");
        [NotMapped] public static Profissao AuxiliarDeServicosGerais => new Profissao(2672, 999994, "Auxiliar de serviços gerais");
        [NotMapped] public static Profissao ServidorPublico => new Profissao(2673, 999993, "Servidor Público");
        [NotMapped] public static Profissao Estagiario => new Profissao(2674, 999992, "Estagiário");
        [NotMapped] public static Profissao Militar => new Profissao(2675, 999991, "Militar");
        [NotMapped] public static Profissao Empresario => new Profissao(2676, 999990, "Empresário");
        [NotMapped] public static Profissao Professor => new Profissao(2677, 999989, "Professor");
        [NotMapped] public static Profissao Comerciante => new Profissao(2678, 999988, "Comerciante");
        [NotMapped] public static Profissao Outros => new Profissao(2679, 999987, "Outros");
        [NotMapped] public static Profissao Pecuarista => new Profissao(2680, 999986, "Pecuarista");//
        [NotMapped] public static Profissao GerenteDeCusto => new Profissao(2681, 999985, "Gerente de custo");
        [NotMapped] public static Profissao AuxiliarDeProducao => new Profissao(2682, 999984, "AuxiliarDeProdução");
        [NotMapped] public static Profissao MecanicoDeDiesel => new Profissao(2683, 999983, "Mecânico de Diesel");
        [NotMapped] public static Profissao PreparadorDeCoquetel => new Profissao(2684, 999982, "Preparador de coquetel");
        [NotMapped] public static Profissao Bancario => new Profissao(2685, 999981, "Bancário");
        [NotMapped] public static Profissao Devops => new Profissao(2686, 999980, "Devops");
        [NotMapped] public static Profissao Programador => new Profissao(2687, 999979, "Programador");


        public Profissao(int id, int codigo, string nome)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
        }

        public static Profissao[] ObterDados()
        {
            return new Profissao[]
            {
                Abatedor,
                AcabadorDeCalcados,
                AcabadorDeEmbalagensFlexiveisECartotecnicas,
                AcabadorDeSuperficiesDeConcreto,
                Acougueiro,
                Acrobata,
                AdestradorDeAnimais,
                Administrador,
                AdministradorDeBancoDeDados,
                AdministradorDeEdificios,
                AdministradorDeFundosECarteirasDeInvestimento,
                AdministradorDeRedes,
                AdministradorDeSistemasOperacionais,
                AdministradorEmSegurancaDaInformacao,
                Advogado,
                AdvogadoAreasEspeciais,
                AdvogadoDireitoCivil,
                AdvogadoDireitoDoTrabalho,
                AdvogadoDireitoPenal,
                AdvogadoDireitoPublico,
                AdvogadoDaUniao,
                AdvogadoDeEmpresa,
                AfiadorDeCardas,
                AfiadorDeCutelaria,
                AfiadorDeFerramentas,
                AfiadorDeSerras,
                AfinadorDeInstrumentosMusicais,
                Afretador,
                AgenciadorDePropaganda,
                AgenteComunitarioDeSaude,
                AgenteDeAcaoSocial,
                AgenteDeCombateAsEndemias,
                AgenteDeDefesaAmbiental,
                AgenteDeDireitosAutorais,
                AgenteDeEstacaoFerroviaEMetro,
                AgenteDeHigieneESeguranca,
                AgenteDeInteligencia,
                AgenteDeManobraEDocagem,
                AgenteDeMicrocredito,
                AgenteDePatio,
                AgenteDePoliciaFederal,
                AgenteDePortaria,
                AgenteDeProtecaoDeAeroporto,
                AgenteDeProtecaoDeAviacaoCivil,
                AgenteDeRecrutamentoESelecao,
                AgenteDeSaudePublica,
                AgenteDeSeguranca,
                AgenteDeSegurancaPenitenciaria,
                AgenteDeTransito,
                AgenteDeVendasDeServicos,
                AgenteDeViagem,
                AgenteFiscalDeQualidade,
                AgenteFiscalMetrologico,
                AgenteFiscalTextil,
                AgenteFunerario,
                AgenteIndigenaDeSaneamento,
                AgenteIndigenaDeSaude,
                AgenteTecnicoDeInteligencia,
                AjudanteDeCarvoaria,
                AjudanteDeConfeccao,
                AjudanteDeDespachanteAduaneiro,
                AjudanteDeMotorista,
                AjustadorDeInstrumentosDePrecisao,
                AjustadorFerramenteiro,
                AjustadorMecanico,
                AjustadorMecanicoUsinagemEmBancadaEEmMaquinasFerramentas,
                AjustadorMecanicoEmBancada,
                AjustadorNavalReparoEConstrucao,
                Alambiqueiro,
                Alfaiate,
                AlimentadorDeLinhaDeProducao,
                AlinhadorDePneus,
                Almoxarife,
                AlvejadorTecidos,
                AmarradorEDesamarradoDeEmbarcacoes,
                AmostradorDeMinerios,
                AnalistaDeCambio,
                AnalistaDeCobrancaInstituicoesFinanceiras,
                AnalistaDeCompliance,
                AnalistaDeCreditoInstituicoesFinanceiras,
                AnalistaDeCreditoRural,
                AnalistaDeDesembaracoAduaneiro,
                AnalistaDeDesenvolvimentoDeSistemas,
                AnalistaDeExportacaoEImportacao,
                AnalistaDeFolhaDePagamento,
                AnalistaDeGestaoDeEstoque,
                AnalistaDeInformacaoEmSaude,
                AnalistaDeInformacoesPesquisadorDeInformacoesDeRede,
                AnalistaDeLeasing,
                AnalistaDeLogistica,
                AnalistaDeManutencaoEquipamentosAereos,
                AnalistaDeMidiasSociais,
                AnalistaDeNegocios,
                AnalistaDePcpProgramacaoEControleDaProducao,
                AnalistaDePesquisaDeMercado,
                AnalistaDePlanejamentoDeManutencao,
                AnalistaDePlanejamentoDeMaterias,
                AnalistaDePlanejamentoEOrcamentoApo,
                AnalistaDeProdutosBancarios,
                AnalistaDeProjetosLogisticos,
                AnalistaDeRecursosHumanos,
                AnalistaDeRedesEDeComunicacaoDeDados,
                AnalistaDeRiscos,
                AnalistaDeSegurosTecnico,
                AnalistaDeSinistros,
                AnalistaDeSistemasDeAutomacao,
                AnalistaDeSuporteComputacional,
                AnalistaDeTestesDeTecnologiaDaInformacao,
                AnalistaDeTransporteEmComercioExterior,
                AnalistaFinanceiroInstituicoesFinanceiras,
                AnalistaMusical,
                AncoraDeMidiasAudiovisuais,
                Antropologo,
                Apicultor,
                AplicadorDeAsfaltoImpermeabilizanteCoberturas,
                AplicadorDeProvasConcursoAvaliacaoExame,
                AplicadorDeVinilAutoadesivo,
                AplicadorSerigraficoEmVidros,
                ApontadorDeMaoDeObra,
                ApontadorDeProducao,
                ApresentadorDeCirco,
                ApresentadorDeEventos,
                ApresentadorDeFestasPopulares,
                ApresentadorDeProgramasDeRadio,
                ApresentadorDeProgramasDeTelevisao,
                ArbitroDeAtletismo,
                ArbitroDeBasquete,
                ArbitroDeFutebol,
                ArbitroDeFutebolDeSalao,
                ArbitroDeJudo,
                ArbitroDeKarate,
                ArbitroDePoloAquatico,
                ArbitroDeVolei,
                ArbitroDesportivo,
                ArbitroExtrajudicial,
                ArmadorDeEstruturaDeConcreto,
                ArmadorDeEstruturaDeConcretoArmado,
                Armazenista,
                Aromista,
                Arqueologo,
                ArquitetoDeEdificacoes,
                ArquitetoDeInteriores,
                ArquitetoDePatrimonio,
                ArquitetoDeSolucoesDeTecnologiaDaInformacao,
                ArquitetoPaisagista,
                ArquitetoUrbanista,
                Arquivista,
                ArquivistaDeDocumentos,
                ArquivistaPesquisadorJornalismo,
                Arrematadeira,
                ArtesaoBordador,
                ArtesaoCeramista,
                ArtesaoComMaterialReciclavel,
                ArtesaoConfeccionadorDeBiojoiasEEcojoias,
                ArtesaoCrocheteiro,
                ArtesaoDoCouro,
                ArtesaoEscultor,
                ArtesaoModeladorVidros,
                ArtesaoMoveleiroExcetoReciclado,
                ArtesaoRendeiro,
                ArtesaoTecelao,
                ArtesaoTrancador,
                ArtesaoTricoteiro,
                Arteterapeuta,
                ArtificeDoCouro,
                ArtistaArtesVisuais,
                ArtistaAereo,
                ArtistaDeCircoOutros,
                Ascensorista,
                AssentadorDeCanalizacaoEdificacoes,
                AssentadorDeRevestimentosCeramicos,
                AssessorDeImprensa,
                AssistenteAdministrativo,
                AssistenteComercialDeSeguros,
                AssistenteDeCoreografia,
                AssistenteDeDirecaoTv,
                AssistenteDeLaboratorioIndustrial,
                AssistenteDeOperacoesAudiovisuais,
                AssistenteDeVendas,
                AssistenteSocial,
                AssistenteTecnicoDeSeguros,
                Assoalhador,
                Astrologo,
                Astronomo,
                AtendenteComercialAgenciaPostal,
                AtendenteDeAgencia,
                AtendenteDeEnfermagem,
                AtendenteDeFarmaciaBalconista,
                AtendenteDeJudiciario,
                AtendenteDeLanchonete,
                AtendenteDeLavanderia,
                AtendenteDeLojasEMercados,
                AtletaProfissionalOutrasModalidades,
                AtletaProfissionalDeFutebol,
                AtletaProfissionalDeGolfe,
                AtletaProfissionalDeLuta,
                AtletaProfissionalDeTenis,
                Ator,
                Atuario,
                Audiodescritor,
                AuditorContadoresEAfins,
                AuditorFiscalDaPrevidenciaSocial,
                AuditorFiscalDaReceitaFederal,
                AuditorFiscalDoTrabalho,
                AutorRoteirista,
                AuxiliarDeBancoDeSangue,
                AuxiliarDeBiblioteca,
                AuxiliarDeCartorio,
                AuxiliarDeContabilidade,
                AuxiliarDeCortePreparacaoDaConfeccaoDeRoupas,
                AuxiliarDeDesenvolvimentoInfantil,
                AuxiliarDeEnfermagem,
                AuxiliarDeEnfermagemDaEstrategiaDeSaudeDaFamilia,
                AuxiliarDeEnfermagemDoTrabalho,
                AuxiliarDeEscritorio,
                AuxiliarDeEstatistica,
                AuxiliarDeFarmaciaDeManipulacao,
                AuxiliarDeFaturamento,
                AuxiliarDeJudiciario,
                AuxiliarDeLaboratorioDeAnalisesClinicas,
                AuxiliarDeLaboratorioDeAnalisesFisicoQuimicas,
                AuxiliarDeLaboratorioDeImunobiologicos,
                AuxiliarDeLavanderia,
                AuxiliarDeLogistica,
                AuxiliarDeManutencaoPredial,
                AuxiliarDeMaquinistaDeTrem,
                AuxiliarDePessoal,
                AuxiliarDeProcessamentoDeFumo,
                AuxiliarDeProducaoFarmaceutica,
                AuxiliarDeProteseDentaria,
                AuxiliarDeRadiologiaRevelacaoFotografica,
                AuxiliarDeSaudeNavegacaoMaritima,
                AuxiliarDeSeguros,
                AuxiliarDeServicosDeImportacaoEExportacao,
                AuxiliarDeServicosJuridicos,
                AuxiliarDeVeterinario,
                AuxiliarEmSaudeBucal,
                AuxiliarEmSaudeBucalDaEstrategiaDeSaudeDaFamilia,
                AuxiliarGeralDeConservacaoDeViasPermanentesExcetoTrilhos,
                AuxiliarNosServicosDeAlimentacao,
                AuxiliarTecnicoDeSinalizacaoNautica,
                AuxiliarTecnicoEmLaboratorioDeFarmacia,
                AvaliadorDeBensMoveis,
                AvaliadorDeImoveis,
                AvaliadorDeProdutosDosMeiosDeComunicacao,
                AvaliadorFisico,
                Avicultor,
                Baba,
                BaianaDeAcaraje,
                BailarinoExcetoDancasPopulares,
                Balanceador,
                Balanceiro,
                Bamburista,
                BanhistaDeAnimaisDomesticos,
                Barbeiro,
                Barista,
                Barman,
                BateFolhaAMaquina,
                Bibliotecario,
                BilheteiroEstacoesDeMetroFerroviariasEAssemelhadas,
                BilheteiroDeTransportesColetivos,
                BilheteiroNoServicoDeDiversoes,
                Bioengenheiro,
                Biologo,
                Biomedico,
                Biotecnologista,
                BloqueiroTrabalhadorPortuario,
                BobinadorEletricistaAMao,
                BobinadorEletricistaAMaquina,
                Boiadeiro,
                BombeiroCivil,
                BombeiroDeAerodromo,
                Boneleiro,
                BordadorAMao,
                BordadorAMaquina,
                Borracheiro,
                Brasador,
                BrigadistaFlorestal,
                Cabeleireiro,
                Cableador,
                CaboBombeiroMilitar,
                CaboDaPoliciaMilitar,
                Cacique,
                Cafeicultor,
                CaixaDeBanco,
                Calafetador,
                CalandristaDeBorracha,
                CalandristaDePapel,
                Calceteiro,
                CaldeireiroChapasDeCobre,
                CaldeireiroChapasDeFerroEAco,
                CamareiroDeHotel,
                CamareiroDeEmbarcacoes,
                CamareiroDeTeatro,
                CamareiroDeTelevisao,
                CaminhoneiroAutonomoRotasRegionaisEInternacionais,
                Canteiro,
                CapitaoBombeiroMilitar,
                CapitaoDaPoliciaMilitar,
                CapitaoDeManobraDaMarinhaMercante,
                CaptadorDeRecursos,
                Carbonizador,
                Carpinteiro,
                CarpinteiroCenarios,
                CarpinteiroEsquadrias,
                CarpinteiroMineracao,
                CarpinteiroTelhados,
                CarpinteiroDeCarretas,
                CarpinteiroDeCarrocerias,
                CarpinteiroDeFormasParaConcreto,
                CarpinteiroDeObras,
                CarpinteiroDeObrasCivisDeArtePontesTuneisBarragens,
                CarpinteiroNavalConstrucaoDePequenasEmbarcacoes,
                CarpinteiroNavalEmbarcacoes,
                CarpinteiroNavalEstaleiros,
                CarregadorAeronaves,
                CarregadorArmazem,
                CarregadorVeiculosDeTransportesTerrestres,
                Cartazeiro,
                Carteiro,
                CartonageiroAMaoCaixasDePapelao,
                CartonageiroAMaquina,
                Carvoeiro,
                CaseiroAgricultura,
                CasqueadorDeAnimais,
                CatadorDeCaranguejosESiris,
                CatadorDeMariscos,
                CatadorDeMaterialReciclavel,
                CelofanistaNaFabricacaoDeCharutos,
                CementadorDeMetais,
                CenografoCarnavalescoEFestasPopulares,
                CenografoDeCinema,
                CenografoDeEventos,
                CenografoDeTeatro,
                CenografoDeTv,
                CenotecnicoCinemaVideoTelevisaoTeatroEEspetaculos,
                Ceramista,
                CeramistaTornoDePedalEMotor,
                CeramistaTornoSemiAutomatico,
                CeramistaModelador,
                CeramistaMoldador,
                CeramistaPrensador,
                Cerimonialista,
                Cerzidor,
                Cesteiro,
                Chapeador,
                ChapeadorDeAeronaves,
                ChapeadorDeCarroceriasMetalicasFabricacao,
                ChapeadorNaval,
                ChapeleiroChapeusDePalha,
                ChapeleiroDeSenhoras,
                CharuteiroAMao,
                Chaveiro,
                ChefeDeBar,
                ChefeDeBrigada,
                ChefeDeConfeitaria,
                ChefeDeContabilidadeTecnico,
                ChefeDeCozinha,
                ChefeDeEstacaoPortuaria,
                ChefeDePortariaDeHotel,
                ChefeDeServicoDeTransporteRodoviarioPassageirosECargas,
                ChefeDeServicosBancarios,
                Churrasqueiro,
                CiclistaMensageiro,
                CientistaPolitico,
                CilindreiroNaPreparacaoDePastaParaFabricacaoDePapel,
                CilindristaPetroquimicaEAfins,
                CimentadorPocosDePetroleo,
                CirurgiaoDentistaAuditor,
                CirurgiaoDentistaClinicoGeral,
                CirurgiaoDentistaDentistica,
                CirurgiaoDentistaDisfuncaoTemporomandibularEDorOrofacial,
                CirurgiaoDentistaEndodontista,
                CirurgiaoDentistaEpidemiologista,
                CirurgiaoDentistaEstomatologista,
                CirurgiaoDentistaImplantodontista,
                CirurgiaoDentistaOdontogeriatra,
                CirurgiaoDentistaOdontologiaDoTrabalho,
                CirurgiaoDentistaOdontologiaParaPacientesComNecessidadesEspeciais,
                CirurgiaoDentistaOdontologistaLegal,
                CirurgiaoDentistaOdontopediatra,
                CirurgiaoDentistaOrtopedistaEOrtodontista,
                CirurgiaoDentistaPatologistaBucal,
                CirurgiaoDentistaPeriodontista,
                CirurgiaoDentistaProtesiologoBucomaxilofacial,
                CirurgiaoDentistaProtesista,
                CirurgiaoDentistaRadiologista,
                CirurgiaoDentistaReabilitadorOral,
                CirurgiaoDentistaTraumatologistaBucomaxilofacial,
                CirurgiaoDentistaDeSaudeColetiva,
                CirurgiaoDentistaDaEstrategiaDeSaudeDaFamilia,
                Citotecnico,
                ClassificadorDeCharutos,
                ClassificadorDeCouros,
                ClassificadorDeFibrasTexteis,
                ClassificadorDeFumo,
                ClassificadorDeGraos,
                ClassificadorDeMadeira,
                ClassificadorDePeles,
                ClassificadorDeToras,
                ClassificadorEEmpilhadorDeTijolosRefratarios,
                CobradorDeTransportesColetivosExcetoTrem,
                CobradorExterno,
                CobradorInterno,
                CodificadorDeDados,
                ColchoeiroConfeccaoDeColchoes,
                ColecionadorDeSelosEMoedas,
                ColetorDeLixoDomiciliar,
                ColetorDeResiduosSolidosDeServicosDeSaude,
                ColoristaDePapel,
                ColoristaTextil,
                ComandanteDaMarinhaMercante,
                ComentaristaDeMidiasAudiovisuais,
                ComercianteAtacadista,
                ComercianteVarejista,
                ComissarioDeTrem,
                ComissarioDeVoo,
                CompensadorDeBanco,
                Compositor,
                Comprador,
                Concierge,
                CondutorDeAmbulancia,
                CondutorDeMaquinas,
                CondutorDeMaquinasBombeador,
                CondutorDeMaquinasMecanico,
                CondutorDeProcessosRobotizadosDePintura,
                CondutorDeProcessosRobotizadosDeSoldagem,
                CondutorDeTurismoDeAventura,
                CondutorDeTurismoDePesca,
                CondutorDeVeiculosAPedais,
                CondutorDeVeiculosDeTracaoAnimalRuasEEstradas,
                CondutorMaquinistaMotoristaFluvial,
                ConfeccionadorDeAcordeao,
                ConfeccionadorDeArtefatosDeCouroExcetoSapatos,
                ConfeccionadorDeBolsasSacosESacolasEPapelAMaquina,
                ConfeccionadorDeBrinquedosDePano,
                ConfeccionadorDeCarimbosDeBorracha,
                ConfeccionadorDeEscovasPinceisEProdutosSimilaresAMao,
                ConfeccionadorDeEscovasPinceisEProdutosSimilaresAMaquina,
                ConfeccionadorDeInstrumentosDeCorda,
                ConfeccionadorDeInstrumentosDePercussaoPeleCouroOuPlastico,
                ConfeccionadorDeInstrumentosDeSoproMadeira,
                ConfeccionadorDeInstrumentosDeSoproMetal,
                ConfeccionadorDeMoveisDeVimeJuncoEBambu,
                ConfeccionadorDeOrgao,
                ConfeccionadorDePiano,
                ConfeccionadorDePneumaticos,
                ConfeccionadorDeSacosDeCelofaneAMaquina,
                ConfeccionadorDeVelasNauticasBarracasEToldos,
                ConfeccionadorDeVelasPorImersao,
                ConfeccionadorDeVelasPorMoldagem,
                Confeiteiro,
                ConferenteDeCargaEDescarga,
                ConferenteDeServicosBancarios,
                ConferenteMercadoriaExcetoCargaEDescarga,
                ConferenteExpedidorDeRoupasLavanderias,
                ConselheiroJulgador,
                ConselheiroTutelar,
                ConservadorDeViaPermanenteTrilhos,
                ConservadorRestauradorDeBensCulturais,
                ConsultorContabilTecnico,
                ConsultorJuridico,
                Contador,
                Continuista,
                Continuo,
                Contorcionista,
                ContramestreDeAcabamentoIndustriaTextil,
                ContramestreDeCabotagem,
                ContramestreDeFiacaoIndustriaTextil,
                ContramestreDeMalhariaIndustriaTextil,
                ContramestreDeTecelagemIndustriaTextil,
                ControladorDeEntradaESaida,
                ControladorDePragas,
                ControladorDeServicosDeMaquinasEVeiculos,
                ControladorDeTrafegoAereo,
                CoordenadorDeOperacoesDeCombateAPoluicaoNoMeioAquaviario,
                CoordenadorDeProgramacao,
                CoordenadorDeProvasConcursoAvaliacaoExame,
                CoordenadorPedagogico,
                Copeiro,
                CopeiroDeHospital,
                CopiadorDeChapa,
                Coreografo,
                CoronelBombeiroMilitar,
                CoronelDaPoliciaMilitar,
                CorretorDeGraos,
                CorretorDeImoveis,
                CorretorDeSeguros,
                CorretorDeValoresAtivosFinanceirosMercadoriasEDerivativos,
                CortadorDeArtefatosDeCouroExcetoRoupasECalcados,
                CortadorDeCalcadosAMaoExcetoSolas,
                CortadorDeCalcadosAMaquinaExcetoSolasEPalmilhas,
                CortadorDeCharutos,
                CortadorDeLaminadosDeMadeira,
                CortadorDePedras,
                CortadorDeRoupas,
                CortadorDeSolasEPalmilhasAMaquina,
                CortadorDeTapecaria,
                CortadorDeVidro,
                CosturadorDeArtefatosDeCouroAMaoExcetoRoupasECalcados,
                CosturadorDeArtefatosDeCouroAMaquinaExcetoRoupasECalcados,
                CosturadorDeCalcadosAMaquina,
                CostureiraDePecasSobEncomenda,
                CostureiraDeReparacaoDeRoupas,
                CostureiroDeRoupaDeCouroEPele,
                CostureiroDeRoupasDeCouroEPeleAMaquinaNaConfeccaoEmSerie,
                CostureiroNaConfeccaoEmSerie,
                CostureiroAMaquinaNaConfeccaoEmSerie,
                CozinhadorConservacaoDeAlimentos,
                CozinhadorDeCarnes,
                CozinhadorDeFrutasELegumes,
                CozinhadorDeMalte,
                CozinhadorDePescado,
                CozinheiroDeEmbarcacoes,
                CozinheiroDeHospital,
                CozinheiroDoServicoDomestico,
                CozinheiroGeral,
                CozinheiroIndustrial,
                CriadorDeAnimaisDomesticos,
                CriadorDeAnimaisProdutoresDeVeneno,
                CriadorDeAsininosEMuares,
                CriadorDeBovinosCorte,
                CriadorDeBovinosLeite,
                CriadorDeBubalinosCorte,
                CriadorDeBubalinosLeite,
                CriadorDeCamaroes,
                CriadorDeCaprinos,
                CriadorDeEquinos,
                CriadorDeJacares,
                CriadorDeMexilhoes,
                CriadorDeOstras,
                CriadorDeOvinos,
                CriadorDePeixes,
                CriadorDeQuelonios,
                CriadorDeRas,
                CriadorDeSuinos,
                CriadorEmPecuariaPolivalente,
                Critico,
                CrocheteiroAMao,
                Cronoanalista,
                Cronometrista,
                CubadorDeMadeira,
                CuidadorDeIdosos,
                CuidadorEmSaude,
                Cumim,
                Cunicultor,
                CurtidorCourosEPeles,
                DancarinoPopular,
                DancarinoTradicional,
                Datilografo,
                Decapador,
                DecoradorDeCeramica,
                DecoradorDeEventos,
                DecoradorDeInterioresDeNivelSuperior,
                DecoradorDeVidro,
                DecoradorDeVidroAPincel,
                DefensorPublico,
                DefumadorDeCarnesEPescados,
                DegustadorDeCafe,
                DegustadorDeCha,
                DegustadorDeCharutos,
                DegustadorDeDerivadosDeCacau,
                DegustadorDeVinhosOuLicores,
                DelegadoDePolicia,
                DemolidorDeEdificacoes,
                DemonstradorDeMercadorias,
                DeputadoEstadualEDistrital,
                DeputadoFederal,
                DescarnadorDeCourosEPelesAMaquina,
                DesenhistaCopista,
                DesenhistaDetalhista,
                DesenhistaIndustrialDeProdutoDesignerDeProduto,
                DesenhistaIndustrialDeProdutoDeModaDesignerDeModa,
                DesenhistaIndustrialGraficoDesignerGrafico,
                DesenhistaProjetistaDeArquitetura,
                DesenhistaProjetistaDeConstrucaoCivil,
                DesenhistaProjetistaDeEletricidade,
                DesenhistaProjetistaDeMaquinas,
                DesenhistaProjetistaEletronico,
                DesenhistaProjetistaMecanico,
                DesenhistaTecnico,
                DesenhistaTecnicoArquitetura,
                DesenhistaTecnicoArtesGraficas,
                DesenhistaTecnicoCalefacaoVentilacaoERefrigeracao,
                DesenhistaTecnicoCartografia,
                DesenhistaTecnicoConstrucaoCivil,
                DesenhistaTecnicoEletricidadeEEletronica,
                DesenhistaTecnicoIlustracoesArtisticas,
                DesenhistaTecnicoIlustracoesTecnicas,
                DesenhistaTecnicoIndustriaTextil,
                DesenhistaTecnicoInstalacoesHidrossanitarias,
                DesenhistaTecnicoMobiliario,
                DesenhistaTecnicoAeronautico,
                DesenhistaTecnicoDeEmbalagensMaquetesELeiautes,
                DesenhistaTecnicoMecanico,
                DesenhistaTecnicoNaval,
                DesenvolvedorDeMultimidia,
                DesenvolvedorDeSistemasDeTecnologiaDaInformacaoTecnico,
                DesenvolvedorWebTecnico,
                DesidratadorDeAlimentos,
                DesignerDeInteriores,
                DesignerDeVitrines,
                DesignerEducacional,
                DesincrustadorPocosDePetroleo,
                Desossador,
                DespachanteAduaneiro,
                DespachanteDeTransito,
                DespachanteDeTransportesColetivosExcetoTrem,
                DespachanteDocumentalista,
                DespachanteOperacionalDeVoo,
                DessecadorDeMalte,
                DestiladorDeMadeira,
                DestiladorDeProdutosQuimicosExcetoPetroleo,
                DestrocadorDePedra,
                DetetiveProfissional,
                Detonador,
                Dietista,
                Digitador,
                DiretorAdministrativo,
                DiretorAdministrativoEFinanceiro,
                DiretorArtistico,
                DiretorComercial,
                DiretorComercialEmOperacoesDeIntermediacaoFinanceira,
                DiretorDeProducaoEOperacoesDeAlimentacao,
                DiretorDeProducaoEOperacoesDeHotel,
                DiretorDeProducaoEOperacoesDeTurismo,
                DiretorDeArte,
                DiretorDeArtePublicidade,
                DiretorDeCambioEComercioExterior,
                DiretorDeCinema,
                DiretorDeCompliance,
                DiretorDeContasPublicidade,
                DiretorDeCreditoExcetoCreditoImobiliario,
                DiretorDeCreditoImobiliario,
                DiretorDeCreditoRural,
                DiretorDeCriacao,
                DiretorDeFotografia,
                DiretorDeImagensTv,
                DiretorDeInstituicaoEducacionalDaAreaPrivada,
                DiretorDeInstituicaoEducacionalPublica,
                DiretorDeLeasing,
                DiretorDeManutencao,
                DiretorDeMarketing,
                DiretorDeMercadoDeCapitais,
                DiretorDeMidiaPublicidade,
                DiretorDeOperacoesComerciaisComercioAtacadistaEVarejista,
                DiretorDeOperacoesDeCorreios,
                DiretorDeOperacoesDeObrasPublicaECivil,
                DiretorDeOperacoesDeServicosDeArmazenamento,
                DiretorDeOperacoesDeServicosDeTelecomunicacoes,
                DiretorDeOperacoesDeServicosDeTransporte,
                DiretorDePesquisaEDesenvolvimentoPD,
                DiretorDePlanejamentoEstrategico,
                DiretorDeProducao,
                DiretorDeProducaoEOperacoesDaIndustriaDeTransformacaoExtracaoMineralEUtilidades,
                DiretorDeProducaoEOperacoesEmEmpresaAgropecuaria,
                DiretorDeProducaoEOperacoesEmEmpresaAquicola,
                DiretorDeProducaoEOperacoesEmEmpresaFlorestal,
                DiretorDeProducaoEOperacoesEmEmpresaPesqueira,
                DiretorDeProdutosBancarios,
                DiretorDeProgramacao,
                DiretorDeProgramasDeRadio,
                DiretorDeProgramasDeTelevisao,
                DiretorDeRecuperacaoDeCreditosEmOperacoesDeIntermediacaoFinanceira,
                DiretorDeRecursosHumanos,
                DiretorDeRedacao,
                DiretorDeRelacoesDeTrabalho,
                DiretorDeRiscosDeMercado,
                DiretorDeServicosCulturais,
                DiretorDeServicosDeSaude,
                DiretorDeServicosSociais,
                DiretorDeSuprimentos,
                DiretorDeSuprimentosNoServicoPublico,
                DiretorDeTecnologiaDaInformacao,
                DiretorFinanceiro,
                DiretorGeralDeEmpresaEOrganizacoesExcetoDeInteressePublico,
                DiretorTeatral,
                DirigenteDePartidoPolitico,
                DirigenteDoServicoPublicoEstadualEDistrital,
                DirigenteDoServicoPublicoFederal,
                DirigenteDoServicoPublicoMunicipal,
                DirigenteEAdministradorDeOrganizacaoDaSociedadeCivilSemFinsLucrativos,
                DirigenteEAdministradorDeOrganizacaoReligiosa,
                DirigentesDeEntidadesDeTrabalhadores,
                DirigentesDeEntidadesPatronais,
                DjDiscJockey,
                Documentalista,
                DomadorDeAnimaisCircense,
                Doula,
                DrageadorMedicamentos,
                DramaturgoDeDanca,
                Economista,
                EconomistaAgroindustrial,
                EconomistaAmbiental,
                EconomistaDoSetorPublico,
                EconomistaDomestico,
                EconomistaFinanceiro,
                EconomistaIndustrial,
                EconomistaRegionalEUrbano,
                Editor,
                EditorDeJornal,
                EditorDeLivro,
                EditorDeMidiaAudiovisual,
                EditorDeMidiaEletronica,
                EditorDeRevista,
                EditorDeRevistaCientifica,
                EditorDeTextoEImagem,
                EducadorSocial,
                EletricistaDeBordo,
                EletricistaDeInstalacoes,
                EletricistaDeInstalacoesAeronaves,
                EletricistaDeInstalacoesCenarios,
                EletricistaDeInstalacoesEdificios,
                EletricistaDeInstalacoesEmbarcacoes,
                EletricistaDeInstalacoesVeiculosAutomotoresEMaquinasOperatrizesExcetoAeronavesEEmbarcacoes,
                EletricistaDeManutencaoDeLinhasEletricasTelefonicasEDeComunicacaoDeDados,
                EletricistaDeManutencaoEletroeletronica,
                EletromecanicoDeManutencaoDeElevadores,
                EletromecanicoDeManutencaoDeEscadasRolantes,
                EletromecanicoDeManutencaoDePortasAutomaticas,
                Eletrotecnico,
                EletrotecnicoProducaoDeEnergia,
                EletrotecnicoNaFabricacaoMontagemEInstalacaoDeMaquinasEEquipamentos,
                EmbaladorAMao,
                EmbaladorAMaquina,
                Embalsamador,
                EmendadorDeCabosEletricosETelefonicosAereosESubterraneos,
                EmissorDePassagens,
                EmpregadoDomesticoNosServicosGerais,
                EmpregadoDomesticoArrumador,
                EmpregadoDomesticoFaxineiro,
                EmpregadoDomesticoDiarista,
                Encanador,
                EncarregadoDeAcabamentoDeChapasEMetaisTempera,
                EncarregadoDeCorteNaConfeccaoDoVestuario,
                EncarregadoDeCosturaNaConfeccaoDoVestuario,
                EncarregadoDeEquipeDeConservacaoDeViasPermanentesExcetoTrilhos,
                EncarregadoDeManutencaoDeInstrumentosDeControleMedicaoESimilares,
                EncarregadoDeManutencaoEletricaDeVeiculos,
                EncarregadoDeManutencaoMecanicaDeSistemasOperacionais,
                EncarregadoGeralDeOperacoesDeConservacaoDeViasPermanentesExcetoTrilhos,
                Enfermeiro,
                EnfermeiroAuditor,
                EnfermeiroDaEstrategiaDeSaudeDaFamilia,
                EnfermeiroDeBordo,
                EnfermeiroDeCentroCirurgico,
                EnfermeiroDeTerapiaIntensiva,
                EnfermeiroDoTrabalho,
                EnfermeiroNefrologista,
                EnfermeiroNeonatologista,
                EnfermeiroObstetrico,
                EnfermeiroPsiquiatrico,
                EnfermeiroPuericultorEPediatrico,
                EnfermeiroSanitarista,
                EnfestadorDeRoupas,
                EngastadorJoias,
                EngenheiroAeronautico,
                EngenheiroAgricola,
                EngenheiroAgrimensor,
                EngenheiroAgronomo,
                EngenheiroAmbiental,
                EngenheiroCartografo,
                EngenheiroCivil,
                EngenheiroCivilAeroportos,
                EngenheiroCivilEdificacoes,
                EngenheiroCivilEstruturasMetalicas,
                EngenheiroCivilFerroviasEMetrovias,
                EngenheiroCivilGeotecnia,
                EngenheiroCivilHidraulica,
                EngenheiroCivilHidrologia,
                EngenheiroCivilPontesEViadutos,
                EngenheiroCivilPortosEViasNavegaveis,
                EngenheiroCivilRodovias,
                EngenheiroCivilSaneamento,
                EngenheiroCivilTransportesETransito,
                EngenheiroCivilTuneis,
                EngenheiroDeAlimentos,
                EngenheiroDeAplicativosEmComputacao,
                EngenheiroDeControleDeQualidade,
                EngenheiroDeControleEAutomacao,
                EngenheiroDeEquipamentosEmComputacao,
                EngenheiroDeLogistica,
                EngenheiroDeManutencaoDeTelecomunicacoes,
                EngenheiroDeMateriais,
                EngenheiroDeMinas,
                EngenheiroDeMinasBeneficiamento,
                EngenheiroDeMinasLavraACeuAberto,
                EngenheiroDeMinasLavraSubterranea,
                EngenheiroDeMinasPesquisaMineral,
                EngenheiroDeMinasPlanejamento,
                EngenheiroDeMinasProcesso,
                EngenheiroDeMinasProjeto,
                EngenheiroDePesca,
                EngenheiroDeProducao,
                EngenheiroDeRedesDeComunicacao,
                EngenheiroDeRiscos,
                EngenheiroDeSegurancaDoTrabalho,
                EngenheiroDeTelecomunicacoes,
                EngenheiroDeTemposEMovimentos,
                EngenheiroEletricista,
                EngenheiroEletricistaDeManutencao,
                EngenheiroEletricistaDeProjetos,
                EngenheiroEletronico,
                EngenheiroEletronicoDeManutencao,
                EngenheiroEletronicoDeProjetos,
                EngenheiroFlorestal,
                EngenheiroMecanico,
                EngenheiroMecanicoEnergiaNuclear,
                EngenheiroMecanicoAutomotivo,
                EngenheiroMecanicoIndustrial,
                EngenheiroMecatronico,
                EngenheiroMetalurgista,
                EngenheiroNaval,
                EngenheiroProjetistaDeTelecomunicacoes,
                EngenheiroQuimico,
                EngenheiroQuimicoIndustriaQuimica,
                EngenheiroQuimicoMineracaoMetalurgiaSiderurgiaCimenteiraECeramica,
                EngenheiroQuimicoPapelECelulose,
                EngenheiroQuimicoPetroleoEBorracha,
                EngenheiroQuimicoUtilidadesEMeioAmbiente,
                EngenheirosDeSistemasOperacionaisEmComputacao,
                Engraxate,
                Enologo,
                EnsaiadorDeDanca,
                EntalhadorDeMadeira,
                EntregadorDePublicacoes,
                EntrevistadorCensitarioEDePesquisasAmostrais,
                EntrevistadorDePesquisaDeOpiniaoEMidia,
                EntrevistadorDePesquisasDeMercado,
                EntrevistadorDePrecos,
                EntrevistadorSocial,
                EnxugadorDeCouros,
                Equilibrista,
                Equoterapeuta,
                Escarfador,
                EscolhedorDePapel,
                EscoradorDeMinas,
                Escrevente,
                EscritorDeFiccao,
                EscritorDeNaoFiccao,
                EscriturarioEmEstatistica,
                EscriturarioDeBanco,
                EscrivaoDePolicia,
                EscrivaoExtraJudicial,
                EscrivaoJudicial,
                Esoterico,
                EspecialistaDePoliticasPublicasEGestaoGovernamentalEppgg,
                EspecialistaEmCalibracoesMetrologicas,
                EspecialistaEmDesenvolvimentoDeCigarros,
                EspecialistaEmEnsaiosMetrologicos,
                EspecialistaEmInstrumentacaoMetrologica,
                EspecialistaEmMateriaisDeReferenciaMetrologica,
                EspecialistaEmPesquisaOperacional,
                EstampadorDeTecido,
                Estatistico,
                EstatisticoEstatisticaAplicada,
                EstatisticoTeorico,
                Esteireiro,
                Estenotipista,
                EsterilizadorDeAlimentos,
                Esteticista,
                EsteticistaDeAnimaisDomesticos,
                EstiradorDeCourosEPelesAcabamento,
                EstiradorDeCourosEPelesPreparacao,
                EstiradorDeTubosDeMetalSemCostura,
                Estivador,
                EstofadorDeAvioes,
                EstofadorDeMoveis,
                Estoquista,
                ExaminadorDeCabosLinhasEletricasETelefonicas,
                ExpedidorDeMercadorias,
                ExtrusorDeFiosOuFibrasDeVidro,
                Farmaceutico,
                FarmaceuticoAnalistaClinico,
                FarmaceuticoDeAlimentos,
                FarmaceuticoEmSaudePublica,
                FarmaceuticoHospitalarEClinico,
                FarmaceuticoIndustrial,
                FarmaceuticoPraticasIntegrativasEComplementares,
                FarmaceuticoToxicologista,
                Faxineiro,
                Feirante,
                Fermentador,
                FerradorDeAnimais,
                Ferramenteiro,
                FerramenteiroDeMandrisCalibradoresEOutrosDispositivos,
                Filologo,
                Filosofo,
                FiltradorDeCerveja,
                FinalizadorDeFilmes,
                FinalizadorDeVideo,
                FiscalDeAtividadesUrbanas,
                FiscalDeAviacaoCivilFac,
                FiscalDeLoja,
                FiscalDePatioDeUsinaDeConcreto,
                FiscalDePistaDeAeroporto,
                FiscalDeTransportesColetivosExcetoTrem,
                FiscalDeTributosEstadual,
                FiscalDeTributosMunicipal,
                Fisico,
                FisicoAcustica,
                FisicoAtomicaEMolecular,
                FisicoCosmologia,
                FisicoEstatisticaEMatematica,
                FisicoFluidos,
                FisicoInstrumentacao,
                FisicoMateriaCondensada,
                FisicoMateriais,
                FisicoMedicina,
                FisicoNuclearEReatores,
                FisicoOptica,
                FisicoParticulasECampos,
                FisicoPlasma,
                FisicoTermica,
                FisioterapeutaDoTrabalho,
                FisioterapeutaAcupunturista,
                FisioterapeutaEsportivo,
                FisioterapeutaGeral,
                FisioterapeutaNeurofuncional,
                FisioterapeutaOsteopata,
                FisioterapeutaQuiropraxista,
                FisioterapeutaRespiratoria,
                FisioterapeutaTraumatoOrtopedicaFuncional,
                Fitotecario,
                FoguistaLocomotivasAVapor,
                FolheadorDeMoveisDeMadeira,
                FonoaudiologoEducacional,
                FonoaudiologoEmAudiologia,
                FonoaudiologoEmDisfagia,
                FonoaudiologoEmLinguagem,
                FonoaudiologoEmMotricidadeOrofacial,
                FonoaudiologoEmSaudeColetiva,
                FonoaudiologoEmVoz,
                FonoaudiologoGeral,
                Forjador,
                ForjadorAMartelo,
                ForjadorPrensista,
                ForneiroMateriaisDeConstrucao,
                ForneiroDeCubilo,
                ForneiroDeFornoPoco,
                ForneiroDeFundicaoFornoDeReducao,
                ForneiroDeReaquecimentoETratamentoTermicoNaMetalurgia,
                ForneiroDeReverbero,
                ForneiroEOperadorAltoForno,
                ForneiroEOperadorConversorAOxigenio,
                ForneiroEOperadorFornoEletrico,
                ForneiroEOperadorRefinoDeMetaisNaoFerrosos,
                ForneiroEOperadorDeFornoDeReducaoDireta,
                ForneiroNaFundicaoDeVidro,
                ForneiroNoRecozimentoDeVidro,
                Fosfatizador,
                Fotografo,
                FotografoPublicitario,
                FotografoRetratista,
                Frentista,
                Fuloneiro,
                FuloneiroNoAcabamentoDeCourosEPeles,
                FundidorJoalheriaEOurivesaria,
                FundidorDeMetais,
                FunileiroDeVeiculosReparacao,
                FunileiroIndustrial,
                Galvanizador,
                Gandula,
                Garagista,
                Garcom,
                GarcomServicosDeVinhos,
                Garimpeiro,
                GeladorIndustrial,
                GeladorProfissional,
                Geneticista,
                Geofisico,
                GeofisicoEspacial,
                Geografo,
                Geologo,
                GeologoDeEngenharia,
                Geoquimico,
                GerenteAdministrativo,
                GerenteComercial,
                GerenteDeAdministracaoEmAeroportos,
                GerenteDeAgencia,
                GerenteDeAlmoxarifado,
                GerenteDeBar,
                GerenteDeCambioEComercioExterior,
                GerenteDeCaptacaoFundosEInvestimentosInstitucionais,
                GerenteDeClientesEspeciaisPrivate,
                GerenteDeCompras,
                GerenteDeComunicacao,
                GerenteDeContasPessoaFisicaEJuridica,
                GerenteDeCreditoECobranca,
                GerenteDeCreditoImobiliario,
                GerenteDeCreditoRural,
                GerenteDeDepartamentoPessoal,
                GerenteDeDesenvolvimentoDeSistemas,
                GerenteDeEmpresaAereaEEmpresaDeServicosAuxiliaresAoTransporteAereoEsataEmAeroportos,
                GerenteDeGrandesContasCorporate,
                GerenteDeHotel,
                GerenteDeInfraestruturaDeTecnologiaDaInformacao,
                GerenteDeInstituicaoEducacionalDaAreaPrivada,
                GerenteDeLogisticaArmazenagemEDistribuicao,
                GerenteDeLojaESupermercado,
                GerenteDeMarketing,
                GerenteDeOperacaoDeTecnologiaDaInformacao,
                GerenteDeOperacoesDeCargas,
                GerenteDeOperacoesDeCorreiosETelecomunicacoes,
                GerenteDeOperacoesDeServicosDeAssistenciaTecnica,
                GerenteDeOperacoesDeTransportes,
                GerenteDeOperacoesEmAeroportos,
                GerenteDePensao,
                GerenteDePesquisaEDesenvolvimentoPD,
                GerenteDeProducaoEOperacoes,
                GerenteDeProducaoEOperacoesAquicolas,
                GerenteDeProducaoEOperacoesFlorestais,
                GerenteDeProducaoEOperacoesAgropecuarias,
                GerenteDeProducaoEOperacoesDaConstrucaoCivilEObrasPublicas,
                GerenteDeProducaoEOperacoesPesqueiras,
                GerenteDeProdutosBancarios,
                GerenteDeProjetosDeTecnologiaDaInformacao,
                GerenteDeProjetosEServicosDeManutencao,
                GerenteDeRecuperacaoDeCredito,
                GerenteDeRecursosHumanos,
                GerenteDeRestaurante,
                GerenteDeRiscos,
                GerenteDeSegurancaDaAviacaoCivil,
                GerenteDeSegurancaDaInformacao,
                GerenteDeSegurancaOperacionalAviacaoCivil,
                GerenteDeServicosCulturais,
                GerenteDeServicosDeSaude,
                GerenteDeServicosEducacionaisDaAreaPublica,
                GerenteDeServicosSociais,
                GerenteDeSuporteTecnicoDeTecnologiaDaInformacao,
                GerenteDeSuprimentos,
                GerenteDeTurismo,
                GerenteDeVendas,
                GerenteFinanceiro,
                Gerontologo,
                Gesseiro,
                GestorEmSeguranca,
                GovernadorDeEstado,
                GovernadorDoDistritoFederal,
                GovernantaDeHotelaria,
                GravadorJoalheriaEOurivesaria,
                GravadorDeInscricoesEmPedra,
                GravadorDeMatrizCalcografica,
                GravadorDeMatrizParaFlexografiaClicherista,
                GravadorDeMatrizParaRotogravuraEletromecanicoEQuimico,
                GravadorDeMatrizSerigrafica,
                GravadorDeRelevosEmPedra,
                GravadorDeVidroAAguaForte,
                GravadorDeVidroAEsmeril,
                GravadorDeVidroAJatoDeAreia,
                GravadorAMaoEncadernacao,
                GuardaPortuario,
                GuardaCivilMunicipal,
                GuardadorDeVeiculos,
                GuardaRoupeiroDeCinema,
                GuiaDeTurismo,
                GuiaFlorestal,
                GuincheiroConstrucaoCivil,
                HidrogenadorDeOleosEGorduras,
                Hidrogeologo,
                HigienistaOcupacional,
                IdentificadorFlorestal,
                IluminadorTelevisao,
                ImediatoDaMarinhaMercante,
                ImpregnadorDeMadeira,
                ImpressorSerigrafia,
                ImpressorCalcografico,
                ImpressorDeCorteEVinco,
                ImpressorDeOfsetePlanoERotativo,
                ImpressorDeRotativa,
                ImpressorDeRotogravura,
                ImpressorDigital,
                ImpressorFlexografico,
                ImpressorLetterset,
                ImpressorTampografico,
                ImpressorTipografico,
                InfluenciadorDigital,
                Inseminador,
                InspetorDeAlunosDeEscolaPrivada,
                InspetorDeAlunosDeEscolaPublica,
                InspetorDeAviacaoCivil,
                InspetorDeControleDimensional,
                InspetorDeDutos,
                InspetorDeEnsaiosNaoDestrutivos,
                InspetorDeEquipamentos,
                InspetorDeEstampariaProducaoTextil,
                InspetorDeFabricacao,
                InspetorDeManutencao,
                InspetorDePintura,
                InspetorDeQualidade,
                InspetorDeRisco,
                InspetorDeServicosDeTransportesRodoviariosPassageirosECargas,
                InspetorDeSinistros,
                InspetorDeSoldagem,
                InspetorDeTerminal,
                InspetorDeTerraplenagem,
                InspetorDeViaPermanenteTrilhos,
                InspetorNaval,
                InstaladorDeCortinasEPersianasPortasSanfonadasEBoxe,
                InstaladorDeIsolantesAcusticos,
                InstaladorDeIsolantesTermicosRefrigeracaoEClimatizacao,
                InstaladorDeIsolantesTermicosDeCaldeiraETubulacoes,
                InstaladorDeLinhasEletricasDeAltaEBaixaTensaoRedeAereaESubterranea,
                InstaladorDeMaterialIsolanteAMaoEdificacoes,
                InstaladorDeMaterialIsolanteAMaquinaEdificacoes,
                InstaladorDeSistemasEletroeletronicosDeSeguranca,
                InstaladorDeSistemasFotovoltaicos,
                InstaladorDeSomEAcessoriosDeVeiculos,
                InstaladorDeTubulacoes,
                InstaladorDeTubulacoesAeronaves,
                InstaladorDeTubulacoesEmbarcacoes,
                InstaladorDeTubulacoesDeGasCombustivelProducaoEDistribuicao,
                InstaladorDeTubulacoesDeVaporProducaoEDistribuicao,
                InstaladorEletricistaTracaoDeVeiculos,
                InstaladorReparadorDeEquipamentosDeComutacaoEmTelefonia,
                InstaladorReparadorDeEquipamentosDeEnergiaEmTelefonia,
                InstaladorReparadorDeEquipamentosDeTransmissaoEmTelefonia,
                InstaladorReparadorDeLinhasEAparelhosDeTelecomunicacoes,
                InstaladorReparadorDeRedesECabosTelefonicos,
                InstaladorReparadorDeRedesTelefonicasEDeComunicacaoDeDados,
                InstrumentadorCirurgico,
                InstrutorDeAprendizagemETreinamentoAgropecuario,
                InstrutorDeAprendizagemETreinamentoComercial,
                InstrutorDeAprendizagemETreinamentoIndustrial,
                InstrutorDeAutoEscola,
                InstrutorDeCursosLivres,
                InstrutorDeVoo,
                Interprete,
                InterpreteDeLinguaDeSinais,
                InvestigadorDePolicia,
                Jardineiro,
                Joalheiro,
                JoalheiroReparacoes,
                Joquei,
                JornaleiroEmBancaDeJornal,
                Jornalista,
                JuizAuditorEstadualJusticaMilitar,
                JuizAuditorFederalJusticaMilitar,
                JuizDeDireito,
                JuizDoTrabalho,
                JuizFederal,
                Kardexista,
                LaboratoristaFotografico,
                Lagareiro,
                LaminadorDeMetaisPreciososAMao,
                LaminadorDePlastico,
                LapidadorJoias,
                LapidadorDeVidrosECristais,
                LavadeiroEmGeral,
                LavadorDeArtefatosDeTapecaria,
                LavadorDeGarrafasVidrosEOutrosUtensilios,
                LavadorDeLa,
                LavadorDePecas,
                LavadorDeRoupas,
                LavadorDeRoupasAMaquina,
                LavadorDeVeiculos,
                Leiloeiro,
                Leiturista,
                LiderDeComunidadeCaicara,
                LiderDeRampaTransporteAereo,
                LigadorDeLinhasTelefonicas,
                LimpadorASecoAMaquina,
                LimpadorDeFachadas,
                LimpadorDePiscinas,
                LimpadorDeRoupasASecoAMao,
                LimpadorDeVidros,
                Lingotador,
                Linguista,
                Linotipista,
                LixadorDeCourosEPeles,
                LocalizadorCobrador,
                LocutorDeMidiasAudiovisuais,
                LubrificadorDeEmbarcacoes,
                LubrificadorDeVeiculosAutomotoresExcetoEmbarcacoes,
                LubrificadorIndustrial,
                Ludomotricista,
                LustradorDePecasDeMadeira,
                LustradorDePiso,
                LuthierRestauracaoDeCordasArcadas,
                MacheiroAMaquina,
                MacheiroAMao,
                MaeSocial,
                Magarefe,
                Magico,
                Maitre,
                MajorBombeiroMilitar,
                MajorDaPoliciaMilitar,
                Malabarista,
                MalteiroGerminacao,
                Manicure,
                Manobrador,
                ManteigueiroNaFabricacaoDeLaticinio,
                MantenedorDeEquipamentosDeParquesDeDiversoesESimilares,
                MantenedorDeSistemasEletroeletronicosDeSeguranca,
                MaquetistaNaMarcenaria,
                Maquiador,
                MaquiadorDeCaracterizacao,
                MaquinistaDeCinemaEVideo,
                MaquinistaDeEmbarcacoes,
                MaquinistaDeTeatroEEspetaculos,
                MaquinistaDeTrem,
                MaquinistaDeTremMetropolitano,
                MarcadorDePecasConfeccionadasParaBordar,
                MarcadorDeProdutosSiderurgicoEMetalurgico,
                Marceneiro,
                Marcheteiro,
                MarinheiroAuxiliarDeConvesMaritimoEAquaviario,
                MarinheiroAuxiliarDeMaquinasMaritimoEAquaviario,
                MarinheiroDeConvesMaritimoEFluviario,
                MarinheiroDeEsporteERecreio,
                MarinheiroDeMaquinas,
                MarmoristaConstrucao,
                MasseiroMassasAlimenticias,
                Massoterapeuta,
                Matematico,
                MatematicoAplicado,
                MatizadorDeCourosEPeles,
                MecanicoDeManutencaoDeAeronavesEmGeral,
                MecanicoDeManutencaoDeAparelhosDeLevantamento,
                MecanicoDeManutencaoDeAparelhosEsportivosEDeGinastica,
                MecanicoDeManutencaoDeAutomoveisMotocicletasEVeiculosSimilares,
                MecanicoDeManutencaoDeBicicletasEVeiculosSimilares,
                MecanicoDeManutencaoDeBombaInjetoraExcetoDeVeiculosAutomotores,
                MecanicoDeManutencaoDeBombas,
                MecanicoDeManutencaoDeCompressoresDeAr,
                MecanicoDeManutencaoDeEmpilhadeirasEOutrosVeiculosDeCargasLeves,
                MecanicoDeManutencaoDeEquipamentoDeMineracao,
                MecanicoDeManutencaoDeInstalacoesMecanicasDeEdificios,
                MecanicoDeManutencaoDeMaquinasAgricolas,
                MecanicoDeManutencaoDeMaquinasCortadorasDeGramaRocadeirasMotosserrasESimilares,
                MecanicoDeManutencaoDeMaquinasDeConstrucaoETerraplenagem,
                MecanicoDeManutencaoDeMaquinasGraficas,
                MecanicoDeManutencaoDeMaquinasOperatrizesLavraDeMadeira,
                MecanicoDeManutencaoDeMaquinasTexteis,
                MecanicoDeManutencaoDeMaquinasEmGeral,
                MecanicoDeManutencaoDeMaquinasFerramentasUsinagemDeMetais,
                MecanicoDeManutencaoDeMotocicletas,
                MecanicoDeManutencaoDeMotoresDieselExcetoDeVeiculosAutomotores,
                MecanicoDeManutencaoDeMotoresEEquipamentosNavais,
                MecanicoDeManutencaoDeRedutores,
                MecanicoDeManutencaoDeSistemaHidraulicoDeAeronavesServicosDePistaEHangar,
                MecanicoDeManutencaoDeTratores,
                MecanicoDeManutencaoDeTurbinasExcetoDeAeronaves,
                MecanicoDeManutencaoDeTurbocompressores,
                MecanicoDeManutencaoDeVeiculosFerroviarios,
                MecanicoDeManutencaoEInstalacaoDeAparelhosDeClimatizacaoERefrigeracao,
                MecanicoDeRefrigeracao,
                MecanicoDeVeiculosAutomotoresADieselExcetoTratores,
                MecanicoDeVoo,
                MecanicoMontadorDeMotoresDeAeronaves,
                MecanicoMontadorDeMotoresDeEmbarcacoes,
                MecanicoMontadorDeMotoresDeExplosaoEDiesel,
                MecanicoMontadorDeTurboalimentadores,
                MediadorExtrajudicial,
                MedicoAcupunturista,
                MedicoAlergistaEImunologista,
                MedicoAnatomopatologista,
                MedicoAnestesiologista,
                MedicoAngiologista,
                MedicoAntroposofico,
                MedicoCancerologistaCirurgico,
                MedicoCancerologistaPediatrico,
                MedicoCardiologista,
                MedicoCirurgiaoCardiovascular,
                MedicoCirurgiaoDaMao,
                MedicoCirurgiaoDeCabecaEPescoco,
                MedicoCirurgiaoDoAparelhoDigestivo,
                MedicoCirurgiaoGeral,
                MedicoCirurgiaoPediatrico,
                MedicoCirurgiaoPlastico,
                MedicoCirurgiaoToracico,
                MedicoCitopatologista,
                MedicoClinico,
                MedicoColoproctologista,
                MedicoDaEstrategiaDeSaudeDaFamilia,
                MedicoDeFamiliaEComunidade,
                MedicoDermatologista,
                MedicoDoTrabalho,
                MedicoEmCirurgiaVascular,
                MedicoEmEndoscopia,
                MedicoEmMedicinaDeTrafego,
                MedicoEmMedicinaIntensiva,
                MedicoEmMedicinaNuclear,
                MedicoEmRadiologiaEDiagnosticoPorImagem,
                MedicoEndocrinologistaEMetabologista,
                MedicoFisiatra,
                MedicoGastroenterologista,
                MedicoGeneralista,
                MedicoGeneticista,
                MedicoGeriatra,
                MedicoGinecologistaEObstetra,
                MedicoHematologista,
                MedicoHemoterapeuta,
                MedicoHiperbarista,
                MedicoHomeopata,
                MedicoInfectologista,
                MedicoLegista,
                MedicoMastologista,
                MedicoNefrologista,
                MedicoNeurocirurgiao,
                MedicoNeurofisiologistaClinico,
                MedicoNeurologista,
                MedicoNutrologista,
                MedicoOftalmologista,
                MedicoOncologistaClinico,
                MedicoOrtopedistaETraumatologista,
                MedicoOtorrinolaringologista,
                MedicoPatologista,
                MedicoPatologistaClinicoMedicinaLaboratorial,
                MedicoPediatra,
                MedicoPneumologista,
                MedicoPsiquiatra,
                MedicoRadiologistaIntervencionista,
                MedicoRadioterapeuta,
                MedicoReumatologista,
                MedicoSanitarista,
                MedicoUrologista,
                MedicoVeterinario,
                MembroDeLiderancaQuilombola,
                MembroSuperiorDoPoderExecutivo,
                MergulhadorProfissionalRasoEProfundo,
                MestreAfiadorDeFerramentas,
                MestreConstrucaoCivil,
                MestreConstrucaoNaval,
                MestreIndustriaDeAutomotoresEMaterialDeTransportes,
                MestreIndustriaDeBorrachaEPlastico,
                MestreIndustriaDeCelulosePapelEPapelao,
                MestreIndustriaDeMadeiraEMobiliario,
                MestreIndustriaDeMaquinasEOutrosEquipamentosMecanicos,
                MestreIndustriaPetroquimicaECarboquimica,
                MestreIndustriaTextilEDeConfeccoes,
                MestreCarpinteiro,
                MestreDeAciaria,
                MestreDeAltoForno,
                MestreDeCabotagem,
                MestreDeCaldeiraria,
                MestreDeCerimonias,
                MestreDeConstrucaoDeFornos,
                MestreDeFerramentaria,
                MestreDeForjaria,
                MestreDeFornoEletrico,
                MestreDeFundicao,
                MestreDeGalvanoplastia,
                MestreDeLaminacao,
                MestreDeLinhasFerrovias,
                MestreDePinturaTratamentoDeSuperficies,
                MestreDeProducaoFarmaceutica,
                MestreDeProducaoQuimica,
                MestreDeSiderurgia,
                MestreDeSoldagem,
                MestreDeTrefilacaoDeMetais,
                MestreDeUsinagem,
                MestreFluvial,
                MestreSerralheiro,
                MetalizadorBanhoQuente,
                MetalizadorAPistola,
                Meteorologista,
                Metrologista,
                Microfonista,
                Mineiro,
                Minhocultor,
                MinistroDeCultoReligioso,
                MinistroDeEstado,
                MinistroDoSuperiorTribunalDoTrabalho,
                MinistroDoSuperiorTribunalMilitar,
                MinistroDoSuperiorTribunalDeJustica,
                MinistroDoSupremoTribunalFederal,
                Missionario,
                MisturadorDeCafe,
                MisturadorDeChaOuMate,
                MocoDeConvesMaritimoEFluviario,
                MocoDeMaquinasMaritimoEFluviario,
                ModeladorDeMadeira,
                ModeladorDeMetaisFundicao,
                ModelistaDeCalcados,
                ModelistaDeRoupas,
                ModeloArtistico,
                ModeloDeModas,
                ModeloPublicitario,
                MoedorDeCafe,
                MoedorDeSal,
                MoldadorVidros,
                MoldadorDeAbrasivosNaFabricacaoDeCeramicaVidroEPorcelana,
                MoldadorDeBorrachaPorCompressao,
                MoldadorDeCorposDeProvaEmUsinasDeConcreto,
                MoldadorDePlasticoPorCompressao,
                MoldadorDePlasticoPorInjecao,
                MoldadorAMao,
                MoldadorAMaquina,
                MoleiroTratamentosQuimicosEAfins,
                MoleiroDeCereaisExcetoArroz,
                MoleiroDeEspeciarias,
                MoleiroDeMinerios,
                MonitorDeDependenteQuimico,
                MonitorDeRessocializacaoPrisional,
                MonitorDeSistemasEletronicosDeSegurancaExterno,
                MonitorDeSistemasEletronicosDeSegurancaInterno,
                MonitorDeTeleatendimento,
                MonitorDeTransporteEscolar,
                Monotipista,
                MontadorDeAndaimesEdificacoes,
                MontadorDeArtefatosDeCouroExcetoRoupasECalcados,
                MontadorDeBicicletas,
                MontadorDeCalcados,
                MontadorDeEquipamentoDeLevantamento,
                MontadorDeEquipamentosEletricos,
                MontadorDeEquipamentosEletricosAparelhosEletrodomesticos,
                MontadorDeEquipamentosEletricosCentraisEletricas,
                MontadorDeEquipamentosEletricosElevadoresEEquipamentosSimilares,
                MontadorDeEquipamentosEletricosInstrumentosDeMedicao,
                MontadorDeEquipamentosEletricosMotoresEDinamos,
                MontadorDeEquipamentosEletricosTransformadores,
                MontadorDeEquipamentosEletronicos,
                MontadorDeEquipamentosEletronicosAparelhosMedicos,
                MontadorDeEquipamentosEletronicosComputadoresEEquipamentosAuxiliares,
                MontadorDeEquipamentosEletronicosEstacaoDeRadioTvEEquipamentosDeRadar,
                MontadorDeEquipamentosEletronicosInstalacoesDeSinalizacao,
                MontadorDeEquipamentosEletronicosMaquinasIndustriais,
                MontadorDeEstruturasDeAeronaves,
                MontadorDeEstruturasMetalicas,
                MontadorDeEstruturasMetalicasDeEmbarcacoes,
                MontadorDeFilmes,
                MontadorDeFotolitoAnalogicoEDigital,
                MontadorDeInstrumentosDeOptica,
                MontadorDeInstrumentosDePrecisao,
                MontadorDeMaquinas,
                MontadorDeMaquinasAgricolas,
                MontadorDeMaquinasDeMinasEPedreiras,
                MontadorDeMaquinasDeTerraplenagem,
                MontadorDeMaquinasGraficas,
                MontadorDeMaquinasOperatrizesParaMadeira,
                MontadorDeMaquinasTexteis,
                MontadorDeMaquinasMotoresEAcessoriosMontagemEmSerie,
                MontadorDeMaquinasFerramentasUsinagemDeMetais,
                MontadorDeMoveisEArtefatosDeMadeira,
                MontadorDeSistemasDeCombustivelDeAeronaves,
                MontadorDeVeiculosLinhaDeMontagem,
                MontadorDeVeiculosReparacao,
                MordomoDeHotelaria,
                MordomoDeResidencia,
                Mosaista,
                Motofretista,
                MotoristaDeCaminhaoRotasRegionaisEInternacionais,
                MotoristaDeCarroDePasseio,
                MotoristaDeFurgaoOuVeiculoSimilar,
                MotoristaDeOnibusRodoviario,
                MotoristaDeOnibusUrbano,
                MotoristaDeTaxi,
                MotoristaDeTrolebus,
                MotoristaOperacionalDeGuincho,
                Motorneiro,
                Mototaxista,
                Museologo,
                MusicoArranjador,
                MusicoInterpreteCantor,
                MusicoInterpreteInstrumentista,
                MusicoRegente,
                Musicologo,
                Musicoterapeuta,
                Naturologo,
                Neuropsicologo,
                NeuropsicopedagogoClinico,
                NeuropsicopedagogoInstitucional,
                NormalizadorDeMetaisEDeCompositos,
                Numerologo,
                Nutricionista,
                Oceanografo,
                OficialDaAeronautica,
                OficialDaMarinha,
                OficialDeInteligencia,
                OficialDeJustica,
                OficialDeQuartoDeNavegacaoDaMarinhaMercante,
                OficialDeRegistroDeContratosMaritimos,
                OficialDoExercito,
                OficialDoRegistroCivilDePessoasJuridicas,
                OficialDoRegistroCivilDePessoasNaturais,
                OficialDoRegistroDeDistribuicoes,
                OficialDoRegistroDeImoveis,
                OficialDoRegistroDeTitulosEDocumentos,
                OficialGeneralDaAeronautica,
                OficialGeneralDaMarinha,
                OficialGeneralDoExercito,
                OficialSuperiorDeMaquinasDaMarinhaMercante,
                OficialTecnicoDeInteligencia,
                OleiroFabricacaoDeTelhas,
                OleiroFabricacaoDeTijolos,
                OperadorDeAbastecimentoDeCombustivelDeAeronave,
                OperadorDeAberturaFiacao,
                OperadorDeAcabamentoIndustriaGrafica,
                OperadorDeAcabamentoDePecasFundidas,
                OperadorDeAciariaBasculamentoDeConvertedor,
                OperadorDeAciariaDessulfuracaoDeGusa,
                OperadorDeAciariaRecebimentoDeGusa,
                OperadorDeAeronavesNaoTripuladas,
                OperadorDeAlambiqueDeFuncionamentoContinuoProdutosQuimicosExcetoPetroleo,
                OperadorDeAparelhoDeFlotacao,
                OperadorDeAparelhoDePrecipitacaoMinasDeOuroOuPrata,
                OperadorDeAparelhoDeReacaoEConversaoProdutosQuimicosExcetoPetroleo,
                OperadorDeAreaDeCorrida,
                OperadorDeAtendimentoAeroviario,
                OperadorDeAtomizador,
                OperadorDeBanhoMetalicoDeVidroPorFlutuacao,
                OperadorDeBateEstacas,
                OperadorDeBateriaDeGasDeHulha,
                OperadorDeBetoneira,
                OperadorDeBinadeira,
                OperadorDeBobinadeira,
                OperadorDeBobinadeiraDeTirasAQuenteNoAcabamentoDeChapasEMetais,
                OperadorDeBombaDeConcreto,
                OperadorDeBranqueadorDePastaParaFabricacaoDePapel,
                OperadorDeBritadeiraTratamentosQuimicosEAfins,
                OperadorDeBritadorDeCoque,
                OperadorDeBritadorDeMandibulas,
                OperadorDeCabineDeLaminacaoFioMaquina,
                OperadorDeCaixa,
                OperadorDeCalandraQuimicaPetroquimicaEAfins,
                OperadorDeCalandrasTecidos,
                OperadorDeCalcinacaoTratamentoQuimicoEAfins,
                OperadorDeCaldeira,
                OperadorDeCamarasFrias,
                OperadorDeCameraDeTelevisao,
                OperadorDeCaminhaoMinasEPedreiras,
                OperadorDeCardas,
                OperadorDeCarregadeira,
                OperadorDeCarroDeApagamentoECoque,
                OperadorDeCeifadeiraNaConservacaoDeViasPermanentes,
                OperadorDeCentralDeConcreto,
                OperadorDeCentralHidreletrica,
                OperadorDeCentralTermoeletrica,
                OperadorDeCentrifugadoraTratamentosQuimicosEAfins,
                OperadorDeCentroDeControle,
                OperadorDeCentroDeControleFerroviaEMetro,
                OperadorDeCentroDeUsinagemComComandoNumerico,
                OperadorDeCentroDeUsinagemDeMadeiraCnc,
                OperadorDeChamuscadeiraDeTecidos,
                OperadorDeCobrancaBancaria,
                OperadorDeColhedorFlorestal,
                OperadorDeColheitadeira,
                OperadorDeCompactadoraDeSolos,
                OperadorDeCompressorDeAr,
                OperadorDeComputador,
                OperadorDeConcentracao,
                OperadorDeConicaleira,
                OperadorDeControleMestre,
                OperadorDeCortadeiraDePapel,
                OperadorDeCristalizacaoNaRefinacaoDeAcucar,
                OperadorDeDesempenadeiraNaUsinagemConvencionalDeMadeira,
                OperadorDeDesgaseificacao,
                OperadorDeDestilacaoESubprodutosDeCoque,
                OperadorDeDigestorDePastaParaFabricacaoDePapel,
                OperadorDeDocagem,
                OperadorDeDraga,
                OperadorDeEmpilhadeira,
                OperadorDeEnfornamentoEDesenfornamentoDeCoque,
                OperadorDeEngomadeiraDeUrdume,
                OperadorDeEntalhadeiraUsinagemDeMadeira,
                OperadorDeEquipamentoDeDestilacaoDeAlcool,
                OperadorDeEquipamentoDeSecagemDePintura,
                OperadorDeEquipamentoParaResfriamento,
                OperadorDeEquipamentosDePreparacaoDeAreia,
                OperadorDeEquipamentosDeRefinacaoDeAcucarProcessoContinuo,
                OperadorDeEscavadeira,
                OperadorDeEscoriaESucata,
                OperadorDeEsmaltadeira,
                OperadorDeEspelhamento,
                OperadorDeEspessador,
                OperadorDeEspuladeira,
                OperadorDeEstacaoDeBombeamento,
                OperadorDeEstacaoDeCaptacaoTratamentoEDistribuicaoDeAgua,
                OperadorDeEstacaoDeTratamentoDeAguaEEfluentes,
                OperadorDeEvaporadorNaDestilacao,
                OperadorDeExaustorCoqueria,
                OperadorDeExploracaoDePetroleo,
                OperadorDeExtracaoDeCafeSoluvel,
                OperadorDeExtrusoraQuimicaPetroquimicaEAfins,
                OperadorDeFilatorio,
                OperadorDeFiltroDeSecagemMineracao,
                OperadorDeFiltroDeTamborRotativoTratamentosQuimicosEAfins,
                OperadorDeFiltroEsteiraMineracao,
                OperadorDeFiltroPrensaTratamentosQuimicosEAfins,
                OperadorDeFiltrosDeParafinaTratamentosQuimicosEAfins,
                OperadorDeFornoFabricacaoDePaesBiscoitosESimilares,
                OperadorDeFornoServicosFunerarios,
                OperadorDeFornoDeIncineracaoNoTratamentoDeAguaEfluentesEResiduosIndustriais,
                OperadorDeFornoDeTratamentoTermicoDeMetais,
                OperadorDeFresadoraUsinagemDeMadeira,
                OperadorDeFresadoraComComandoNumerico,
                OperadorDeGuilhotinaCorteDePapel,
                OperadorDeGuindasteFixo,
                OperadorDeGuindasteMovel,
                OperadorDeImpermeabilizadorDeTecidos,
                OperadorDeIncubadora,
                OperadorDeInspecaoDeQualidade,
                OperadorDeInstalacaoDeArCondicionado,
                OperadorDeInstalacaoDeExtracaoProcessamentoEnvasamentoEDistribuicaoDeGases,
                OperadorDeInstalacaoDeRefrigeracao,
                OperadorDeJatoAbrasivo,
                OperadorDeJigMinas,
                OperadorDeLacosDeCabosDeAco,
                OperadorDeLaminadeiraEReunideira,
                OperadorDeLaminador,
                OperadorDeLaminadorDeBarrasAFrio,
                OperadorDeLaminadorDeBarrasAQuente,
                OperadorDeLaminadorDeMetaisNaoFerrosos,
                OperadorDeLaminadorDeTubos,
                OperadorDeLavagemEDepuracaoDePastaParaFabricacaoDePapel,
                OperadorDeLinhaDeMontagemAparelhosEletricos,
                OperadorDeLinhaDeMontagemAparelhosEletronicos,
                OperadorDeLixadeiraUsinagemDeMadeira,
                OperadorDeMacaroqueira,
                OperadorDeMandriladoraComComandoNumerico,
                OperadorDeMaquinaFabricacaoDeCigarros,
                OperadorDeMaquinaBordatriz,
                OperadorDeMaquinaCopiadoraExcetoOperadorDeGraficaRapida,
                OperadorDeMaquinaCortadoraMinasEPedreiras,
                OperadorDeMaquinaDeAbrirValas,
                OperadorDeMaquinaDeCilindrarChapas,
                OperadorDeMaquinaDeCordoalha,
                OperadorDeMaquinaDeCortarEDobrarPapelao,
                OperadorDeMaquinaDeCortinaDAguaProducaoDeMoveis,
                OperadorDeMaquinaDeCosturaDeAcabamento,
                OperadorDeMaquinaDeDobrarChapas,
                OperadorDeMaquinaDeEletroerosao,
                OperadorDeMaquinaDeEnvasarLiquidos,
                OperadorDeMaquinaDeEtiquetar,
                OperadorDeMaquinaDeExtracaoContinuaMinasDeCarvao,
                OperadorDeMaquinaDeFabricacaoDeCosmeticos,
                OperadorDeMaquinaDeFabricacaoDeProdutosDeHigieneELimpezaSabaoSaboneteEOutros,
                OperadorDeMaquinaDeFabricarCharutosECigarrilhas,
                OperadorDeMaquinaDeFabricarPapelFaseUmida,
                OperadorDeMaquinaDeFabricarPapelFaseSeca,
                OperadorDeMaquinaDeFabricarPapelEPapelao,
                OperadorDeMaquinaDeFundicao,
                OperadorDeMaquinaDeFundirSobPressao,
                OperadorDeMaquinaDeLavarFiosETecidos,
                OperadorDeMaquinaDeMoldarAutomatizada,
                OperadorDeMaquinaDePreparacaoDeMateriaPrimaParaProducaoDeCigarros,
                OperadorDeMaquinaDeProdutosFarmaceuticos,
                OperadorDeMaquinaDeSecarCelulose,
                OperadorDeMaquinaDeSinterizar,
                OperadorDeMaquinaDeSoprarVidro,
                OperadorDeMaquinaDeUsinagemDeMadeiraProducaoEmSerie,
                OperadorDeMaquinaDeUsinagemMadeiraEmGeral,
                OperadorDeMaquinaEletroerosaoAFioComComandoNumerico,
                OperadorDeMaquinaExtrusoraDeVaretasETubosDeVidro,
                OperadorDeMaquinaIntercaladoraDePlacasCompensados,
                OperadorDeMaquinaMisturadeiraTratamentosQuimicosEAfins,
                OperadorDeMaquinaPerfuradoraMinasEPedreiras,
                OperadorDeMaquinaPerfuratriz,
                OperadorDeMaquinaRecobridoraDeArame,
                OperadorDeMaquinaRodoferroviaria,
                OperadorDeMaquinasDeBeneficiamentoDeProdutosAgricolas,
                OperadorDeMaquinasDeConstrucaoCivilEMineracao,
                OperadorDeMaquinasDeFabricacaoDeChocolatesEAchocolatados,
                OperadorDeMaquinasDeFabricacaoDeDocesSalgadosEMassasAlimenticias,
                OperadorDeMaquinasDeUsinarMadeiraCnc,
                OperadorDeMaquinasDoAcabamentoDeCourosEPeles,
                OperadorDeMaquinasEspeciaisEmConservacaoDeViaPermanenteTrilhos,
                OperadorDeMaquinasFixasEmGeral,
                OperadorDeMaquinasFlorestaisEstaticas,
                OperadorDeMaquinasOperatrizes,
                OperadorDeMaquinasFerramentaConvencionais,
                OperadorDeMartelete,
                OperadorDeMensagensDeTelecomunicacoesCorreios,
                OperadorDeMidiaAudiovisual,
                OperadorDeMoendaNaFabricacaoDeAcucar,
                OperadorDeMolduradoraUsinagemDeMadeira,
                OperadorDeMontaCargasConstrucaoCivil,
                OperadorDeMontagemDeCilindrosEMancais,
                OperadorDeMotoniveladora,
                OperadorDeMotoniveladoraExtracaoDeMineraisSolidos,
                OperadorDeMotosserra,
                OperadorDeNegocios,
                OperadorDeOpenEnd,
                OperadorDePaCarregadeira,
                OperadorDePainelDeControle,
                OperadorDePainelDeControleRefinacaoDePetroleo,
                OperadorDePassadorFiacao,
                OperadorDePavimentadoraAsfaltoConcretoEMateriaisSimilares,
                OperadorDePeneirasHidraulicas,
                OperadorDePenteadeira,
                OperadorDePlainaDesengrossadeira,
                OperadorDePonteRolante,
                OperadorDePorticoRolante,
                OperadorDePrensaDeAltaFrequenciaNaUsinagemDeMadeira,
                OperadorDePrensaDeEmbutirPapelao,
                OperadorDePrensaDeEnfardamento,
                OperadorDePrensaDeMaterialReciclavel,
                OperadorDePrensaDeMoldarVidro,
                OperadorDePreparacaoDeGraosVegetaisOleosEGorduras,
                OperadorDePreservacaoEControleTermico,
                OperadorDeProcessoQuimicaPetroquimicaEAfins,
                OperadorDeProcessoDeMoagem,
                OperadorDeProcessoDeTratamentoDeImagem,
                OperadorDeProcessosQuimicosEPetroquimicos,
                OperadorDeProducaoQuimicaPetroquimicaEAfins,
                OperadorDeProjetorCinematografico,
                OperadorDeQuadroDeDistribuicaoDeEnergiaEletrica,
                OperadorDeRadioChamada,
                OperadorDeRameuse,
                OperadorDeReatorDeCoqueDePetroleo,
                OperadorDeReatorNuclear,
                OperadorDeRebobinadeiraNaFabricacaoDePapelEPapelao,
                OperadorDeRedeDeTeleprocessamento,
                OperadorDeRefrigeracaoCoqueria,
                OperadorDeRefrigeracaoComAmonia,
                OperadorDeRetificadoraComComandoNumerico,
                OperadorDeRetorcedeira,
                OperadorDeSalaDeControleDeInstalacoesQuimicasPetroquimicasEAfins,
                OperadorDeSalinaSalMarinho,
                OperadorDeSchutthecar,
                OperadorDeSerrasUsinagemDeMadeira,
                OperadorDeSerrasNoDesdobramentoDeMadeira,
                OperadorDeSistemaDeReversaoCoqueria,
                OperadorDeSistemasDeProvaAnalogicoEDigital,
                OperadorDeSondaDePercussao,
                OperadorDeSondaRotativa,
                OperadorDeSubestacao,
                OperadorDeTalhaEletrica,
                OperadorDeTelefericoPassageiros,
                OperadorDeTelemarketingAtivo,
                OperadorDeTelemarketingAtivoEReceptivo,
                OperadorDeTelemarketingReceptivo,
                OperadorDeTelemarketingTecnico,
                OperadorDeTesouraMecanicaEMaquinaDeCorteNoAcabamentoDeChapasEMetais,
                OperadorDeTimeDeMontagem,
                OperadorDeTornoAutomaticoUsinagemDeMadeira,
                OperadorDeTornoComComandoNumerico,
                OperadorDeTransferenciaEEstocagemNaRefinacaoDoPetroleo,
                OperadorDeTransporteMultimodal,
                OperadorDeTratamentoDeCaldaNaRefinacaoDeAcucar,
                OperadorDeTratamentoQuimicoDeMateriaisRadioativos,
                OperadorDeTratorMinasEPedreiras,
                OperadorDeTratorDeLamina,
                OperadorDeTratorFlorestal,
                OperadorDeTremDeMetro,
                OperadorDeTriagemETransbordo,
                OperadorDeTupiaUsinagemDeMadeira,
                OperadorDeTurismo,
                OperadorDeUrdideira,
                OperadorDeUsinagemConvencionalPorAbrasao,
                OperadorDeUtilidadeProducaoEDistribuicaoDeVaporGasOleoCombustivelEnergiaOxigenio,
                OperadorDeVazamentoLingotamento,
                OperadorDeVeiculosSubaquaticosControladosRemotamente,
                OperadorDeZincagemProcessoEletrolitico,
                OperadorEletromecanico,
                OperadorPolivalenteDaIndustriaTextil,
                OperadorMantenedorDeProjetorCinematografico,
                OrganizadorDeEvento,
                OrientadorEducacional,
                Ortoptista,
                Osteopata,
                Ourives,
                Ouvidor,
                OxicortadorAMaoEAMaquina,
                Oxidador,
                Padeiro,
                Paginador,
                PalecionadorDeCourosEPeles,
                Paleontologo,
                Palhaco,
                PapiloscopistaPolicial,
                Paranormal,
                ParteiraLeiga,
                PassadeiraDePecasConfeccionadas,
                PassadorDeRoupasEmGeral,
                PassadorDeRoupasAMao,
                PassamaneiroAMaquina,
                Pasteurizador,
                Pastilheiro,
                PatraoDePescaDeAltoMar,
                PatraoDePescaNaNavegacaoInterior,
                Pedagogo,
                Pedicure,
                Pedreiro,
                PedreiroChaminesIndustriais,
                PedreiroMaterialRefratario,
                PedreiroMineracao,
                PedreiroDeConservacaoDeViasPermanentesExcetoTrilhos,
                PedreiroDeEdificacoes,
                Perfumista,
                Perfusionista,
                PeritoContabil,
                PeritoCriminal,
                PescadorArtesanalDeAguaDoce,
                PescadorArtesanalDeLagostas,
                PescadorArtesanalDePeixesECamaroes,
                PescadorIndustrial,
                PescadorProfissional,
                PesquisadorDeClinicaMedica,
                PesquisadorDeEngenhariaCivil,
                PesquisadorDeEngenhariaETecnologiaOutrasAreasDaEngenharia,
                PesquisadorDeEngenhariaEletricaEEletronica,
                PesquisadorDeEngenhariaMecanica,
                PesquisadorDeEngenhariaMetalurgicaDeMinasEDeMateriais,
                PesquisadorDeEngenhariaQuimica,
                PesquisadorDeMedicinaBasica,
                PesquisadorEmBiologiaAmbiental,
                PesquisadorEmBiologiaAnimal,
                PesquisadorEmBiologiaDeMicroorganismosEParasitas,
                PesquisadorEmBiologiaHumana,
                PesquisadorEmBiologiaVegetal,
                PesquisadorEmCienciasAgronomicas,
                PesquisadorEmCienciasDaComputacaoEInformatica,
                PesquisadorEmCienciasDaEducacao,
                PesquisadorEmCienciasDaPescaEAquicultura,
                PesquisadorEmCienciasDaTerraEMeioAmbiente,
                PesquisadorEmCienciasDaZootecnia,
                PesquisadorEmCienciasFlorestais,
                PesquisadorEmCienciasSociaisEHumanas,
                PesquisadorEmEconomia,
                PesquisadorEmFisica,
                PesquisadorEmHistoria,
                PesquisadorEmMatematica,
                PesquisadorEmMedicinaVeterinaria,
                PesquisadorEmMetrologia,
                PesquisadorEmPsicologia,
                PesquisadorEmQuimica,
                PesquisadorEmSaudeColetiva,
                Petrografo,
                PicotadorDeCartoesJacquard,
                PilotoAgricola,
                PilotoComercialExcetoLinhasAereas,
                PilotoComercialDeHelicopteroExcetoLinhasAereas,
                PilotoDeAeronaves,
                PilotoDeCompeticaoAutomobilistica,
                PilotoDeEnsaiosEmVoo,
                PilotoFluvial,
                PintorAPincelERoloExcetoObrasEEstruturasMetalicas,
                PintorDeCeramicaAPincel,
                PintorDeEstruturasMetalicas,
                PintorDeLetreiros,
                PintorDeObras,
                PintorDeVeiculosFabricacao,
                PintorDeVeiculosReparacao,
                PintorPorImersao,
                PintorAPistolaExcetoObrasEEstruturasMetalicas,
                PipoqueiroAmbulante,
                Pirotecnico,
                Pizzaiolo,
                Planejista,
                PlataformistaPetroleo,
                PoceiroEdificacoes,
                Podologo,
                Poeta,
                PolicialLegislativo,
                PolicialRodoviarioFederal,
                PolidorDeMetais,
                PolidorDePedras,
                PorteiroHotel,
                PorteiroDeEdificios,
                PracaDaAeronautica,
                PracaDaMarinha,
                PracaDoExercito,
                PraticoDePortosDaMarinhaMercante,
                Prefeito,
                PrensadorDeCourosEPeles,
                PrensadorDeFrutasExcetoOleaginosas,
                PrensistaOperadorDePrensa,
                PrensistaDeAglomerados,
                PrensistaDeCompensados,
                PreparadorDeAditivos,
                PreparadorDeAglomerantes,
                PreparadorDeAtleta,
                PreparadorDeBarbotina,
                PreparadorDeCalcados,
                PreparadorDeCourosCurtidos,
                PreparadorDeEsmaltesCeramica,
                PreparadorDeEstruturasMetalicas,
                PreparadorDeFumoNaFabricacaoDeCharutos,
                PreparadorDeMaquinasFerramenta,
                PreparadorDeMassaFabricacaoDeAbrasivos,
                PreparadorDeMassaFabricacaoDeVidro,
                PreparadorDeMassaDeArgila,
                PreparadorDeMatrizesDeCorteEVinco,
                PreparadorDeMeladoEEssenciaDeFumo,
                PreparadorDePanelasLingotamento,
                PreparadorDeRacoes,
                PreparadorDeSolasEPalmilhas,
                PreparadorDeSucataEAparas,
                PreparadorDeTintas,
                PreparadorDeTintasFabricaDeTecidos,
                PreparadorFisico,
                PresidenteDaRepublica,
                PrimeiroOficialDeMaquinasDaMarinhaMercante,
                PrimeiroTenenteDePoliciaMilitar,
                ProcessadorDeFumo,
                ProcuradorAutarquico,
                ProcuradorDaAssistenciaJudiciaria,
                ProcuradorDaFazendaNacional,
                ProcuradorDaRepublica,
                ProcuradorDeJustica,
                ProcuradorDeJusticaMilitar,
                ProcuradorDoEstado,
                ProcuradorDoMunicipio,
                ProcuradorDoTrabalho,
                ProcuradorFederal,
                ProcuradorFundacional,
                ProcuradorRegionalDaRepublica,
                ProcuradorRegionalDoTrabalho,
                ProdutorAgricolaPolivalente,
                ProdutorAgropecuarioEmGeral,
                ProdutorCinematografico,
                ProdutorCultural,
                ProdutorDaCulturaDeAmendoim,
                ProdutorDaCulturaDeCanola,
                ProdutorDaCulturaDeCocoDaBaia,
                ProdutorDaCulturaDeDende,
                ProdutorDaCulturaDeGirassol,
                ProdutorDaCulturaDeLinho,
                ProdutorDaCulturaDeMamona,
                ProdutorDaCulturaDeSoja,
                ProdutorDeAlgodao,
                ProdutorDeArroz,
                ProdutorDeArvoresFrutiferas,
                ProdutorDeCacau,
                ProdutorDeCanaDeAcucar,
                ProdutorDeCereaisDeInverno,
                ProdutorDeCuraua,
                ProdutorDeErvaMate,
                ProdutorDeEspeciarias,
                ProdutorDeEspeciesFrutiferasRasteiras,
                ProdutorDeEspeciesFrutiferasTrepadeiras,
                ProdutorDeFloresDeCorte,
                ProdutorDeFloresEmVaso,
                ProdutorDeForracoes,
                ProdutorDeFumo,
                ProdutorDeGramineasForrageiras,
                ProdutorDeGuarana,
                ProdutorDeJuta,
                ProdutorDeMilhoESorgo,
                ProdutorDeModa,
                ProdutorDePlantasAromaticasEMedicinais,
                ProdutorDePlantasOrnamentais,
                ProdutorDeRadio,
                ProdutorDeRami,
                ProdutorDeSisal,
                ProdutorDeTeatro,
                ProdutorDeTelevisao,
                ProdutorDeTexto,
                ProdutorNaOlericulturaDeFrutosESementes,
                ProdutorNaOlericulturaDeLegumes,
                ProdutorNaOlericulturaDeRaizesBulbosETuberculos,
                ProdutorNaOlericulturaDeTalosFolhasEFlores,
                Proeiro,
                ProfessorDaEducacaoDeJovensEAdultosDoEnsinoFundamentalPrimeiraAQuartaSerie,
                ProfessorDaAreaDeMeioAmbiente,
                ProfessorDeAdministracao,
                ProfessorDeAlunosComDeficienciaAuditivaESurdos,
                ProfessorDeAlunosComDeficienciaFisica,
                ProfessorDeAlunosComDeficienciaMental,
                ProfessorDeAlunosComDeficienciaMultipla,
                ProfessorDeAlunosComDeficienciaVisual,
                ProfessorDeAntropologiaDoEnsinoSuperior,
                ProfessorDeArquitetura,
                ProfessorDeArquivologiaDoEnsinoSuperior,
                ProfessorDeArtesDoEspetaculoNoEnsinoSuperior,
                ProfessorDeArtesNoEnsinoMedio,
                ProfessorDeArtesVisuaisNoEnsinoSuperiorArtesPlasticasEMultimidia,
                ProfessorDeAstronomiaEnsinoSuperior,
                ProfessorDeBiblioteconomiaDoEnsinoSuperior,
                ProfessorDeBiologiaNoEnsinoMedio,
                ProfessorDeCienciaPoliticaDoEnsinoSuperior,
                ProfessorDeCienciasBiologicasDoEnsinoSuperior,
                ProfessorDeCienciasExatasENaturaisDoEnsinoFundamental,
                ProfessorDeComputacaoNoEnsinoSuperior,
                ProfessorDeComunicacaoSocialDoEnsinoSuperior,
                ProfessorDeContabilidade,
                ProfessorDeDanca,
                ProfessorDeDesenhoTecnico,
                ProfessorDeDireitoDoEnsinoSuperior,
                ProfessorDeDisciplinasPedagogicasNoEnsinoMedio,
                ProfessorDeEconomia,
                ProfessorDeEducacaoArtisticaDoEnsinoFundamental,
                ProfessorDeEducacaoFisicaDoEnsinoFundamental,
                ProfessorDeEducacaoFisicaNoEnsinoMedio,
                ProfessorDeEducacaoFisicaNoEnsinoSuperior,
                ProfessorDeEnfermagemDoEnsinoSuperior,
                ProfessorDeEngenharia,
                ProfessorDeEnsinoSuperiorNaAreaDeDidatica,
                ProfessorDeEnsinoSuperiorNaAreaDeOrientacaoEducacional,
                ProfessorDeEnsinoSuperiorNaAreaDePesquisaEducacional,
                ProfessorDeEnsinoSuperiorNaAreaDePraticaDeEnsino,
                ProfessorDeEstatisticaNoEnsinoSuperior,
                ProfessorDeFarmaciaEBioquimica,
                ProfessorDeFilologiaECriticaTextual,
                ProfessorDeFilosofiaDoEnsinoSuperior,
                ProfessorDeFilosofiaNoEnsinoMedio,
                ProfessorDeFisicaEnsinoSuperior,
                ProfessorDeFisicaNoEnsinoMedio,
                ProfessorDeFisioterapia,
                ProfessorDeFonoaudiologia,
                ProfessorDeGeofisica,
                ProfessorDeGeografiaDoEnsinoFundamental,
                ProfessorDeGeografiaDoEnsinoSuperior,
                ProfessorDeGeografiaNoEnsinoMedio,
                ProfessorDeGeologia,
                ProfessorDeHistoriaDoEnsinoFundamental,
                ProfessorDeHistoriaDoEnsinoSuperior,
                ProfessorDeHistoriaNoEnsinoMedio,
                ProfessorDeJornalismo,
                ProfessorDeLinguaAlema,
                ProfessorDeLinguaELiteraturaBrasileiraNoEnsinoMedio,
                ProfessorDeLinguaEspanhola,
                ProfessorDeLinguaEstrangeiraModernaDoEnsinoFundamental,
                ProfessorDeLinguaEstrangeiraModernaNoEnsinoMedio,
                ProfessorDeLinguaFrancesa,
                ProfessorDeLinguaInglesa,
                ProfessorDeLinguaItaliana,
                ProfessorDeLinguaPortuguesa,
                ProfessorDeLinguaPortuguesaDoEnsinoFundamental,
                ProfessorDeLinguasEstrangeirasModernas,
                ProfessorDeLinguisticaELinguisticaAplicada,
                ProfessorDeLiteraturaAlema,
                ProfessorDeLiteraturaBrasileira,
                ProfessorDeLiteraturaComparada,
                ProfessorDeLiteraturaDeLinguasEstrangeirasModernas,
                ProfessorDeLiteraturaEspanhola,
                ProfessorDeLiteraturaFrancesa,
                ProfessorDeLiteraturaInglesa,
                ProfessorDeLiteraturaItaliana,
                ProfessorDeLiteraturaPortuguesa,
                ProfessorDeMatematicaAplicadaNoEnsinoSuperior,
                ProfessorDeMatematicaDoEnsinoFundamental,
                ProfessorDeMatematicaNoEnsinoMedio,
                ProfessorDeMatematicaPuraNoEnsinoSuperior,
                ProfessorDeMedicina,
                ProfessorDeMedicinaVeterinaria,
                ProfessorDeMuseologiaDoEnsinoSuperior,
                ProfessorDeMusicaNoEnsinoSuperior,
                ProfessorDeNivelMedioNaEducacaoInfantil,
                ProfessorDeNivelMedioNoEnsinoFundamental,
                ProfessorDeNivelMedioNoEnsinoProfissionalizante,
                ProfessorDeNivelSuperiorDoEnsinoFundamentalPrimeiraAQuartaSerie,
                ProfessorDeNivelSuperiorNaEducacaoInfantilQuatroASeisAnos,
                ProfessorDeNivelSuperiorNaEducacaoInfantilZeroATresAnos,
                ProfessorDeNutricao,
                ProfessorDeOdontologia,
                ProfessorDeOutrasLinguasELiteraturas,
                ProfessorDePesquisaOperacionalNoEnsinoSuperior,
                ProfessorDePsicologiaDoEnsinoSuperior,
                ProfessorDePsicologiaNoEnsinoMedio,
                ProfessorDeQuimicaEnsinoSuperior,
                ProfessorDeQuimicaNoEnsinoMedio,
                ProfessorDeSemiotica,
                ProfessorDeServicoSocialDoEnsinoSuperior,
                ProfessorDeSociologiaDoEnsinoSuperior,
                ProfessorDeSociologiaNoEnsinoMedio,
                ProfessorDeTecnicasAgricolas,
                ProfessorDeTecnicasComerciaisESecretariais,
                ProfessorDeTecnicasDeEnfermagem,
                ProfessorDeTecnicasERecursosAudiovisuais,
                ProfessorDeTecnicasIndustriais,
                ProfessorDeTecnologiaECalculoTecnico,
                ProfessorDeTeoriaDaLiteratura,
                ProfessorDeTerapiaOcupacional,
                ProfessorDeZootecniaDoEnsinoSuperior,
                ProfessorInstrutorDeEnsinoEAprendizagemAgroflorestal,
                ProfessorInstrutorDeEnsinoEAprendizagemEmServicos,
                ProfessorLeigoNoEnsinoFundamental,
                ProfessorPraticoNoEnsinoProfissionalizante,
                ProfessoresDeCursosLivres,
                ProfissionalDeAtletismo,
                ProfissionalDeEducacaoFisicaNaSaude,
                ProfissionalDeRelacoesComInvestidores,
                ProfissionalDeRelacoesInstitucionaisEGovernamentais,
                ProfissionalDoSexo,
                ProfissonalDeRelacoesInternacionais,
                ProgramadorDeMaquinasFerramentaComComandoNumerico,
                ProgramadorVisualGrafico,
                ProjetistaDeMoveis,
                ProjetistaDeSistemasDeAudio,
                ProjetistaDeSom,
                PromotorDeJustica,
                PromotorDeVendas,
                PromotorDeVendasEspecializado,
                PropagandistaDeProdutosFamaceuticos,
                ProteticoDentario,
                Psicanalista,
                PsicologoAcupunturista,
                PsicologoClinico,
                PsicologoDoEsporte,
                PsicologoDoTrabalho,
                PsicologoDoTransito,
                PsicologoEducacional,
                PsicologoHospitalar,
                PsicologoJuridico,
                PsicologoSocial,
                Psicomotricista,
                Psicopedagogo,
                Publicitario,
                Pugilista,
                QueijeiroNaFabricacaoDeLaticinio,
                Quimico,
                QuimicoIndustrial,
                Quiropraxista,
                RachadorDeCourosEPeles,
                Radiotelegrafista,
                Raizeiro,
                RebaixadorDeCouros,
                RebarbadorDeMetal,
                RebitadorAMarteloPneumatico,
                RebitadorAMao,
                RecebedorDeApostasLoteria,
                RecebedorDeApostasTurfe,
                RecepcionistaDeBanco,
                RecepcionistaDeCasasDeEspetaculos,
                RecepcionistaDeConsultorioMedicoOuDentario,
                RecepcionistaDeHotel,
                RecepcionistaDeSeguroSaude,
                RecepcionistaEmGeral,
                Recreador,
                RecreadorDeAcantonamento,
                RecuperadorDeGuiasECilindros,
                RedatorDePublicidade,
                RedatorDeTextosTecnicos,
                Redeiro,
                RedeiroPesca,
                RefinadorDeOleoEGordura,
                RefinadorDeSal,
                RegistradorDeCancer,
                RejuntadorDeRevestimentos,
                RelacoesPublicas,
                RelojoeiroFabricacao,
                RelojoeiroReparacao,
                RemetedorDeFios,
                ReparadorDeAparelhosDeTelecomunicacoesEmLaboratorio,
                ReparadorDeAparelhosEletrodomesticosExcetoImagemESom,
                ReparadorDeEquipamentosDeEscritorio,
                ReparadorDeEquipamentosFotograficos,
                ReparadorDeInstrumentosMusicais,
                ReparadorDeRadioTvESom,
                ReporterExclusiveRadioETelevisao,
                ReporterDeMidiasAudiovisuais,
                ReporterFotografico,
                RepositorDeMercadorias,
                RepresentanteComercialAutonomo,
                RestauradorDeInstrumentosMusicaisExcetoCordasArcadas,
                RestauradorDeLivros,
                RetalhadorDeCarne,
                ReveladorDeFilmesFotograficosEmCores,
                ReveladorDeFilmesFotograficosEmPretoEBranco,
                RevestidorDeInterioresPapelMaterialPlasticoEEmborrachados,
                RevestidorDeSuperficiesDeConcreto,
                RevisorDeFiosProducaoTextil,
                RevisorDeTecidosAcabados,
                RevisorDeTecidosCrus,
                RevisorDeTexto,
                RiscadorDeEstruturasMetalicas,
                RiscadorDeRoupas,
                Sacristao,
                SalgadorDeAlimentos,
                SalsicheiroFabricacaoDeLinguicaSalsichaEProdutosSimilares,
                SalvaVidas,
                Sanitarista,
                SapateiroCalcadosSobMedida,
                SargentoBombeiroMilitar,
                SargentoDaPoliciaMilitar,
                SecadorDeMadeira,
                SecretariaTrilingue,
                SecretariaOExecutivaO,
                SecretarioBilingue,
                SecretarioExecutivo,
                SegundoOficialDeMaquinasDaMarinhaMercante,
                SegundoTenenteDePoliciaMilitar,
                SelecionadorDeMaterialReciclavel,
                Seleiro,
                Senador,
                Sepultador,
                Sericultor,
                Seringueiro,
                SerradorDeBordasNoDesdobramentoDeMadeira,
                SerradorDeMadeira,
                SerradorDeMadeiraSerraCircularMultipla,
                SerradorDeMadeiraSerraDeFitaMultipla,
                Serralheiro,
                ServenteDeObras,
                Sexador,
                SinaleiroPonteRolante,
                Socioeducador,
                Sociologo,
                SocorristaExcetoMedicosEEnfermeiros,
                SoldadoBombeiroMilitar,
                SoldadoDaPoliciaMilitar,
                Soldador,
                SoldadorAOxigas,
                SoldadorAluminotermicoEmConservacaoDeTrilhos,
                SoldadorEletrico,
                SondadorPocosDePetroleoEGas,
                SondadorDePocosExcetoDePetroleoEGas,
                Sonoplasta,
                SopradorDeConvertedor,
                SopradorDeVidro,
                SubprocuradorDeJusticaMilitar,
                SubprocuradorGeralDaRepublica,
                SubprocuradorGeralDoTrabalho,
                SubtenenteBombeiroMilitar,
                SubtenenteDaPoliciaMilitar,
                SuperintendenteTecnicoNoTransporteAquaviario,
                SupervisorIndustriaDeCalcadosEArtefatosDeCouro,
                SupervisorAdministrativo,
                SupervisorDaAdministracaoDeAeroportos,
                SupervisorDaAquicultura,
                SupervisorDaAreaFlorestal,
                SupervisorDaConfeccaoDeArtefatosDeTecidosCourosEAfins,
                SupervisorDaIndustriaDeBebidas,
                SupervisorDaIndustriaDeFumo,
                SupervisorDaIndustriaDeMineraisNaoMetalicosExcetoOsDerivadosDePetroleoECarvao,
                SupervisorDaManutencaoEReparacaoDeVeiculosLeves,
                SupervisorDaManutencaoEReparacaoDeVeiculosPesados,
                SupervisorDaMecanicaDePrecisao,
                SupervisorDasArtesGraficasIndustriaEditorialEGrafica,
                SupervisorDeAlmoxarifado,
                SupervisorDeAndar,
                SupervisorDeApoioOperacionalNaMineracao,
                SupervisorDeBombeiros,
                SupervisorDeCaixasEBilheteirosExcetoCaixaDeBanco,
                SupervisorDeCambio,
                SupervisorDeCargaEDescarga,
                SupervisorDeCobranca,
                SupervisorDeColetadoresDeApostasEDeJogos,
                SupervisorDeCompras,
                SupervisorDeContasAPagar,
                SupervisorDeControleDeTratamentoTermico,
                SupervisorDeControlePatrimonial,
                SupervisorDeCreditoECobranca,
                SupervisorDeCurtimento,
                SupervisorDeDigitacaoEOperacao,
                SupervisorDeEmbalagemEEtiquetagem,
                SupervisorDeEmpresaAereaEmAeroportos,
                SupervisorDeEnsino,
                SupervisorDeEntrevistadoresERecenseadores,
                SupervisorDeExploracaoAgricola,
                SupervisorDeExploracaoAgropecuaria,
                SupervisorDeExploracaoPecuaria,
                SupervisorDeExtracaoDeSal,
                SupervisorDeFabricacaoDeInstrumentosMusicais,
                SupervisorDeFabricacaoDeProdutosCeramicosPorcelanatosEAfins,
                SupervisorDeFabricacaoDeProdutosDeVidro,
                SupervisorDeJoalheria,
                SupervisorDeLavanderia,
                SupervisorDeLogistica,
                SupervisorDeManutencaoDeAparelhosTermicosDeClimatizacaoEDeRefrigeracao,
                SupervisorDeManutencaoDeBombasMotoresCompressoresEEquipamentosDeTransmissao,
                SupervisorDeManutencaoDeMaquinasGraficas,
                SupervisorDeManutencaoDeMaquinasIndustriaisTexteis,
                SupervisorDeManutencaoDeMaquinasOperatrizesEDeUsinagem,
                SupervisorDeManutencaoDeViasFerreas,
                SupervisorDeManutencaoEletricaDeAltaTensaoIndustrial,
                SupervisorDeManutencaoEletromecanica,
                SupervisorDeManutencaoEletromecanicaUtilidades,
                SupervisorDeManutencaoEletromecanicaIndustrialComercialEPredial,
                SupervisorDeMontagemEInstalacaoEletroeletronica,
                SupervisorDeOperacaoDeFluidosDistribuicaoCaptacaoTratamentoDeAguaGasesVapor,
                SupervisorDeOperacaoEletricaGeracaoTransmissaoEDistribuicaoDeEnergiaEletrica,
                SupervisorDeOperacoesMidiasAudiovisuais,
                SupervisorDeOperacoesPortuarias,
                SupervisorDeOrcamento,
                SupervisorDePerfuracaoEDesmonte,
                SupervisorDeProducaoDaIndustriaAlimenticia,
                SupervisorDeProducaoNaMineracao,
                SupervisorDeRecepcionistas,
                SupervisorDeReparosLinhasFerreas,
                SupervisorDeTelefonistas,
                SupervisorDeTelemarketingEAtendimento,
                SupervisorDeTesouraria,
                SupervisorDeTransporteNaMineracao,
                SupervisorDeTransportes,
                SupervisorDeUsinaDeConcreto,
                SupervisorDeVendasComercial,
                SupervisorDeVendasDeServicos,
                SupervisorDeVigilantes,
                SupervisorTecnicoMidiasAudiovisuais,
                SupervisorTecnicoOperacionalDeSistemasDeTelevisaoEProdutorasDeVideo,
                Surfassagista,
                Sushiman,
                TabeliaoDeNotas,
                TabeliaoDeProtestos,
                TaifeiroExcetoMilitares,
                Tanoeiro,
                TapeceiroDeAutos,
                Taqueiro,
                Taquigrafo,
                Taxidermista,
                TecelaoRedes,
                TecelaoRendasEBordados,
                TecelaoTearAutomatico,
                TecelaoTearJacquard,
                TecelaoTearManual,
                TecelaoTearMecanicoDeMaquineta,
                TecelaoTearMecanicoDeXadrez,
                TecelaoTearMecanicoLiso,
                TecelaoTearMecanicoExcetoJacquard,
                TecelaoDeMalhasMaquinaCircular,
                TecelaoDeMalhasMaquinaRetilinea,
                TecelaoDeMalhasAMaquina,
                TecelaoDeMeiasMaquinaCircular,
                TecelaoDeMeiasMaquinaRetilinea,
                TecelaoDeMeiasAMaquina,
                TecelaoDeTapetesAMao,
                TecelaoDeTapetesAMaquina,
                TecnicoAgricola,
                TecnicoAgropecuario,
                TecnicoDaReceitaFederal,
                TecnicoDeAcabamentoEmSiderurgia,
                TecnicoDeAciariaEmSiderurgia,
                TecnicoDeAlimentos,
                TecnicoDeApoioABioengenharia,
                TecnicoDeApoioEmPesquisaEDesenvolvimentoExcetoAgropecuarioEFlorestal,
                TecnicoDeApoioEmPesquisaEDesenvolvimentoAgropecuarioFlorestal,
                TecnicoDeCeluloseEPapel,
                TecnicoDeComunicacaoDeDados,
                TecnicoDeContabilidade,
                TecnicoDeControleDeMeioAmbiente,
                TecnicoDeDesportoIndividualEColetivoExcetoFutebol,
                TecnicoDeEnfermagem,
                TecnicoDeEnfermagemDaEstrategiaDeSaudeDaFamilia,
                TecnicoDeEnfermagemDeTerapiaIntensiva,
                TecnicoDeEnfermagemDoTrabalho,
                TecnicoDeEnfermagemPsiquiatrica,
                TecnicoDeEstradas,
                TecnicoDeFundicaoEmSiderurgia,
                TecnicoDeGarantiaDaQualidade,
                TecnicoDeImobilizacaoOrtopedica,
                TecnicoDeLaboratorioDeAnalisesFisicoQuimicasMateriaisDeConstrucao,
                TecnicoDeLaboratorioEFiscalizacaoDesportiva,
                TecnicoDeLaboratorioIndustrial,
                TecnicoDeLaminacaoEmSiderurgia,
                TecnicoDeManutencaoDeSistemasEInstrumentos,
                TecnicoDeManutencaoEletrica,
                TecnicoDeManutencaoEletricaDeMaquina,
                TecnicoDeManutencaoEletronica,
                TecnicoDeManutencaoEletronicaCircuitosDeMaquinasComComandoNumerico,
                TecnicoDeMateriaPrimaEMaterial,
                TecnicoDeMeteorologia,
                TecnicoDeMineracao,
                TecnicoDeMineracaoOleoEPetroleo,
                TecnicoDeObrasCivis,
                TecnicoDeOperacaoQuimicaPetroquimicaEAfins,
                TecnicoDeOperacoesEServicosBancariosCambio,
                TecnicoDeOperacoesEServicosBancariosCreditoImobiliario,
                TecnicoDeOperacoesEServicosBancariosCreditoRural,
                TecnicoDeOperacoesEServicosBancariosLeasing,
                TecnicoDeOperacoesEServicosBancariosRendaFixaEVariavel,
                TecnicoDeOrtopedia,
                TecnicoDePainelDeControle,
                TecnicoDePlanejamentoDeProducao,
                TecnicoDePlanejamentoEProgramacaoDaManutencao,
                TecnicoDeProducaoEmRefinoDePetroleo,
                TecnicoDeRedeTelecomunicacoes,
                TecnicoDeReducaoNaSiderurgiaPrimeiraFusao,
                TecnicoDeRefratarioEmSiderurgia,
                TecnicoDeResseguros,
                TecnicoDeSaneamento,
                TecnicoDeSeguros,
                TecnicoDeSistemasAudiovisuais,
                TecnicoDeSuporteAoUsuarioDeTecnologiaDaInformacao,
                TecnicoDeTelecomunicacoesTelefonia,
                TecnicoDeTransmissaoTelecomunicacoes,
                TecnicoDeTributosEstadual,
                TecnicoDeTributosMunicipal,
                TecnicoDeUtilidadeProducaoEDistribuicaoDeVaporGasesOleosCombustiveisEnergia,
                TecnicoDeVendas,
                TecnicoDoMobiliario,
                TecnicoEletricista,
                TecnicoEletronico,
                TecnicoEmAcupuntura,
                TecnicoEmAdministracao,
                TecnicoEmAdministracaoDeComercioExterior,
                TecnicoEmAgrimensura,
                TecnicoEmAtendimentoEVendas,
                TecnicoEmAutomobilistica,
                TecnicoEmBiblioteconomia,
                TecnicoEmBiotecnologia,
                TecnicoEmBioterismo,
                TecnicoEmBorracha,
                TecnicoEmCalcadosEArtefatosDeCouro,
                TecnicoEmCaldeiraria,
                TecnicoEmCalibracao,
                TecnicoEmCarcinicultura,
                TecnicoEmConfeccoesDoVestuario,
                TecnicoEmCurtimento,
                TecnicoEmDireitosAutorais,
                TecnicoEmEletromecanica,
                TecnicoEmEspirometria,
                TecnicoEmEstruturasMetalicas,
                TecnicoEmFarmacia,
                TecnicoEmFotonica,
                TecnicoEmGeodesiaECartografia,
                TecnicoEmGeofisica,
                TecnicoEmGeologia,
                TecnicoEmGeoquimica,
                TecnicoEmGeotecnia,
                TecnicoEmGravacaoDeAudio,
                TecnicoEmHemoterapia,
                TecnicoEmHidrografia,
                TecnicoEmHigieneOcupacional,
                TecnicoEmHistologia,
                TecnicoEmImunobiologicos,
                TecnicoEmInstalacaoDeEquipamentosDeAudio,
                TecnicoEmInstrumentacao,
                TecnicoEmLaboratorioDeFarmacia,
                TecnicoEmMadeira,
                TecnicoEmManutencaoDeBalancas,
                TecnicoEmManutencaoDeEquipamentosDeInformatica,
                TecnicoEmManutencaoDeEquipamentosEInstrumentosMedicoHospitalares,
                TecnicoEmManutencaoDeHidrometros,
                TecnicoEmManutencaoDeInstrumentosDeMedicaoEPrecisao,
                TecnicoEmManutencaoDeMaquinas,
                TecnicoEmMasterizacaoDeAudio,
                TecnicoEmMateriaisProdutosCeramicosEVidros,
                TecnicoEmMecanicaDePrecisao,
                TecnicoEmMecatronicaAutomacaoDaManufatura,
                TecnicoEmMecatronicaRobotica,
                TecnicoEmMetodosEletrograficosEmEncefalografia,
                TecnicoEmMetodosGraficosEmCardiologia,
                TecnicoEmMitilicultura,
                TecnicoEmMixagemDeAudio,
                TecnicoEmMuseologia,
                TecnicoEmNutricaoEDietetica,
                TecnicoEmOpticaEOptometria,
                TecnicoEmPatologiaClinica,
                TecnicoEmPecuaria,
                TecnicoEmPesquisaMineral,
                TecnicoEmPetroquimica,
                TecnicoEmPiscicultura,
                TecnicoEmPlanejamentoDeLavraDeMinas,
                TecnicoEmPlastico,
                TecnicoEmPolissonografia,
                TecnicoEmProcessamentoMineralExcetoPetroleo,
                TecnicoEmProgramacaoVisual,
                TecnicoEmQuiropraxia,
                TecnicoEmRadiologiaEImagenologia,
                TecnicoEmRanicultura,
                TecnicoEmSaudeBucal,
                TecnicoEmSaudeBucalDaEstrategiaDeSaudeDaFamilia,
                TecnicoEmSecretariado,
                TecnicoEmSegurancaDoTrabalho,
                TecnicoEmSinaisNavais,
                TecnicoEmSinalizacaoNautica,
                TecnicoEmSoldagem,
                TecnicoEmSonorizacao,
                TecnicoEmTratamentoDeEfluentes,
                TecnicoEmTurismo,
                TecnicoFlorestal,
                TecnicoGrafico,
                TecnicoMecanico,
                TecnicoMecanicoAeronaves,
                TecnicoMecanicoCalefacaoVentilacaoERefrigeracao,
                TecnicoMecanicoEmbarcacoes,
                TecnicoMecanicoMaquinas,
                TecnicoMecanicoMotores,
                TecnicoMecanicoNaFabricacaoDeFerramentas,
                TecnicoMecanicoNaManutencaoDeFerramentas,
                TecnicoOperacionalDeServicosDeCorreios,
                TecnicoQuimico,
                TecnicoQuimicoDePetroleo,
                TecnicoTextil,
                TecnicoTextilTratamentosQuimicos,
                TecnicoTextilDeFiacao,
                TecnicoTextilDeMalharia,
                TecnicoTextilDeTecelagem,
                TecnicosEmManobrasEmEquipamentosDeConves,
                TecnologoEmAlimentos,
                TecnologoEmAutomacaoIndustrial,
                TecnologoEmConstrucaoCivil,
                TecnologoEmEletricidade,
                TecnologoEmEletronica,
                TecnologoEmFabricacaoMecanica,
                TecnologoEmGastronomia,
                TecnologoEmGestaoAdministrativoFinanceira,
                TecnologoEmGestaoDaTecnologiaDaInformacao,
                TecnologoEmGestaoHospitalar,
                TecnologoEmLogisticaDeTransporte,
                TecnologoEmMecatronica,
                TecnologoEmMeioAmbiente,
                TecnologoEmMetalurgia,
                TecnologoEmPetroleoEGas,
                TecnologoEmProcessosQuimicos,
                TecnologoEmProducaoAudiovisual,
                TecnologoEmProducaoFonografica,
                TecnologoEmProducaoIndustrial,
                TecnologoEmProducaoSulcroalcooleira,
                TecnologoEmRadiologia,
                TecnologoEmRochasOrnamentais,
                TecnologoEmSecretariadoEscolar,
                TecnologoEmSegurancaDoTrabalho,
                TecnologoEmSistemasBiomedicos,
                TecnologoEmSoldagem,
                TecnologoEmTelecomunicacoes,
                TecnologoOftalmico,
                TeleatendenteDeEmergencia,
                Telefonista,
                Teleoperador,
                TelhadorTelhasDeArgilaEMateriaisSimilares,
                TelhadorTelhasDeCimentoAmianto,
                TelhadorTelhasMetalicas,
                TelhadorTelhasPlasticas,
                TemperadorDeMetaisEDeCompositos,
                TemperadorDeVidro,
                TenenteDoCorpoDeBombeirosMilitar,
                TenenteCoronelBombeiroMilitar,
                TenenteCoronelDaPoliciaMilitar,
                Teologo,
                TerapeutaHolistico,
                TerapeutaOcupacional,
                TesoureiroDeBanco,
                TingidorDeCourosEPeles,
                TingidorDeRoupas,
                Tipografo,
                Titeriteiro,
                Topografo,
                TorneiroLavraDePedra,
                TorneiroNaUsinagemConvencionalDeMadeira,
                TorradorDeCacau,
                TorradorDeCafe,
                TorristaPetroleo,
                TosadorDeAnimaisDomesticos,
                TrabalhadorAgropecuarioEmGeral,
                TrabalhadorDaAviculturaDeCorte,
                TrabalhadorDaAviculturaDePostura,
                TrabalhadorDaCaprinocultura,
                TrabalhadorDaCulturaDeAlgodao,
                TrabalhadorDaCulturaDeArroz,
                TrabalhadorDaCulturaDeCacau,
                TrabalhadorDaCulturaDeCafe,
                TrabalhadorDaCulturaDeCanaDeAcucar,
                TrabalhadorDaCulturaDeErvaMate,
                TrabalhadorDaCulturaDeEspeciarias,
                TrabalhadorDaCulturaDeFumo,
                TrabalhadorDaCulturaDeGuarana,
                TrabalhadorDaCulturaDeMilhoESorgo,
                TrabalhadorDaCulturaDePlantasAromaticasEMedicinais,
                TrabalhadorDaCulturaDeSisal,
                TrabalhadorDaCulturaDeTrigoAveiaCevadaETriticale,
                TrabalhadorDaCulturaDoRami,
                TrabalhadorDaCunicultura,
                TrabalhadorDaElaboracaoDePreFabricadosCimentoAmianto,
                TrabalhadorDaElaboracaoDePreFabricadosConcretoArmado,
                TrabalhadorDaExploracaoDeAcai,
                TrabalhadorDaExploracaoDeAndiroba,
                TrabalhadorDaExploracaoDeArvoresEArbustosProdutoresDeSubstanciasAromatMedicEToxicas,
                TrabalhadorDaExploracaoDeBabacu,
                TrabalhadorDaExploracaoDeBacaba,
                TrabalhadorDaExploracaoDeBuriti,
                TrabalhadorDaExploracaoDeCarnauba,
                TrabalhadorDaExploracaoDeCastanha,
                TrabalhadorDaExploracaoDeCiposProdutoresDeSubstanciasAromaticasMedicinaisEToxicas,
                TrabalhadorDaExploracaoDeCocoDaPraia,
                TrabalhadorDaExploracaoDeCopaiba,
                TrabalhadorDaExploracaoDeEspeciesProdutorasDeGomasNaoElasticas,
                TrabalhadorDaExploracaoDeMadeirasTanantes,
                TrabalhadorDaExploracaoDeMalvaPaina,
                TrabalhadorDaExploracaoDeMurumuru,
                TrabalhadorDaExploracaoDeOiticica,
                TrabalhadorDaExploracaoDeOuricuri,
                TrabalhadorDaExploracaoDePequi,
                TrabalhadorDaExploracaoDePiacava,
                TrabalhadorDaExploracaoDePinhao,
                TrabalhadorDaExploracaoDePupunha,
                TrabalhadorDaExploracaoDeRaizesProdutorasDeSubstanciasAromaticasMedicinaisEToxicas,
                TrabalhadorDaExploracaoDeResinas,
                TrabalhadorDaExploracaoDeTucum,
                TrabalhadorDaExtracaoDeSubstanciasAromaticasMedicinaisEToxicasEmGeral,
                TrabalhadorDaFabricacaoDeMunicaoEExplosivos,
                TrabalhadorDaFabricacaoDePedrasArtificiais,
                TrabalhadorDaFabricacaoDeResinasEVernizes,
                TrabalhadorDaManutencaoDeEdificacoes,
                TrabalhadorDaOvinocultura,
                TrabalhadorDaPecuariaAsininosEMuares,
                TrabalhadorDaPecuariaBovinosCorte,
                TrabalhadorDaPecuariaBovinosLeite,
                TrabalhadorDaPecuariaBubalinos,
                TrabalhadorDaPecuariaEquinos,
                TrabalhadorDaSuinocultura,
                TrabalhadorDeExtracaoFlorestalEmGeral,
                TrabalhadorDeFabricacaoDeMargarina,
                TrabalhadorDeFabricacaoDeSorvete,
                TrabalhadorDeFabricacaoDeTintas,
                TrabalhadorDeFabricacaoDeVinhos,
                TrabalhadorDePecuariaPolivalente,
                TrabalhadorDePreparacaoDePescadosLimpeza,
                TrabalhadorDeServicosDeLimpezaEConservacaoDeAreasPublicas,
                TrabalhadorDeTratamentoDoLeiteEFabricacaoDeLaticiniosEAfins,
                TrabalhadorDoAcabamentoDeArtefatosDeTecidosECouros,
                TrabalhadorDoBeneficiamentoDeFumo,
                TrabalhadorEmCriatoriosDeAnimaisProdutoresDeVeneno,
                TrabalhadorNaApicultura,
                TrabalhadorNaCulturaDeAmendoim,
                TrabalhadorNaCulturaDeCanola,
                TrabalhadorNaCulturaDeCocoDaBaia,
                TrabalhadorNaCulturaDeDende,
                TrabalhadorNaCulturaDeMamona,
                TrabalhadorNaCulturaDeSoja,
                TrabalhadorNaCulturaDoGirassol,
                TrabalhadorNaCulturaDoLinho,
                TrabalhadorNaFabricacaoDeProdutosAbrasivos,
                TrabalhadorNaMinhocultura,
                TrabalhadorNaOlericulturaFrutosESementes,
                TrabalhadorNaOlericulturaLegumes,
                TrabalhadorNaOlericulturaRaizesBulbosETuberculos,
                TrabalhadorNaOlericulturaTalosFolhasEFlores,
                TrabalhadorNaOperacaoDeSistemaDeIrrigacaoLocalizadaMicroaspersaoEGotejamento,
                TrabalhadorNaOperacaoDeSistemaDeIrrigacaoPorAspersaoPivoCentral,
                TrabalhadorNaOperacaoDeSistemasConvencionaisDeIrrigacaoPorAspersao,
                TrabalhadorNaOperacaoDeSistemasDeIrrigacaoEAspersaoAltoPropelido,
                TrabalhadorNaOperacaoDeSistemasDeIrrigacaoPorSuperficieEDrenagem,
                TrabalhadorNaProducaoDeMudasESementes,
                TrabalhadorNaSericicultura,
                TrabalhadorNoCultivoDeArvoresFrutiferas,
                TrabalhadorNoCultivoDeEspeciesFrutiferasRasteiras,
                TrabalhadorNoCultivoDeFloresEFolhagensDeCorte,
                TrabalhadorNoCultivoDeFloresEmVaso,
                TrabalhadorNoCultivoDeForracoes,
                TrabalhadorNoCultivoDeMudas,
                TrabalhadorNoCultivoDePlantasOrnamentais,
                TrabalhadorNoCultivoDeTrepadeirasFrutiferas,
                TrabalhadorPolivalenteDaConfeccaoDeCalcados,
                TrabalhadorPolivalenteDoCurtimentoDeCourosEPeles,
                TrabalhadorPortuarioDeCapatazia,
                TrabalhadorVolanteDaAgricultura,
                TracadorDePedras,
                Tradutor,
                TrancadorDeCabosDeAco,
                TransformadorDeTubosDeVidro,
                Trapezista,
                TratadorDeAnimais,
                TratoristaAgricola,
                TrefiladorJoalheriaEOurivesaria,
                TrefiladorDeBorracha,
                TrefiladorDeMetaisAMaquina,
                TreinadorProfissionalDeFutebol,
                TricoteiroAMao,
                Tropeiro,
                Turismologo,
                Urbanista,
                VaqueadorDeCourosEPeles,
                VarredorDeRua,
                Vassoureiro,
                VendedorPermissionario,
                VendedorAmbulante,
                VendedorDeComercioVarejista,
                VendedorEmComercioAtacadista,
                VendedorEmDomicilio,
                VendedorPracista,
                Vereador,
                Vibradorista,
                ViceGovernadorDeEstado,
                ViceGovernadorDoDistritoFederal,
                VicePrefeito,
                VicePresidenteDaRepublica,
                Vidraceiro,
                VidraceiroEdificacoes,
                VidraceiroVitrais,
                Vigia,
                VigiaFlorestal,
                VigiaPortuario,
                Vigilante,
                Vinagreiro,
                VisitadorSanitario,
                VistoriadorNaval,
                VisualMerchandiser,
                ViveiristaFlorestal,
                Xaropeiro,
                ZeladorDeEdificio,
                Zootecnista,
                Balconista,
                Aposentado,
                Pensionista,
                Autonomo,
                DoLar,
                AuxiliarDeServicosGerais,
                ServidorPublico,
                Estagiario,
                Militar,
                Empresario,
                Professor,
                Comerciante,
                Outros,
                Pecuarista,
                GerenteDeCusto,
                AuxiliarDeProducao,
                MecanicoDeDiesel,
                PreparadorDeCoquetel,
                Bancario,
                Devops,
                Programador
            };

        }
        public static Profissao ObterPorId(int id)
        {
            if (id < 0)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }
    }
}
