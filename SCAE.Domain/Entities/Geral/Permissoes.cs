using System.ComponentModel.DataAnnotations;


namespace SCAE.Domain.Entities.Geral
{

    public enum Permissoes
    {
        [Display(GroupName = "Master", Name = "Master", Description = "Concede acesso total ao sistema")]
        Master = 0,
        [Display(GroupName = "GerenteCorretor", Name = "GerenteCorretor", Description = "Concede acesso total ao sistema da área do corretor")]
        Gerente = 1,
        [Display(GroupName = "Administrador", Name = "Administrador", Description = "Concede acesso total ao sistema da área do Erp faltando algumas informações específicas")]
        Administrador = 2,

        #region Almoxarifado
        [Display(GroupName = "Almoxarifado", Name = "Cadastrar Almoxarifado", Description = "Permite cadastrar um novo almoxarifado")]
        Almoxarifado_Almoxarifado_Cadastrar = 1001,
        [Display(GroupName = "Almoxarifado", Name = "Alterar Almoxarifado", Description = "Permite alterar um almoxarifado")]
        Almoxarifado_Almoxarifado_Alterar = 1002,
        [Display(GroupName = "Almoxarifado", Name = "Excluir Almoxarifado", Description = "Permite excluir um almoxarifado")]
        Almoxarifado_Almoxarifado_Excluir = 1003,
        [Display(GroupName = "Almoxarifado", Name = "Listar Almoxarifados", Description = "Permite listar os almoxarifados")]
        Almoxarifado_Almoxarifado_Listar = 1004,

        [Display(GroupName = "GrupoProduto", Name = "Cadastrar Grupo de Produtos", Description = "Permite cadastrar um novo Grupo de Produtos")]
        Almoxarifado_GrupoProduto_Cadastrar = 2001,
        [Display(GroupName = "GrupoProduto", Name = "Alterar Grupo de Produtos", Description = "Permite alterar um Grupo de Produtos")]
        Almoxarifado_GrupoProduto_Alterar = 2002,
        [Display(GroupName = "GrupoProduto", Name = "Excluir Grupo de Produtos", Description = "Permite excluir um Grupo de Produtos")]
        Almoxarifado_GrupoProduto_Excluir = 2003,
        [Display(GroupName = "GrupoProduto", Name = "Listar Grupo de Produtos", Description = "Permite listar os Grupos de Produtos")]
        Almoxarifado_GrupoProduto_Listar = 2004,

        [Display(GroupName = "Inventario", Name = "Cadastrar Inventario", Description = "Permite cadastrar um novo Inventario")]
        Almoxarifado_Inventario_Cadastrar = 3001,
        [Display(GroupName = "Inventario", Name = "Alterar Inventario", Description = "Permite alterar um Inventario")]
        Almoxarifado_Inventario_Alterar = 3002,
        [Display(GroupName = "Inventario", Name = "Excluir Inventario", Description = "Permite excluir um Inventario")]
        Almoxarifado_Inventario_Excluir = 3003,
        [Display(GroupName = "Inventario", Name = "Listar Inventarios", Description = "Permite listar os Inventarios")]
        Almoxarifado_Inventario_Listar = 3004,

        [Display(GroupName = "Movimentacao", Name = "Cadastrar Movimentação", Description = "Permite cadastrar uma nova Movimentação")]
        Almoxarifado_Movimentacao_Cadastrar = 4001,
        [Display(GroupName = "Movimentacao", Name = "Alterar Movimentação", Description = "Permite alterar uma Movimentação")]
        Almoxarifado_Movimentacao_Alterar = 4002,
        [Display(GroupName = "Movimentacao", Name = "Excluir Movimentação", Description = "Permite excluir uma Movimentação")]
        Almoxarifado_Movimentacao_Excluir = 4003,
        [Display(GroupName = "Movimentacao", Name = "Listar Movimentação", Description = "Permite listar as Movimentações")]
        Almoxarifado_Movimentacao_Listar = 4004,
        [Display(GroupName = "Movimentacao", Name = "Cadastrar Transferencia", Description = "Permite realizar uma Transferencia")]
        Almoxarifado_Movimentacao_Transferir = 4005,

        [Display(GroupName = "Produto", Name = "Cadastrar Produto", Description = "Permite cadastrar um novo Produto")]
        Almoxarifado_Produto_Cadastrar = 5001,
        [Display(GroupName = "Produto", Name = "Alterar Produto", Description = "Permite alterar um Produto")]
        Almoxarifado_Produto_Alterar = 5002,
        [Display(GroupName = "Produto", Name = "Excluir Produto", Description = "Permite excluir um Produto")]
        Almoxarifado_Produto_Excluir = 5003,
        [Display(GroupName = "Produto", Name = "Listar Produto", Description = "Permite listar os Produtos")] //para fotos e lista filtrada também
        Almoxarifado_Produto_Listar = 5004,

        [Display(GroupName = "Requisicao", Name = "Cadastrar Requisição", Description = "Permite cadastrar uma Requisição")]
        Almoxarifado_Requisicao_Cadastrar = 6001,
        [Display(GroupName = "Requisicao", Name = "Alterar Requisição", Description = "Permite alterar uma Requisição")]
        Almoxarifado_Requisicao_Alterar = 6002,
        [Display(GroupName = "Requisicao", Name = "Excluir Requisição", Description = "Permite excluir uma Requisição")]
        Almoxarifado_Requisicao_Excluir = 6003,
        [Display(GroupName = "Requisicao", Name = "Listar Requisição", Description = "Permite listar as Requisições")] //para item também
        Almoxarifado_Requisicao_Listar = 6004,

        [Display(GroupName = "TipoMovimentacao", Name = "Listar Tipo de Movimentação", Description = "Permite listar os Tipos de Movimentação")] 
        Almoxarifado_TipoMovimentacao_Listar = 7001,

        [Display(GroupName = "TipoProduto", Name = "Listar Tipo de Produto", Description = "Permite listar os Tipos de Produto")]
        Almoxarifado_TipoProduto_Listar = 8001,

        [Display(GroupName = "UnidadeMedida", Name = "Cadastrar Unidade de Medida", Description = "Permite cadastrar uma Unidade de Medida")]
        Almoxarifado_UnidadeMedida_Cadastrar = 9001,
        [Display(GroupName = "UnidadeMedida", Name = "Alterar Unidade de Medida", Description = "Permite alterar uma Unidade de Medida")]
        Almoxarifado_UnidadeMedida_Alterar = 9002,
        [Display(GroupName = "UnidadeMedida", Name = "Excluir Unidade de Medida", Description = "Permite excluir uma Unidade de Medida")]
        Almoxarifado_UnidadeMedida_Excluir = 9003,
        [Display(GroupName = "UnidadeMedida", Name = "Listar Unidade de Medida", Description = "Permite listar as Unidades de Medida")] 
        Almoxarifado_UnidadeMedida_Listar = 9004,
        #endregion

        #region Base
        [Display(GroupName = "Assinante", Name = "Cadastrar Assinante", Description = "Permite cadastrar um assinante")]
        Base_Assinante_Cadastrar = 10001,
        [Display(GroupName = "Assinante", Name = "Alterar Assinante", Description = "Permite alterar um assinante")]
        Base_Assinante_Alterar = 10002,
        [Display(GroupName = "Assinante", Name = "Excluir Assinante", Description = "Permite excluir um assinante")]
        Base_Assinante_Excluir = 10003,
        [Display(GroupName = "Assinante", Name = "Listar Assinante", Description = "Permite listar os assinantes")]
        Base_Assinante_Listar = 10004,
        #endregion

