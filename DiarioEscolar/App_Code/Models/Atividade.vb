Imports System.Data

Public Class Atividade
    Private EE09_ID_ATIVIDADE As Integer
    Private EE10_ID_TIPO_ATIVIDADE As Integer
    Private EE13_ID_EQUIPE_DISCIPLINA As Integer
    Private EE09_DT_CADASTRO As DateTime
    Private EE09_DT_REALIZADA As DateTime

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE09_ID_ATIVIDADE
        End Get
        Set(value As Integer)
            EE09_ID_ATIVIDADE = value
        End Set
    End Property

    Public Property TipoAtividade() As Integer
        Get
            Return EE10_ID_TIPO_ATIVIDADE
        End Get
        Set(value As Integer)
            EE10_ID_TIPO_ATIVIDADE = value
        End Set
    End Property

    Public Property EquipeDisciplina() As Integer
        Get
            Return EE13_ID_EQUIPE_DISCIPLINA
        End Get
        Set(value As Integer)
            EE13_ID_EQUIPE_DISCIPLINA = value
        End Set
    End Property

    Public Property DataCadastro() As Date
        Get
            Return EE09_DT_CADASTRO
        End Get
        Set(value As Date)
            EE09_DT_CADASTRO = value
        End Set
    End Property

    Public Property DataRealizada() As Date
        Get
            Return EE09_DT_REALIZADA
        End Get
        Set(value As Date)
            EE09_DT_REALIZADA = value
        End Set
    End Property

    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE09_ATIVIDADE")
        strSQL.Append(" where EE09_ID_ATIVIDADE = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE09_ID_ATIVIDADE = DoBanco(dr("EE09_ID_ATIVIDADE"), eTipoValor.CHAVE)
            EE10_ID_TIPO_ATIVIDADE = DoBanco(dr("EE10_ID_TIPO_ATIVIDADE"), eTipoValor.CHAVE)
            EE13_ID_EQUIPE_DISCIPLINA = DoBanco(dr("EE13_ID_EQUIPE_DISCIPLINA"), eTipoValor.CHAVE)
            EE09_DT_CADASTRO = DoBanco(dr("EE09_DT_CADASTRO"), eTipoValor.DATA)
            EE09_DT_REALIZADA = DoBanco(dr("EE09_DT_REALIZADA"), eTipoValor.DATA)

        End If

    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE09_ATIVIDADE")
        strSQL.Append(" where EE09_ID_ATIVIDADE = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE09_ID_ATIVIDADE") = ProBanco(EE09_ID_ATIVIDADE, eTipoValor.CHAVE)
        dr("EE10_ID_TIPO_ATIVIDADE") = ProBanco(EE10_ID_TIPO_ATIVIDADE, eTipoValor.CHAVE)
        dr("EE13_ID_EQUIPE_DISCIPLINA") = ProBanco(EE13_ID_EQUIPE_DISCIPLINA, eTipoValor.CHAVE)
        dr("EE09_DT_CADASTRO") = ProBanco(EE09_DT_CADASTRO, eTipoValor.DATA)
        dr("EE09_DT_REALIZADA") = ProBanco(EE09_DT_REALIZADA, eTipoValor.DATA)



        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Function Pesquisar(CodigoEquipeDisciplina As Integer,
                             Optional ByVal Sort As String = "",
                             Optional ByVal TipoAtividade As Integer = 0,
                             Optional ByVal DataCadastro As Date = Nothing,
                             Optional ByVal DataRealizada As Date = Nothing
                            ) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder



        strSQL.Append(" select * ")
        strSQL.Append(" From EE09_ATIVIDADE")
        strSQL.Append(" Join EE10_TIPO_ATIVIDADE On EE09_ATIVIDADE.EE10_ID_TIPO_ATIVIDADE = EE10_TIPO_ATIVIDADE.EE10_ID_TIPO_ATIVIDADE")
        strSQL.Append(" Where EE09_ATIVIDADE.EE13_ID_EQUIPE_DISCIPLINA =" & CodigoEquipeDisciplina)


        If TipoAtividade > 0 Then
            strSQL.Append(" and EE10_ID_TIPO_ATIVIDADE = " & TipoAtividade)
        End If


        If DataCadastro <> Nothing Then
            strSQL.Append(" and EE09_DT_CADASTRO =" & DataCadastro)
        End If


        If DataRealizada <> Nothing Then
            strSQL.Append(" and EE09_DT_REALIZADA =" & EE09_DT_REALIZADA)
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "EE09_DT_CADASTRO", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Friend Function Excluir(Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE09_ATIVIDADE")
        strSQL.Append(" where EE09_ID_ATIVIDADE = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function
End Class
