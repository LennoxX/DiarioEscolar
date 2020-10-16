Imports System.Data

Public Class Aula
    Private EE08_ID_AULA As Integer
    Private EE13_ID_EQUIPE_DISCIPLINA As Integer
    Private EE08_DT_CADASTRO As DateTime
    Private EE08_DS_CONTEUDO As String

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE08_ID_AULA
        End Get
        Set(value As Integer)
            EE08_ID_AULA = value
        End Set
    End Property

    Public Property IdEquipeDisciplina() As Integer
        Get
            Return EE13_ID_EQUIPE_DISCIPLINA
        End Get
        Set(value As Integer)
            EE13_ID_EQUIPE_DISCIPLINA = value
        End Set
    End Property

    Public Property DataCadastro() As Date
        Get
            Return EE08_DT_CADASTRO
        End Get
        Set(value As Date)
            EE08_DT_CADASTRO = value
        End Set
    End Property

    Public Property Conteudo() As String
        Get
            Return EE08_DS_CONTEUDO
        End Get
        Set(value As String)
            EE08_DS_CONTEUDO = value
        End Set
    End Property

    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE08_AULA")
        strSQL.Append(" where EE08_ID_AULA = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE08_ID_AULA = DoBanco(dr("EE08_ID_AULA"), eTipoValor.CHAVE)
            EE13_ID_EQUIPE_DISCIPLINA = DoBanco(dr("EE13_ID_EQUIPE_DISCIPLINA"), eTipoValor.CHAVE)
            EE08_DT_CADASTRO = DoBanco(dr("EE08_DT_CADASTRO"), eTipoValor.DATA)
            EE08_DS_CONTEUDO = DoBanco(dr("EE08_DS_CONTEUDO"), eTipoValor.TEXTO_LIVRE)

        End If

    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE08_AULA")
        strSQL.Append(" where EE08_ID_AULA = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE08_ID_AULA") = ProBanco(EE08_ID_AULA, eTipoValor.CHAVE)
        dr("EE13_ID_EQUIPE_DISCIPLINA") = ProBanco(EE13_ID_EQUIPE_DISCIPLINA, eTipoValor.CHAVE)
        dr("EE08_DT_CADASTRO") = ProBanco(EE08_DT_CADASTRO, eTipoValor.DATA)
        dr("EE08_DS_CONTEUDO") = ProBanco(EE08_DS_CONTEUDO, eTipoValor.TEXTO_LIVRE)


        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Function Pesquisar(EquipeDisciplina As Integer,
                              Optional ByVal Sort As String = "",
                              Optional ByVal Codigo As Integer = 0,
                              Optional ByVal DataCadastro As Date = Nothing,
                              Optional ByVal Nascimento As Date = Nothing,
                              Optional ByVal Situacao As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select * ")
        strSQL.Append(" from EE08_AULA")
        strSQL.Append(" where EE08_ID_AULA Is Not null")
        strSQL.Append(" and EE13_ID_EQUIPE_DISCIPLINA = " & EquipeDisciplina)

        If Codigo > 0 Then
            strSQL.Append(" And EE08_ID_AULA = " & Codigo)
        End If



        If DataCadastro <> Nothing Then
            strSQL.Append(" and EE08_DT_CADASTRO =" & Nascimento)
        End If

        If Conteudo <> "" Then
            strSQL.Append(" and upper(EE08_DS_CONTEUDO) like '%" & Situacao.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "EE08_DS_CONTEUDO", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function
End Class