        #region Clientes
        [Display(GroupName = "Contrato", Name = "Cadastrar Contrato", Description = "Permite cadastrar um contrato")]
        Clientes_Contrato_Cadastrar = 11001,
        [Display(GroupName = "Contrato", Name = "Alterar Contrato", Description = "Permite alterar um contrato")]
        Clientes_Contrato_Alterar = 11002,
        [Display(GroupName = "Contrato", Name = "Excluir Contrato", Description = "Permite excluir um contrato")]
        Clientes_Contrato_Excluir = 11003,
        [Display(GroupName = "Contrato", Name = "Listar Contrato", Description = "Permite listar os contratos")]
        Clientes_Contrato_Listar = 11004,
        [Display(GroupName = "Contrato", Name = "Aditar Contrato", Description = "Permite aditar o contrato")]
        Clientes_Contrato_Aditar = 11005,
        [Display(GroupName = "Contrato", Name = "Atualizar Instrução", Description = "Permite Atualizar instrução das parcelas do contrato")]
        Clientes_Contrato_AtualizarInstrucao = 11006,
        [Display(GroupName = "Contrato", Name = "Cancelar Contrato", Description = "Permite cancelar o contrato")]
        Clientes_Contrato_Cancelar = 11007,
        [Display(GroupName = "Contrato", Name = "Reverter Aditamento", Description = "Permite reverter o aditamento")]
        Clientes_Contrato_ReverterAditamento = 11008,

        [Display(GroupName = "TipoContrato", Name = "Cadastrar Tipo de Contrato", Description = "Permite cadastrar um Tipo de Contrato")]
        Clientes_TipoContrato_Cadastrar = 12001,
        [Display(GroupName = "TipoContrato", Name = "Alterar Tipo de Contrato", Description = "Permite alterar um Tipo de Contrato")]
        Clientes_TipoContrato_Alterar = 12002,
        [Display(GroupName = "TipoContrato", Name = "Excluir Tipo de Contrato", Description = "Permite excluir um Tipo de Contrato")]
        Clientes_TipoContrato_Excluir = 12003,
        [Display(GroupName = "TipoContrato", Name = "Listar Tipo de Contrato", Description = "Permite listar os Tipos de Contratos")]
        Clientes_TipoContrato_Listar = 12004,

        [Display(GroupName = "TipoOperacaoContrato", Name = "Listar Tipo de Operação Contrato", Description = "Permite listar os Tipos de Operação dos Contratos")]
        Clientes_TipoOperacaoContrato_Listar = 13001,

        [Display(GroupName = "TipoProdutoContrato", Name = "Listar Tipo de Produto do Contrato", Description = "Permite listar os Tipos de Produto dos Contratos")]
        Clientes_TipoProdutoContrato_Listar = 14001,

        [Display(GroupName = "TipoAditamentoContrato", Name = "Listar Tipo de Aditamento do Contrato", Description = "Permite listar os Tipos de Aditamento dos Contratos")]
        Clientes_TipoAditamentoContrato_Listar = 66001,
        #endregion

        #region Compras
        [Display(GroupName = "Orcamento", Name = "Cadastrar Orçamento", Description = "Permite cadastrar um orçamento")]
        Compras_Orcamento_Cadastrar = 15001,
        [Display(GroupName = "Orcamento", Name = "Alterar Orçamento", Description = "Permite alterar um orçamento")]
        Compras_Orcamento_Alterar = 15002,
        [Display(GroupName = "Orcamento", Name = "Excluir Orçamento", Description = "Permite excluir um orçamento")]
        Compras_Orcamento_Excluir = 15003,
        [Display(GroupName = "Orcamento", Name = "Listar Orçamento", Description = "Permite listar os orçamentos")]
        Compras_Orcamento_Listar = 15004,
        [Display(GroupName = "Orcamento", Name = "Cancelar Orçamento", Description = "Permite cancelar um orçamento")]
        Compras_Orcamento_Cancelar = 15005,
        [Display(GroupName = "Orcamento", Name = "Aprovar Orçamento", Description = "Permite aprovar um orçamento")]
        Compras_Orcamento_Aprovar = 15006,

        [Display(GroupName = "Parametro", Name = "Cadastrar Parametro", Description = "Permite cadastrar um parametro")]
        Compras_Parametro_Cadastrar = 16001,
        [Display(GroupName = "Parametro", Name = "Alterar Parametro", Description = "Permite alterar um parametro")]
        Compras_Parametro_Alterar = 16002,
        [Display(GroupName = "Parametro", Name = "Excluir Parametro", Description = "Permite excluir um parametro")]
        Compras_Parametro_Excluir = 16003,
        [Display(GroupName = "Parametro", Name = "Listar Parametro", Description = "Permite listar os parametros")]
        Compras_Parametro_Listar = 16004,

        [Display(GroupName = "Pedido", Name = "Cadastrar Pedido", Description = "Permite cadastrar um Pedido")]
        Compras_Pedido_Cadastrar = 17001,
        [Display(GroupName = "Pedido", Name = "Alterar Pedido", Description = "Permite alterar um Pedido")]
        Compras_Pedido_Alterar = 17002,
        [Display(GroupName = "Pedido", Name = "Excluir Pedido", Description = "Permite excluir um Pedido")]
        Compras_Pedido_Excluir = 17003,
        [Display(GroupName = "Pedido", Name = "Listar Pedido", Description = "Permite listar os Pedidos")]
        Compras_Pedido_Listar = 17004,
        [Display(GroupName = "Pedido", Name = "Receber Pedido", Description = "Permite receber o pedido")]
        Compras_Pedido_Receber = 17005,

        [Display(GroupName = "SituacaoOrcamento", Name = "Listar Situação Orcamento", Description = "Permite listar as situacões dos orcamentos")]
        Compras_SituacaoOrcamento_Listar = 18001,

        [Display(GroupName = "SituacaoPedidoItem", Name = "Listar Situação PedidoItem", Description = "Permite listar as situacões dos Itens dos pedidos")]
        Compras_SituacaoPedidoItem_Listar = 19001,

        #endregion

        #region Empreendimento
        [Display(GroupName = "Empreendimento", Name = "Cadastrar Empreendimento", Description = "Permite cadastrar um empreendimento")]
        Empreendimento_Empreendimento_Cadastrar = 20001,
        [Display(GroupName = "Empreendimento", Name = "Alterar Empreendimento", Description = "Permite alterar um empreendimento")]
        Empreendimento_Empreendimento_Alterar = 20002,
        [Display(GroupName = "Empreendimento", Name = "Excluir Empreendimento", Description = "Permite excluir um empreendimento")]
        Empreendimento_Empreendimento_Excluir = 20003,
        [Display(GroupName = "Empreendimento", Name = "Listar Empreendimento", Description = "Permite listar os empreendimentos")]
        Empreendimento_Empreendimento_Listar = 20004,

        [Display(GroupName = "SituacaoUnidade", Name = "Listar Situacao Unidade", Description = "Permite listar a situacao das unidades")]
        Empreendimento_SituacaoUnidade_Listar = 21001,

        [Display(GroupName = "TipoEmpreendimento", Name = "Listar Tipo Empreendimento", Description = "Permite listar os tipos de empreendimento")]
        Empreendimento_TipoEmpreendimento_Listar = 22001,

        [Display(GroupName = "TipoGrupo", Name = "Listar Tipo Grupo", Description = "Permite listar os tipos de Grupo")]
        Empreendimento_TipoGrupo_Listar = 23001,

        [Display(GroupName = "TipoImovel", Name = "Listar Tipo Imovel", Description = "Permite listar os tipos de Imovel")]
        Empreendimento_TipoImovel_Listar = 24001,

        [Display(GroupName = "TipoUnidade", Name = "Listar Tipo Unidade", Description = "Permite listar os tipos de Unidade")]
        Empreendimento_TipoUnidade_Listar = 25001,

        [Display(GroupName = "Vicio", Name = "Cadastrar Vicio", Description = "Permite cadastrar um Vicio")]
        Empreendimento_Vicio_Cadastrar = 26001,
        [Display(GroupName = "Vicio", Name = "Alterar Vicio", Description = "Permite alterar um Vicio")]
        Empreendimento_Vicio_Alterar = 26002,
        [Display(GroupName = "Vicio", Name = "Excluir Vicio", Description = "Permite excluir um Vicio")]
        Empreendimento_Vicio_Excluir = 26003,
        [Display(GroupName = "Vicio", Name = "Listar Vicio", Description = "Permite listar os Vicios")]
        Empreendimento_Vicio_Listar = 26004,

        #endregion

        #region Financeiro
        [Display(GroupName = "Banco", Name = "Cadastrar Banco", Description = "Permite cadastrar um Banco")]
        Financeiro_Banco_Cadastrar = 27001,
        [Display(GroupName = "Banco", Name = "Alterar Banco", Description = "Permite alterar um Banco")]
        Financeiro_Banco_Alterar = 27002,
        [Display(GroupName = "Banco", Name = "Excluir Banco", Description = "Permite excluir um Banco")]
        Financeiro_Banco_Excluir = 27003,
        [Display(GroupName = "Banco", Name = "Listar Banco", Description = "Permite listar os Bancos")]
        Financeiro_Banco_Listar = 27004,


