Imports System.Data

Public Class Falta
    Private EE17_ID_FALTA As Integer
    Private EE08_ID_AULA As Integer
    Private EE17_NR_FALTA As Integer
    Private EE05_ID_EQUIPE_ALUNO As Integer

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE17_ID_FALTA
        End Get
        Set(value As Integer)
            EE17_ID_FALTA = value
        End Set
    End Property

    Public Property CodigoAula() As Integer
        Get
            Return EE08_ID_AULA
        End Get
        Set(value As Integer)
            EE08_ID_AULA = value
        End Set
    End Property

    Public Property Falta() As Integer
        Get
            Return EE17_NR_FALTA
        End Get
        Set(value As Integer)
            EE17_NR_FALTA = value
        End Set
    End Property

    Public Property CodigoEquipeAluno() As Integer
        Get
            Return EE05_ID_EQUIPE_ALUNO
        End Get
        Set(value As Integer)
            EE05_ID_EQUIPE_ALUNO = value
        End Set
    End Property

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                            Optional ByVal Codigo As Integer = 0,
                            Optional ByVal CodigoAula As Integer = 0,
                            Optional ByVal Falta As Integer = 0,
                            Optional ByVal CodigoEquipeAluno As Integer = 0
                           ) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select * ")
        strSQL.Append(" from  EE17_FALTA")
        strSQL.Append(" where  EE17_ID_FALTA Is Not null")

        If Codigo > 0 Then
            strSQL.Append(" And EE17_ID_FALTA = " & Codigo)
        End If

        If CodigoAula > 0 Then
            strSQL.Append("  And EE08_ID_AULA = " & CodigoAula)
        End If

        If Falta > 0 Then
            strSQL.Append("  And EE17_NR_FALTA = " & Falta)
        End If

        If CodigoEquipeAluno > 0 Then
            strSQL.Append("  And EE05_ID_EQUIPE_ALUNO = " & CodigoEquipeAluno)
        End If

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE17_FALTA")
        strSQL.Append(" where EE17_ID_FALTA = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE08_ID_AULA") = ProBanco(EE08_ID_AULA, eTipoValor.CHAVE)
        dr("EE05_ID_EQUIPE_ALUNO") = ProBanco(EE05_ID_EQUIPE_ALUNO, eTipoValor.CHAVE)
        dr("EE17_NR_FALTA") = ProBanco(EE17_NR_FALTA, eTipoValor.NUMERO_INTEIRO)



        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub
End Class
