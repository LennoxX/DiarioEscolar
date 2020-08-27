Imports System.Data

Public Class EquipeEscola
    Private EE06_ID_EQUIPE_ESCOLA As Integer
    Private EE01_ID_ESCOLA As Integer
    Private EE14_ID_MATRIZ As Integer
    Private EE06_DH_DATA As DateTime
    Private EE06_DS_EQUIPE_ESCOLA As String

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE06_ID_EQUIPE_ESCOLA
        End Get
        Set(value As Integer)
            EE06_ID_EQUIPE_ESCOLA = value
        End Set
    End Property

    Public Property CodigoEscola() As Integer
        Get
            Return EE01_ID_ESCOLA
        End Get
        Set(value As Integer)
            EE01_ID_ESCOLA = value
        End Set
    End Property


    Public Property Data() As Date
        Get
            Return EE06_DH_DATA
        End Get
        Set(value As Date)
            EE06_DH_DATA = value
        End Set
    End Property

    Public Property Matriz() As Integer
        Get
            Return EE14_ID_MATRIZ
        End Get
        Set(value As Integer)
            EE14_ID_MATRIZ = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return EE06_DS_EQUIPE_ESCOLA
        End Get
        Set(value As String)
            EE06_DS_EQUIPE_ESCOLA = value
        End Set
    End Property

    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE06_EQUIPE_ESCOLA")
        strSQL.Append(" where EE06_ID_EQUIPE_ESCOLA = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE06_ID_EQUIPE_ESCOLA = DoBanco(dr("EE06_ID_EQUIPE_ESCOLA"), eTipoValor.CHAVE)
            EE01_ID_ESCOLA = DoBanco(dr("EE01_ID_ESCOLA"), eTipoValor.CHAVE)
            EE14_ID_MATRIZ = DoBanco(dr("EE14_ID_MATRIZ"), eTipoValor.CHAVE)
            EE06_DH_DATA = DoBanco(dr("EE06_DH_DATA"), eTipoValor.DATA_COMPLETA)
            EE06_DS_EQUIPE_ESCOLA = DoBanco(dr("EE06_DS_EQUIPE_ESCOLA"), eTipoValor.TEXTO)

        End If

    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE06_EQUIPE_ESCOLA")
        strSQL.Append(" where EE06_ID_EQUIPE_ESCOLA = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE06_ID_EQUIPE_ESCOLA") = ProBanco(EE06_ID_EQUIPE_ESCOLA, eTipoValor.CHAVE)
        dr("EE01_ID_ESCOLA") = ProBanco(EE01_ID_ESCOLA, eTipoValor.CHAVE)
        dr("EE14_ID_MATRIZ") = ProBanco(EE14_ID_MATRIZ, eTipoValor.CHAVE)
        dr("EE06_DH_DATA") = ProBanco(EE06_DH_DATA, eTipoValor.DATA)
        dr("EE06_DS_EQUIPE_ESCOLA") = ProBanco(EE06_DS_EQUIPE_ESCOLA, eTipoValor.TEXTO)


        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Function Pesquisar(CodigoEscola As Integer,
                            Optional ByVal Sort As String = "",
                            Optional ByVal Codigo As Integer = 0,
                            Optional ByVal IdMatriz As Integer = 0,
                            Optional ByVal Descricao As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE06_EQUIPE_ESCOLA")
        strSQL.Append(" where EE06_ID_EQUIPE_ESCOLA is not null")
        strSQL.Append(" And EE01_ID_ESCOLA = " & CodigoEscola)



        If Codigo > 0 Then
            strSQL.Append(" and EE06_ID_EQUIPE_ESCOLA = " & Codigo)
        End If

        If IdMatriz > 0 Then
            strSQL.Append(" and EE14_ID_MATRIZ = " & IdMatriz)
        End If

        If Descricao <> "" Then
            strSQL.Append(" and upper(EE06_DS_EQUIPE_ESCOLA) like '%" & Descricao.ToUpper & "%'")
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "EE06_DS_EQUIPE_ESCOLA", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Friend Function Excluir(Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE06_EQUIPE_ESCOLA")
        strSQL.Append(" where EE06_ID_EQUIPE_ESCOLA = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function
End Class