        [Display(GroupName = "CentroCusto", Name = "Cadastrar Centro de Custo", Description = "Permite cadastrar um Centro de Custo")]
        Financeiro_CentroCusto_Cadastrar = 28001,
        [Display(GroupName = "CentroCusto", Name = "Alterar Centro de Custo", Description = "Permite alterar um Centro de Custo")]
        Financeiro_CentroCusto_Alterar = 28002,
        [Display(GroupName = "CentroCusto", Name = "Excluir Centro de Custo", Description = "Permite excluir um Centro de Custo")]
        Financeiro_CentroCusto_Excluir = 28003,
        [Display(GroupName = "CentroCusto", Name = "Listar Centro de Custo", Description = "Permite listar os Centros de Custo")]
        Financeiro_CentroCusto_Listar = 28004,
        [Display(GroupName = "CentroCusto", Name = "Transferencia de Centro de Custo", Description = "Permite Transferir um Centro de Custo")]
        Financeiro_CentroCusto_Transferencia = 28005,

        [Display(GroupName = "CondicaoPagamento", Name = "Cadastrar Condição de Pagamento", Description = "Permite cadastrar uma Condição de Pagamento")]
        Financeiro_CondicaoPagamento_Cadastrar = 29001,
        [Display(GroupName = "CondicaoPagamento", Name = "Alterar Condição de Pagamento", Description = "Permite alterar uma Condição de Pagamento")]
        Financeiro_CondicaoPagamento_Alterar = 29002,
        [Display(GroupName = "CondicaoPagamento", Name = "Excluir Condição de Pagamento", Description = "Permite excluir uma Condição de Pagamento")]
        Financeiro_CondicaoPagamento_Excluir = 29003,
        [Display(GroupName = "CondicaoPagamento", Name = "Listar Condições de Pagamento", Description = "Permite listar as Condições de Pagamento")]
        Financeiro_CondicaoPagamento_Listar = 29004,

        [Display(GroupName = "ContaCorrente", Name = "Cadastrar Conta Corrente", Description = "Permite cadastrar uma Conta Corrente")]
        Financeiro_ContaCorrente_Cadastrar = 30001,
        [Display(GroupName = "ContaCorrente", Name = "Alterar Conta Corrente", Description = "Permite alterar uma Conta Corrente")]
        Financeiro_ContaCorrente_Alterar = 30002,
        [Display(GroupName = "ContaCorrente", Name = "Excluir Conta Corrente", Description = "Permite excluir uma Conta Corrente")]
        Financeiro_ContaCorrente_Excluir = 30003,
        [Display(GroupName = "ContaCorrente", Name = "Listar Conta Corrente", Description = "Permite listar as Contas Correntes")]
        Financeiro_ContaCorrente_Listar = 30004,

        [Display(GroupName = "ContaGerencial", Name = "Cadastrar Conta Gerencial", Description = "Permite cadastrar uma Conta Gerencial")]
        Financeiro_ContaGerencial_Cadastrar = 31001,
        [Display(GroupName = "ContaGerencial", Name = "Alterar Conta Gerencial", Description = "Permite alterar uma Conta Gerencial")]
        Financeiro_ContaGerencial_Alterar = 31002,
        [Display(GroupName = "ContaGerencial", Name = "Excluir Conta Gerencial", Description = "Permite excluir uma Conta Gerencial")]
        Financeiro_ContaGerencial_Excluir = 31003,
        [Display(GroupName = "ContaGerencial", Name = "Listar Conta Gerencial", Description = "Permite listar as Contas Gerenciais")]
        Financeiro_ContaGerencial_Listar = 31004,
        [Display(GroupName = "ContaGerencial", Name = "Transferencia Conta Gerencial", Description = "Permite realizar transferencia em uma Conta Gerencial")]
        Financeiro_ContaGerencial_Transferencia = 31005,

        [Display(GroupName = "Despesa", Name = "Cadastrar Despesa", Description = "Permite cadastrar uma Despesa")]
        Financeiro_Despesa_Cadastrar = 32001,
        [Display(GroupName = "Despesa", Name = "Alterar Despesa", Description = "Permite alterar uma Despesa")]
        Financeiro_Despesa_Alterar = 32002,
        [Display(GroupName = "Despesa", Name = "Excluir Despesa", Description = "Permite excluir uma Despesa")]
        Financeiro_Despesa_Excluir = 32003,
        [Display(GroupName = "Despesa", Name = "Listar Despesa", Description = "Permite listar as Despesas")]
        Financeiro_Despesa_Listar = 32004,
        [Display(GroupName = "Despesa", Name = "Excluir Despesa Classificação", Description = "Permite excluir uma classificação de uma Despesa")]
        Financeiro_Despesa_ExcluirClassificacao = 32005,
        [Display(GroupName = "Despesa", Name = "Cancelar Baixa", Description = "Permite Cancelar uma Baixa")]
        Financeiro_Despesa_CancelarBaixa = 32006,
        [Display(GroupName = "Despesa", Name = "Excluir Documento Despesa", Description = "Permite excluir um Documento de uma Despesa")]
        Financeiro_Despesa_ExcluirDocumento = 32007,
        [Display(GroupName = "Despesa", Name = "Listar Documento", Description = "Permite listar Documentos")]
        Financeiro_Despesa_ListarDocumento = 32008,
        [Display(GroupName = "Despesa", Name = "Listar Baixa", Description = "Permite listar as Baixas")]
        Financeiro_Despesa_ListarBaixa = 32009,
        [Display(GroupName = "Despesa", Name = "Listar Parcela", Description = "Permite listar as Parcelas")]
        Financeiro_Despesa_ListarParcela = 32010,
        [Display(GroupName = "Despesa", Name = "Baixar Parcela", Description = "Permite Baixar uma Parcela")]
        Financeiro_Despesa_BaixarParcela = 32011,
        [Display(GroupName = "Despesa", Name = "Cancelar Parcela", Description = "Permite Cancelar uma Parcela")]
        Financeiro_Despesa_CancelarParcela = 32012,
        [Display(GroupName = "Despesa", Name = "Alterar Parcela", Description = "Permite Alterar uma Parcela")]
        Financeiro_Despesa_AlterarParcela = 32013,
        [Display(GroupName = "Despesa", Name = "Excluir Parcela", Description = "Permite excluir uma Parcela")]
        Financeiro_Despesa_ExcluirParcela = 32014,


        [Display(GroupName = "Receita", Name = "Cadastrar Receita", Description = "Permite cadastrar uma Receita")]
        Financeiro_Receita_Cadastrar = 33001,
        [Display(GroupName = "Receita", Name = "Alterar Receita", Description = "Permite alterar uma Receita")]
        Financeiro_Receita_Alterar = 33002,
        [Display(GroupName = "Receita", Name = "Excluir Receita", Description = "Permite excluir uma Receita")]
        Financeiro_Receita_Excluir = 33003,
        [Display(GroupName = "Receita", Name = "Listar Receita", Description = "Permite listar as Receitas")]
        Financeiro_Receita_Listar = 33004,
        [Display(GroupName = "Receita", Name = "Excluir Receita Classificação", Description = "Permite excluir uma classificação de uma Receita")]
        Financeiro_Receita_ExcluirClassificacao = 33005,
        [Display(GroupName = "Receita", Name = "Cancelar Baixa", Description = "Permite Cancelar uma Baixa")]
        Financeiro_Receita_CancelarBaixa = 33006,
        [Display(GroupName = "Receita", Name = "Excluir Documento Receita", Description = "Permite excluir um Documento de uma Receita")]
        Financeiro_Receita_ExcluirDocumento = 33007,
        [Display(GroupName = "Receita", Name = "Listar Documento", Description = "Permite listar Documentos")]
        Financeiro_Receita_ListarDocumento = 33008,
        [Display(GroupName = "Receita", Name = "Listar Baixa", Description = "Permite listar as Baixas")]
        Financeiro_Receita_ListarBaixa = 33009,
        [Display(GroupName = "Receita", Name = "Listar Parcela", Description = "Permite listar as Parcelas")]
        Financeiro_Receita_ListarParcela = 33010,
        [Display(GroupName = "Receita", Name = "Baixar Parcela", Description = "Permite Baixar uma Parcela")]
        Financeiro_Receita_BaixarParcela = 33011,
        [Display(GroupName = "Receita", Name = "Cancelar Parcela", Description = "Permite Cancelar uma Parcela")]
        Financeiro_Receita_CancelarParcela = 33012,
        [Display(GroupName = "Receita", Name = "Alterar Parcela", Description = "Permite Alterar uma Parcela")]
        Financeiro_Receita_AlterarParcela = 33013,
        [Display(GroupName = "Receita", Name = "Gerar Comprovante", Description = "Permite Gerar um Comprovante")]
        Financeiro_Receita_GerarComprovante = 33014,
        [Display(GroupName = "Receita", Name = "Visualizar Comprovante", Description = "Permite Visualizar um Comprovante")]
        Financeiro_Receita_VisualizarComprovante = 33015,
        [Display(GroupName = "Receita", Name = "Reajustar Receita", Description = "Permite Reajustar Receita")]
        Financeiro_Receita_Reajustar = 33016,
        [Display(GroupName = "Receita", Name = "Agrupar Parcelas", Description = "Permite Agrupar Parcelas")]
        Financeiro_Receita_Agrupar = 33017,
        [Display(GroupName = "Receita", Name = "Visualizar Quitação", Description = "Permite Visualizar Quitação de uma receita")]
        Financeiro_Receita_VisualizarQuitacao = 33018,
        [Display(GroupName = "Receita", Name = "Antecipar Receita", Description = "Permite Antecipar uma receita")]
        Financeiro_Receita_Antecipar = 33019,
        [Display(GroupName = "Receita", Name = "Visualizar Antecipação", Description = "Permite Visualizar Antecipação de uma receita")]
        Financeiro_Receita_VisualizarAntecipacao = 33020,
        [Display(GroupName = "Receita", Name = "Gerar Boleto", Description = "Permite Gerar Boleto")]
        Financeiro_Receita_GerarBoleto = 33021,
        [Display(GroupName = "Receita", Name = "Cadastrar Parcela", Description = "Permite cadastrar uma Parcela")]
        Financeiro_Receita_CadastrarParcela = 33022,
        [Display(GroupName = "Receita", Name = "Cancelar Boleto", Description = "Permite Cancelar Boleto")]
        Financeiro_Receita_CancelarBoleto = 33023,
        [Display(GroupName = "Receita", Name = "Atualizar Encargos", Description = "Permite Atualizar Encargos")]
        Financeiro_Receita_AtualizarEncargos = 33024,
        [Display(GroupName = "Receita", Name = "Visualizar Encargos", Description = "Permite Visualizar Encargos")]
        Financeiro_Receita_VisualizarEncargos = 33025,
        [Display(GroupName = "Receita", Name = "AtualizarInstrucaoParcelasSistema", Description = "Permite atualizar a instrucao de todas as parcelas do sistema")]
        Financeiro_Receita_AtualizarInstrucaoParcelasSistema = 33026,
        [Display(GroupName = "Receita", Name = "Quitar Receita", Description = "Permite quitar uma receita")]
        Financeiro_Receita_Quitar = 33027,
        [Display(GroupName = "Receita", Name = "Visualizar Comprovante Antecipacao", Description = "Permite Visualizar um Comprovante de Antecipação")]
        Financeiro_Receita_VisualizarComprovanteAntecipacao = 33028,
        [Display(GroupName = "Receita", Name = "Gerar Comprovante Antecipacao", Description = "Permite Gerar um Comprovante de Antecipação")]
        Financeiro_Receita_GerarComprovanteAntecipacao = 33029,
        [Display(GroupName = "Receita", Name = "Visualizar Comprovante Simulacao Antecipacao", Description = "Permite Visualizar um comprovante de simulação de Antecipação")]
        Financeiro_Receita_VisualizarComprovanteSimulacaoAntecipacao = 33030,
        [Display(GroupName = "Receita", Name = "Visualizar Comprovante Simulacao Quitacao", Description = "Permite Visualizar um comprovante de simulação de Quitação")]
        Financeiro_Receita_VisualizarComprovanteSimulacaoQuitacao = 33031,
        [Display(GroupName = "Receita", Name = "Excluir Parcela", Description = "Permite excluir uma parcela")]
        Financeiro_Receita_ExcluirParcela = 33032,


        [Display(GroupName = "FormaPagamento", Name = "Cadastrar Forma de Pagamento", Description = "Permite cadastrar uma Forma de Pagamento")]
        Financeiro_FormaPagamento_Cadastrar = 34001,
        [Display(GroupName = "FormaPagamento", Name = "Alterar Forma de Pagamento", Description = "Permite alterar uma Forma de Pagamento")]
        Financeiro_FormaPagamento_Alterar = 34002,
        [Display(GroupName = "FormaPagamento", Name = "Excluir Forma de Pagamento", Description = "Permite excluir uma Forma de Pagamento")]
        Financeiro_FormaPagamento_Excluir = 34003,
        [Display(GroupName = "FormaPagamento", Name = "Listar Forma de Pagamento", Description = "Permite listar as Formas de Pagamento")]
        Financeiro_FormaPagamento_Listar = 34004,

        [Display(GroupName = "Indice", Name = "Cadastrar Indice", Description = "Permite cadastrar um Indice")]
        Financeiro_Indice_Cadastrar = 35001,
        [Display(GroupName = "Indice", Name = "Alterar Indice", Description = "Permite alterar um Indice")]
        Financeiro_Indice_Alterar = 35002,
        [Display(GroupName = "Indice", Name = "Excluir Indice", Description = "Permite excluir um Indice")]
        Financeiro_Indice_Excluir = 35003,
        [Display(GroupName = "Indice", Name = "Listar Indice", Description = "Permite listar os Indices")]
        Financeiro_Indice_Listar = 35004,

        [Display(GroupName = "LayoutCobranca", Name = "Listar Layout Cobrança", Description = "Permite listar os Layouts de Cobrança")]
        Financeiro_LayoutCobranca_Listar = 36001,

        [Display(GroupName = "Parametro", Name = "Cadastrar Parametro", Description = "Permite cadastrar um Parametro")]
        Financeiro_Parametro_Cadastrar = 37001,
        [Display(GroupName = "Parametro", Name = "Alterar Parametro", Description = "Permite alterar um Parametro")]
        Financeiro_Parametro_Alterar = 37002,
        [Display(GroupName = "Parametro", Name = "Excluir Parametro", Description = "Permite excluir um Parametro")]
        Financeiro_Parametro_Excluir = 37003,
        [Display(GroupName = "Parametro", Name = "Listar Parametro", Description = "Permite listar os Parametros")]
        Financeiro_Parametro_Listar = 37004,
        [Display(GroupName = "Parametro", Name = "Enviar SMS", Description = "Define se o parâmetro terá envio de SMS")]
        Financeiro_Parametro_EnviarSMS = 37005,
        

        [Display(GroupName = "Relatorio", Name = "Listar Relatorio", Description = "Permite visualizar os Relatorios")]
        Financeiro_Relatorio_Listar = 38001,

        [Display(GroupName = "SituacaoDespesaParcela", Name = "Listar Situacao Despesa Parcela", Description = "Permite listar as Situações das Parcelas das Despesas")]
        Financeiro_SituacaoDespesaParcela_Listar = 39001,

        [Display(GroupName = "SituacaoReceitaParcela", Name = "Listar Situacao Receita Parcela", Description = "Permite listar as Situações das Parcelas das Receitas")]
        Financeiro_SituacaoReceitaParcela_Listar = 40001,

        [Display(GroupName = "TipoDespesa", Name = "Listar Tipo Despesa", Description = "Permite listar os Tipos de Despesas")]
        Financeiro_TipoDespesa_Listar = 41001,

        [Display(GroupName = "TipoDocumento", Name = "Cadastrar Tipo Documento", Description = "Permite cadastrar um Tipo de Documento")]
        Financeiro_TipoDocumento_Cadastrar = 42001,
        [Display(GroupName = "TipoDocumento", Name = "Alterar Tipo Documento", Description = "Permite alterar um Tipo de Documento")]
        Financeiro_TipoDocumento_Alterar = 42002,
        [Display(GroupName = "TipoDocumento", Name = "Excluir Tipo Documento", Description = "Permite excluir um Tipo de Documento")]
        Financeiro_TipoDocumento_Excluir = 42003,
        [Display(GroupName = "TipoDocumento", Name = "Listar Tipo Documento", Description = "Permite listar os Tipos de Documentos")]
        Financeiro_TipoDocumento_Listar = 42004,

        [Display(GroupName = "TipoGateway", Name = "Listar Tipo Gateway", Description = "Permite listar os Tipos de Gateway")]
        Financeiro_TipoGateway_Listar = 43001,

        [Display(GroupName = "TipoIndice", Name = "Listar Tipo Indice", Description = "Permite listar os Tipos de Indice")]
        Financeiro_TipoIndice_Listar = 44001,

        [Display(GroupName = "TipoIndice", Name = "Excluir Tipo Indice", Description = "Permite excluir os Tipos de Indice")]
        Financeiro_TipoIndice_Excluir = 44002,

        [Display(GroupName = "TipoIndice", Name = "Alterar Tipo Indice", Description = "Permite alterar os Tipos de Indice")]
        Financeiro_TipoIndice_Alterar = 44003,

        [Display(GroupName = "TipoIndice", Name = "Cadastrar Tipo Indice", Description = "Permite cadastrar os Tipos de Indice")]
        Financeiro_TipoIndice_Cadastrar = 44004,

        [Display(GroupName = "TipoReceita", Name = "Listar Tipo Receita", Description = "Permite listar os Tipos de Receita")]
        Financeiro_TipoReceita_Listar = 45001,

        [Display(GroupName = "TipoServicoParcela", Name = "Cadastrar Tipo Serviço Parcela", Description = "Permite cadastrar um Tipo de Servico da Parcela")]
        Financeiro_TipoServicoParcela_Cadastrar = 67001,
        [Display(GroupName = "TipoServicoParcela", Name = "Alterar Tipo Serviço Parcela", Description = "Permite alterar um Tipo de Servico da Parcela")]
        Financeiro_TipoServicoParcela_Alterar = 67002,
        [Display(GroupName = "TipoServicoParcela", Name = "Excluir Tipo Serviço Parcela", Description = "Permite excluir um Tipo de Servico da Parcela")]
        Financeiro_TipoServicoParcela_Excluir = 67003,
        [Display(GroupName = "TipoServicoParcela", Name = "Listar Tipo Serviço Parcela", Description = "Permite listar os Tipos de Servico das Parcela")]
        Financeiro_TipoServicoParcela_Listar = 67004,

        [Display(GroupName = "ReguaCobranca", Name = "Cadastrar Régua de Cobrança", Description = "Permite cadastrar uma Régua de Cobrança")]
        Financeiro_ReguaCobranca_Cadastrar = 68001,
        [Display(GroupName = "ReguaCobranca", Name = "Alterar Régua de Cobrança", Description = "Permite alterar uma Régua de Cobrança")]
        Financeiro_ReguaCobranca_Alterar = 68002,
        [Display(GroupName = "ReguaCobranca", Name = "Excluir Régua de Cobrança", Description = "Permite excluir uma Régua de Cobrança")]
        Financeiro_ReguaCobranca_Excluir = 68003,
        [Display(GroupName = "ReguaCobranca", Name = "Listar Régua de Cobrança", Description = "Permite listar as Réguas de Cobrança")]
        Financeiro_ReguaCobranca_Listar = 68004,


        [Display(GroupName = "RetornoBancario", Name = "Cadastrar RetornoBancario", Description = "Permite cadastrar um RetornoBancario")]
        Financeiro_RetornoBancario_Cadastrar = 69001,
        [Display(GroupName = "RetornoBancario", Name = "Alterar RetornoBancario", Description = "Permite alterar um RetornoBancario")]
        Financeiro_RetornoBancario_Alterar = 69002,
        [Display(GroupName = "RetornoBancario", Name = "Excluir RetornoBancario", Description = "Permite excluir um RetornoBancario")]
        Financeiro_RetornoBancario_Excluir = 69003,
        [Display(GroupName = "RetornoBancario", Name = "Listar RetornoBancario", Description = "Permite listar os RetornoBancario")]
        Financeiro_RetornoBancario_Listar = 69004,

        [Display(GroupName = "AdiantamentoCarteira", Name = "Cadastrar AdiantamentoCarteira", Description = "Permite cadastrar um AdiantamentoCarteira")]
        Financeiro_AdiantamentoCarteira_Cadastrar = 87001,
        [Display(GroupName = "AdiantamentoCarteira", Name = "Alterar AdiantamentoCarteira", Description = "Permite alterar um AdiantamentoCarteira")]
        Financeiro_AdiantamentoCarteira_Alterar = 87002,
        [Display(GroupName = "AdiantamentoCarteira", Name = "Excluir AdiantamentoCarteira", Description = "Permite excluir um AdiantamentoCarteira")]
        Financeiro_AdiantamentoCarteira_Excluir = 87003,
        [Display(GroupName = "AdiantamentoCarteira", Name = "Listar AdiantamentoCarteira", Description = "Permite listar os AdiantamentoCarteira")]
        Financeiro_AdiantamentoCarteira_Listar = 87004,

        [Display(GroupName = "TipoAdiantamentoCarteira", Name = "Listar TipoAdiantamentoCarteira", Description = "Permite listar os TipoAdiantamentoCarteira")]
        Financeiro_TipoAdiantamentoCarteira_Listar = 88001,

        [Display(GroupName = "SituacaoAdiantamentoCarteira", Name = "Listar SituacaoAdiantamentoCarteira", Description = "Permite listar as SituacaoAdiantamentoCarteira")]
        Financeiro_SituacaoAdiantamentoCarteira_Listar = 89001,


        #endregion

        #region Geral

        [Display(GroupName = "Cartorio", Name = "Cadastrar Cartorio", Description = "Permite cadastrar um Cartorio")]
        Geral_Cartorio_Cadastrar = 46001,
        [Display(GroupName = "Cartorio", Name = "Alterar Cartorio", Description = "Permite alterar um Cartorio")]
        Geral_Cartorio_Alterar = 46002,
        [Display(GroupName = "Cartorio", Name = "Excluir Cartorio", Description = "Permite excluir um Cartorio")]
        Geral_Cartorio_Excluir = 46003,
        [Display(GroupName = "Cartorio", Name = "Listar Cartorio", Description = "Permite listar os Cartorios")]
        Geral_Cartorio_Listar = 46004,

        [Display(GroupName = "Empresa", Name = "Cadastrar Empresa", Description = "Permite cadastrar uma Empresa")]
        Geral_Empresa_Cadastrar = 47001,
        [Display(GroupName = "Empresa", Name = "Alterar Empresa", Description = "Permite alterar uma Empresa")]
        Geral_Empresa_Alterar = 47002,
        [Display(GroupName = "Empresa", Name = "Excluir Empresa", Description = "Permite excluir uma Empresa")]
        Geral_Empresa_Excluir = 47003,
        [Display(GroupName = "Empresa", Name = "Listar Empresa", Description = "Permite listar as Empresas")]
        Geral_Empresa_Listar = 47004,
        [Display(GroupName = "Empresa", Name = "Listar Extrato Empresa", Description = "Permite listar o Extrato das Empresas")]
        Geral_Empresa_ListarExtrato = 47005,
        [Display(GroupName = "Empresa", Name = "Listar Saldo Zoop Empresa", Description = "Permite listar o Saldo Zoop das Empresas")]
        Geral_Empresa_ListarSaldoZoop = 47006,
        [Display(GroupName = "Empresa", Name = "Transferir Saldo Zoop Empresa", Description = "Permite Transferir o Saldo Zoop das Empresas")]
        Geral_Empresa_TransferirSaldoZoop = 47007,
        [Display(GroupName = "Empresa", Name = "Cadastrar Documento Zoop", Description = "Permite cadastrar um Documento Zoop")]
        Geral_Empresa_CadastrarDocumentoZoop = 47008,

        [Display(GroupName = "Endereco", Name = "Listar Endereço", Description = "Permite listar os Endereços")]
        Geral_Endereco_Listar = 48001,

        [Display(GroupName = "EstadoCivil", Name = "Listar Estado Civil", Description = "Permite listar o Estado Civil")]
        Geral_EstadoCivil_Listar = 49001,

        [Display(GroupName = "Log", Name = "Cadastrar Log", Description = "Permite cadastrar um Log")]
        Geral_Log_Cadastrar = 50001,
        [Display(GroupName = "Log", Name = "Listar Log", Description = "Permite listar os Logs")]
        Geral_Log_Listar = 50002,

        [Display(GroupName = "Nacionalidade", Name = "Listar Nacionalidade", Description = "Permite listar as Nacionalidades")]
        Geral_Nacionalidade_Listar = 51001,

        [Display(GroupName = "Pessoa", Name = "Cadastrar Pessoa", Description = "Permite cadastrar uma Pessoa")]
        Geral_Pessoa_Cadastrar = 52001,
        [Display(GroupName = "Pessoa", Name = "Alterar Pessoa", Description = "Permite alterar uma Pessoa")]
        Geral_Pessoa_Alterar = 52002,
        [Display(GroupName = "Pessoa", Name = "Excluir Pessoa", Description = "Permite excluir uma Pessoa")]
        Geral_Pessoa_Excluir = 52003,
        [Display(GroupName = "Pessoa", Name = "Listar Pessoa", Description = "Permite listar as Pessoas")]
        Geral_Pessoa_Listar = 52004,
        [Display(GroupName = "Pessoa", Name = "Criar Usuario", Description = "Permite Criar um Usuario")]
        Geral_Pessoa_CriarUsuario = 52005,

        [Display(GroupName = "Profissao", Name = "Listar Profissões", Description = "Permite listar as Profissões")]
        Geral_Profissao_Listar = 53001,

        [Display(GroupName = "Seguradora", Name = "Cadastrar Seguradora", Description = "Permite cadastrar uma Seguradora")]
        Geral_Seguradora_Cadastrar = 54001,
        [Display(GroupName = "Seguradora", Name = "Alterar Seguradora", Description = "Permite alterar uma Seguradora")]
        Geral_Seguradora_Alterar = 54002,
        [Display(GroupName = "Seguradora", Name = "Excluir Seguradora", Description = "Permite excluir uma Seguradora")]
        Geral_Seguradora_Excluir = 54003,
        [Display(GroupName = "Seguradora", Name = "Listar Seguradora", Description = "Permite listar as Seguradoras")]
        Geral_Seguradora_Listar = 54004,

        [Display(GroupName = "Sexo", Name = "Listar Sexo", Description = "Permite listar os Sexos")]
        Geral_Sexo_Listar = 55001,

        [Display(GroupName = "SituacaoFrete", Name = "Listar Situação Frete", Description = "Permite listar as Situações dos Fretes")]
        Geral_SituacaoFrete_Listar = 56001,

        [Display(GroupName = "TipoOrigem", Name = "Listar Tipo Origem", Description = "Permite listar os Tipos de Origem")]
        Geral_TipoOrigem_Listar = 57001,

        [Display(GroupName = "TipoPessoa", Name = "Listar Tipo Pessoa", Description = "Permite listar os Tipos de Pessoa")]
        Geral_TipoPessoa_Listar = 58001,

        [Display(GroupName = "TipoProcessoJudicial", Name = "Cadastrar Tipo Processo Judicial", Description = "Permite cadastrar um Tipo de Processo Judicial")]
        Geral_TipoProcessoJudicial_Cadastrar = 59001,
        [Display(GroupName = "TipoProcessoJudicial", Name = "Alterar Tipo Processo Judicial", Description = "Permite alterar um Tipo de Processo Judicial")]
        Geral_TipoProcessoJudicial_Alterar = 59002,
        [Display(GroupName = "TipoProcessoJudicial", Name = "Excluir Tipo Processo Judicial", Description = "Permite excluir um Tipo de Processo Judicial")]
        Geral_TipoProcessoJudicial_Excluir = 59003,
        [Display(GroupName = "TipoProcessoJudicial", Name = "Listar Tipo Processo Judicial", Description = "Permite listar os Tipo de Processos Judiciais")]
        Geral_TipoProcessoJudicial_Listar = 59004,

        [Display(GroupName = "Usuario", Name = "Cadastrar Usuario", Description = "Permite cadastrar um Usuario")]
        Geral_Usuario_Cadastrar = 60001,
        [Display(GroupName = "Usuario", Name = "Alterar Usuario", Description = "Permite alterar um Usuario")]
        Geral_Usuario_Alterar = 60002,
        [Display(GroupName = "Usuario", Name = "Excluir Usuario", Description = "Permite excluir um Usuario")]
        Geral_Usuario_Excluir = 60003,
        [Display(GroupName = "Usuario", Name = "Listar Usuario", Description = "Permite listar os Usuarios")]
        Geral_Usuario_Listar = 60004,
        [Display(GroupName = "Usuario", Name = "Resetar Senha", Description = "Permite Resetar a Senha")]
        Geral_Usuario_ResetarSenha = 60005,
        [Display(GroupName = "Usuario", Name = "Alterar Senha", Description = "Permite Alterar a Senha")]
        Geral_Usuario_AlterarSenha = 60006,
        [Display(GroupName = "Usuario", Name = "Mudar Tema", Description = "Permite Mudar o Tema")]
        Geral_Usuario_MudarTema = 60007,
        [Display(GroupName = "Usuario", Name = "Cadastrar Permissoes", Description = "Permite Cadastrar Permissões do usuário")]
        Geral_Usuario_CadastrarPermissoes = 60008,



        #endregion

        #region Projeto
        [Display(GroupName = "ContratoFornecedor", Name = "Cadastrar Contrato Fornecedor", Description = "Permite cadastrar um Contrato de Fornecedor")]
        Projeto_ContratoFornecedor_Cadastrar = 61001,
        [Display(GroupName = "ContratoFornecedor", Name = "Alterar Contrato Fornecedor", Description = "Permite alterar um Contrato de Fornecedor")]
        Projeto_ContratoFornecedor_Alterar = 61002,
        [Display(GroupName = "ContratoFornecedor", Name = "Excluir Contrato Fornecedor", Description = "Permite excluir um Contrato de Fornecedor")]
        Projeto_ContratoFornecedor_Excluir = 61003,
        [Display(GroupName = "ContratoFornecedor", Name = "Listar Contrato Fornecedor", Description = "Permite listar os Contratos dos Fornecedores")]
        Projeto_ContratoFornecedor_Listar = 61004,

        [Display(GroupName = "Etapa", Name = "Cadastrar Etapa", Description = "Permite cadastrar uma Etapa")]
        Projeto_Etapa_Cadastrar = 62001,
        [Display(GroupName = "Etapa", Name = "Alterar Etapa", Description = "Permite alterar uma Etapa")]
        Projeto_Etapa_Alterar = 62002,
        [Display(GroupName = "Etapa", Name = "Excluir Etapa", Description = "Permite excluir uma Etapa")]
        Projeto_Etapa_Excluir = 62003,
        [Display(GroupName = "Etapa", Name = "Listar Etapa", Description = "Permite listar as Etapas")]
        Projeto_Etapa_Listar = 62004,

        [Display(GroupName = "Medicao", Name = "Cadastrar Medição", Description = "Permite cadastrar uma Medição")]
        Projeto_Medicao_Cadastrar = 63001,
        [Display(GroupName = "Medicao", Name = "Alterar Medição", Description = "Permite alterar uma Medição")]
        Projeto_Medicao_Alterar = 63002,
        [Display(GroupName = "Medicao", Name = "Excluir Medição", Description = "Permite excluir uma Medição")]
        Projeto_Medicao_Excluir = 63003,
        [Display(GroupName = "Medicao", Name = "Listar Medição", Description = "Permite listar as Medições")]
        Projeto_Medicao_Listar = 63004,
        [Display(GroupName = "Medicao", Name = "Gerar Despesa", Description = "Permite Gerar uma Despesa em uma Medição")]
        Projeto_Medicao_GerarDespesa = 63005,

        [Display(GroupName = "Orcado", Name = "Cadastrar Orçado", Description = "Permite cadastrar um Orçamento")]
        Projeto_Orcado_Cadastrar = 64001,
        [Display(GroupName = "Orcado", Name = "Alterar Orçado", Description = "Permite alterar um Orçamento")]
        Projeto_Orcado_Alterar = 64002,
        [Display(GroupName = "Orcado", Name = "Excluir Orçado", Description = "Permite excluir um Orçamento")]
        Projeto_Orcado_Excluir = 64003,
        [Display(GroupName = "Orcado", Name = "Listar Orçado", Description = "Permite listar os Orçamentos")]
        Projeto_Orcado_Listar = 64004,

        [Display(GroupName = "TipoContratoFornecedor", Name = "Listar Tipo Contrato Fornecedor", Description = "Permite listar os Tipos de Contrato dos Fornecedores")]
        Projeto_TipoContratoFornecedor_Listar = 65001,
        #endregion

        #region Modulos
        [Display(GroupName = "Modulo", Name = "Negócios", Description = "Acesso ao Módulo Negócios")]
        Modulos_Modulo_Negocio = 999001,
        [Display(GroupName = "Modulo", Name = "Contratos", Description = "Acesso ao Módulo Contratos")]
        Modulos_Modulo_Contrato = 999002,
        [Display(GroupName = "Modulo", Name = "Financeiro", Description = "Acesso ao Módulo Financeiro")]
        Modulos_Modulo_Financeiro = 999003,
        [Display(GroupName = "Modulo", Name = "Cadastros", Description = "Acesso ao Módulo Cadastros")]
        Modulos_Modulo_Cadastro = 999004,
        [Display(GroupName = "Modulo", Name = "Administração", Description = "Acesso ao Módulo Administração")]
        Modulos_Modulo_Administracao = 999005,
        [Display(GroupName = "Modulo", Name = "KPIs", Description = "Acesso ao Módulo KPIs")]
        Modulos_Modulo_KPI = 999006,
        [Display(GroupName = "Modulo", Name = "Almoxarifado", Description = "Acesso ao Módulo Almoxarifado")]
        Modulos_Modulo_Almoxarifado = 999007,
        [Display(GroupName = "Modulo", Name = "Compras", Description = "Acesso ao Módulo Compras")]
        Modulos_Modulo_Compra = 999008,
        [Display(GroupName = "Modulo", Name = "Projeto", Description = "Acesso ao Módulo Projeto")] //gestão de obras
        Modulos_Modulo_Projeto = 999009,

        #endregion

        #region OrcamentoObras

        [Display(GroupName = "ClasseComposicao", Name = "Cadastrar ClasseComposicao", Description = "Permite cadastrar ClasseComposicao")]
        OrcamentoObras_ClasseComposicao_Cadastrar = 70001,
        [Display(GroupName = "ClasseComposicao", Name = "Alterar ClasseComposicao", Description = "Permite alterar ClasseComposicao")]
        OrcamentoObras_ClasseComposicao_Alterar = 70002,
        [Display(GroupName = "ClasseComposicao", Name = "Excluir ClasseComposicao", Description = "Permite excluir ClasseComposicao")]
        OrcamentoObras_ClasseComposicao_Excluir = 70003,
        [Display(GroupName = "ClasseComposicao", Name = "Listar ClasseComposicao", Description = "Permite listar ClasseComposicao")]
        OrcamentoObras_ClasseComposicao_Listar = 70004,

        [Display(GroupName = "Composicao", Name = "Cadastrar Composicao", Description = "Permite cadastrar uma Composicao")]
        OrcamentoObras_Composicao_Cadastrar = 71001,
        [Display(GroupName = "Composicao", Name = "Alterar Composicao", Description = "Permite alterar uma Composicao")]
        OrcamentoObras_Composicao_Alterar = 71002,
        [Display(GroupName = "Composicao", Name = "Excluir Composicao", Description = "Permite excluir uma Composicao")]
        OrcamentoObras_Composicao_Excluir = 71003,
        [Display(GroupName = "Composicao", Name = "Listar Composicao", Description = "Permite listar as Composicao")]
        OrcamentoObras_Composicao_Listar = 71004,

        [Display(GroupName = "ComposicaoItem", Name = "Cadastrar ComposicaoItem", Description = "Permite cadastrar uma ComposicaoItem")]
        OrcamentoObras_ComposicaoItem_Cadastrar = 72001,
        [Display(GroupName = "ComposicaoItem", Name = "Alterar ComposicaoItem", Description = "Permite alterar uma ComposicaoItem")]
        OrcamentoObras_ComposicaoItem_Alterar = 72002,
        [Display(GroupName = "ComposicaoItem", Name = "Excluir ComposicaoItem", Description = "Permite excluir uma ComposicaoItem")]
        OrcamentoObras_ComposicaoItem_Excluir = 72003,
        [Display(GroupName = "ComposicaoItem", Name = "Listar ComposicaoItem", Description = "Permite listar as ComposicaoItem")]
        OrcamentoObras_ComposicaoItem_Listar = 72004,

        [Display(GroupName = "OrcamentoEtapaItem", Name = "Cadastrar OrcamentoEtapaItem", Description = "Permite cadastrar um OrcamentoEtapaItem")]
        OrcamentoObras_OrcamentoEtapaItem_Cadastrar = 73001,
        [Display(GroupName = "OrcamentoEtapaItem", Name = "Alterar OrcamentoEtapaItem", Description = "Permite alterar um OrcamentoEtapaItem")]
        OrcamentoObras_OrcamentoEtapaItem_Alterar = 73002,
        [Display(GroupName = "OrcamentoEtapaItem", Name = "Excluir OrcamentoEtapaItem", Description = "Permite excluir um OrcamentoEtapaItem")]
        OrcamentoObras_OrcamentoEtapaItem_Excluir = 73003,
        [Display(GroupName = "OrcamentoEtapaItem", Name = "Listar OrcamentoEtapaItem", Description = "Permite listar os OrcamentoEtapaItem")]
        OrcamentoObras_OrcamentoEtapaItem_Listar = 73004,

        [Display(GroupName = "OrcamentoEtapa", Name = "Cadastrar OrcamentoEtapa", Description = "Permite cadastrar uma OrcamentoEtapa")]
        OrcamentoObras_OrcamentoEtapa_Cadastrar = 74001,
        [Display(GroupName = "OrcamentoEtapa", Name = "Alterar OrcamentoEtapa", Description = "Permite alterar uma OrcamentoEtapa")]
        OrcamentoObras_OrcamentoEtapa_Alterar = 74002,
        [Display(GroupName = "OrcamentoEtapa", Name = "Excluir OrcamentoEtapa", Description = "Permite excluir uma OrcamentoEtapa")]
        OrcamentoObras_OrcamentoEtapa_Excluir = 74003,
        [Display(GroupName = "OrcamentoEtapa", Name = "Listar OrcamentoEtapa", Description = "Permite listar as OrcamentoEtapa")]
        OrcamentoObras_OrcamentoEtapa_Listar = 74004,

        [Display(GroupName = "OrcamentoObras", Name = "Cadastrar OrcamentoObras", Description = "Permite cadastrar um OrcamentoObras")]
        OrcamentoObras_OrcamentoObras_Cadastrar = 75001,
        [Display(GroupName = "OrcamentoObras", Name = "Alterar OrcamentoObras", Description = "Permite alterar um OrcamentoObras")]
        OrcamentoObras_OrcamentoObras_Alterar = 75002,
        [Display(GroupName = "OrcamentoObras", Name = "Excluir OrcamentoObras", Description = "Permite excluir um OrcamentoObras")]
        OrcamentoObras_OrcamentoObras_Excluir = 75003,
        [Display(GroupName = "OrcamentoObras", Name = "Listar OrcamentoObras", Description = "Permite listar os OrcamentoObras")]
        OrcamentoObras_OrcamentoObras_Listar = 75004,

        [Display(GroupName = "OrigemDados", Name = "Cadastrar OrigemDados", Description = "Permite cadastrar um OrigemDados")]
        OrcamentoObras_OrigemDados_Cadastrar = 76001,
        [Display(GroupName = "OrigemDados", Name = "Alterar OrigemDados", Description = "Permite alterar um OrigemDados")]
        OrcamentoObras_OrigemDados_Alterar = 76002,
        [Display(GroupName = "OrigemDados", Name = "Excluir OrigemDados", Description = "Permite excluir um OrigemDados")]
        OrcamentoObras_OrigemDados_Excluir = 76003,
        [Display(GroupName = "OrigemDados", Name = "Listar OrigemDados", Description = "Permite listar os OrigemDados")]
        OrcamentoObras_OrigemDados_Listar = 76004,

        [Display(GroupName = "TipoComposicao", Name = "Cadastrar TipoComposicao", Description = "Permite cadastrar um TipoComposicao")]
        OrcamentoObras_TipoComposicao_Cadastrar = 77001,
        [Display(GroupName = "TipoComposicao", Name = "Alterar TipoComposicao", Description = "Permite alterar um TipoComposicao")]
        OrcamentoObras_TipoComposicao_Alterar = 77002,
        [Display(GroupName = "TipoComposicao", Name = "Excluir TipoComposicao", Description = "Permite excluir um TipoComposicao")]
        OrcamentoObras_TipoComposicao_Excluir = 77003,
        [Display(GroupName = "TipoComposicao", Name = "Listar TipoComposicao", Description = "Permite listar os TipoComposicao")]
        OrcamentoObras_TipoComposicao_Listar = 77004,

        [Display(GroupName = "TipoInsumo", Name = "Cadastrar TipoInsumo", Description = "Permite cadastrar um TipoInsumo")]
        OrcamentoObras_TipoInsumo_Cadastrar = 78001,
        [Display(GroupName = "TipoInsumo", Name = "Alterar TipoInsumo", Description = "Permite alterar um TipoInsumo")]
        OrcamentoObras_TipoInsumo_Alterar = 78002,
        [Display(GroupName = "TipoInsumo", Name = "Excluir TipoInsumo", Description = "Permite excluir um TipoInsumo")]
        OrcamentoObras_TipoInsumo_Excluir = 78003,
        [Display(GroupName = "TipoInsumo", Name = "Listar TipoInsumo", Description = "Permite listar os TipoInsumo")]
        OrcamentoObras_TipoInsumo_Listar = 78004,

        [Display(GroupName = "Insumo", Name = "Cadastrar Insumo", Description = "Permite cadastrar um Insumo")]
        OrcamentoObras_Insumo_Cadastrar = 79001,
        [Display(GroupName = "Insumo", Name = "Alterar Insumo", Description = "Permite alterar um Insumo")]
        OrcamentoObras_Insumo_Alterar = 79002,
        [Display(GroupName = "Insumo", Name = "Excluir Insumo", Description = "Permite excluir um Insumo")]
        OrcamentoObras_Insumo_Excluir = 79003,
        [Display(GroupName = "Insumo", Name = "Listar Insumo", Description = "Permite listar os Insumo")]
        OrcamentoObras_Insumo_Listar = 79004,

        #endregion

        #region AreaCorretor

        [Display(GroupName = "Reserva", Name = "Cadastrar Reserva", Description = "Permite cadastrar Reserva")]
        AreaCorretor_Reserva_Cadastrar = 80001,
        [Display(GroupName = "Reserva", Name = "Alterar Reserva", Description = "Permite alterar Reserva")]
        AreaCorretor_Reserva_Alterar = 80002,
        [Display(GroupName = "Reserva", Name = "Excluir Reserva", Description = "Permite excluir Reserva")]
        AreaCorretor_Reserva_Excluir = 80003,
        [Display(GroupName = "Reserva", Name = "Listar Reserva", Description = "Permite listar Reserva")]
        AreaCorretor_Reserva_Listar = 80004,

        [Display(GroupName = "Lead", Name = "Cadastrar Lead", Description = "Permite cadastrar Lead")]
        AreaCorretor_Lead_Cadastrar = 81001,
        [Display(GroupName = "Lead", Name = "Alterar Lead", Description = "Permite alterar Lead")]
        AreaCorretor_Lead_Alterar = 81002,
        [Display(GroupName = "Lead", Name = "Excluir Lead", Description = "Permite excluir Lead")]
        AreaCorretor_Lead_Excluir = 81003,
        [Display(GroupName = "Lead", Name = "Listar Lead", Description = "Permite listar Lead")]
        AreaCorretor_Lead_Listar = 81004,

        [Display(GroupName = "SituacaoReserva", Name = "Cadastrar SituacaoReserva", Description = "Permite cadastrar SituacaoReserva")]
        AreaCorretor_SituacaoReserva_Cadastrar = 82001,
        [Display(GroupName = "SituacaoReserva", Name = "Alterar SituacaoReserva", Description = "Permite alterar SituacaoReserva")]
        AreaCorretor_SituacaoReserva_Alterar = 82002,
        [Display(GroupName = "SituacaoReserva", Name = "Excluir SituacaoReserva", Description = "Permite excluir SituacaoReserva")]
        AreaCorretor_SituacaoReserva_Excluir = 82003,
        [Display(GroupName = "SituacaoReserva", Name = "Listar SituacaoReserva", Description = "Permite listar SituacaoReserva")]
        AreaCorretor_SituacaoReserva_Listar = 82004,

        [Display(GroupName = "TipoReserva", Name = "Cadastrar TipoReserva", Description = "Permite cadastrar TipoReserva")]
        AreaCorretor_TipoReserva_Cadastrar = 83001,
        [Display(GroupName = "TipoReserva", Name = "Alterar TipoReserva", Description = "Permite alterar TipoReserva")]
        AreaCorretor_TipoReserva_Alterar = 83002,
        [Display(GroupName = "TipoReserva", Name = "Excluir TipoReserva", Description = "Permite excluir TipoReserva")]
        AreaCorretor_TipoReserva_Excluir = 83003,
        [Display(GroupName = "TipoReserva", Name = "Listar TipoReserva", Description = "Permite listar TipoReserva")]
        AreaCorretor_TipoReserva_Listar = 83004,

        [Display(GroupName = "ReservaObservacao", Name = "Cadastrar ReservaObservacao", Description = "Permite cadastrar ReservaObservacao")]
        AreaCorretor_ReservaObservacao_Cadastrar = 84001,
        [Display(GroupName = "ReservaObservacao", Name = "Alterar ReservaObservacao", Description = "Permite alterar ReservaObservacao")]
        AreaCorretor_ReservaObservacao_Alterar = 84002,
        [Display(GroupName = "ReservaObservacao", Name = "Excluir ReservaObservacao", Description = "Permite excluir ReservaObservacao")]
        AreaCorretor_ReservaObservacao_Excluir = 84003,
        [Display(GroupName = "ReservaObservacao", Name = "Listar ReservaObservacao", Description = "Permite listar ReservaObservacao")]
        AreaCorretor_ReservaObservacao_Listar = 84004,

        [Display(GroupName = "GrauParentesco", Name = "Cadastrar GrauParentesco", Description = "Permite cadastrar GrauParentesco")]
        AreaCorretor_GrauParentesco_Cadastrar = 85001,
        [Display(GroupName = "GrauParentesco", Name = "Alterar GrauParentesco", Description = "Permite alterar GrauParentesco")]
        AreaCorretor_GrauParentesco_Alterar = 85002,
        [Display(GroupName = "GrauParentesco", Name = "Excluir GrauParentesco", Description = "Permite excluir GrauParentesco")]
        AreaCorretor_GrauParentesco_Excluir = 85003,
        [Display(GroupName = "GrauParentesco", Name = "Listar GrauParentesco", Description = "Permite listar GrauParentesco")]
        AreaCorretor_GrauParentesco_Listar = 85004,

        [Display(GroupName = "GrauInteresse", Name = "Cadastrar GrauInteresse", Description = "Permite cadastrar GrauInteresse")]
        AreaCorretor_GrauInteresse_Cadastrar = 86001,
        [Display(GroupName = "GrauInteresse", Name = "Alterar GrauInteresse", Description = "Permite alterar GrauInteresse")]
        AreaCorretor_GrauInteresse_Alterar = 86002,
        [Display(GroupName = "GrauInteresse", Name = "Excluir GrauInteresse", Description = "Permite excluir GrauInteresse")]
        AreaCorretor_GrauInteresse_Excluir = 86003,
        [Display(GroupName = "GrauInteresse", Name = "Listar GrauInteresse", Description = "Permite listar GrauInteresse")]
        AreaCorretor_GrauInteresse_Listar = 86004,

        #endregion


        //ultimo id 89001. SituacaoAdiantamentoCarteira em financeiro 

    }
}
