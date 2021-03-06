﻿Imports System.Data

Public Class EquipeProfessor
    Private EE04_ID_EQUIPE_PROFESSOR As Integer
    Private EE02_ID_PROFESSOR As Integer
    Private EE06_ID_EQUIPE_ESCOLA As Integer

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub



    Public Property Codigo() As Integer
        Get
            Return EE04_ID_EQUIPE_PROFESSOR
        End Get
        Set(value As Integer)
            EE04_ID_EQUIPE_PROFESSOR = value
        End Set
    End Property

    Public Property CodigoProfessor() As Integer
        Get
            Return EE02_ID_PROFESSOR
        End Get
        Set(value As Integer)
            EE02_ID_PROFESSOR = value
        End Set
    End Property

    Public Property CodigoEquipeEscola() As Integer
        Get
            Return EE06_ID_EQUIPE_ESCOLA
        End Get
        Set(value As Integer)
            EE06_ID_EQUIPE_ESCOLA = value
        End Set
    End Property

    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE04_EQUIPE_PROFESSOR")
        strSQL.Append(" where EE04_ID_EQUIPE_PROFESSOR = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE04_ID_EQUIPE_PROFESSOR = DoBanco(dr("EE04_ID_EQUIPE_PROFESSOR"), eTipoValor.CHAVE)
            EE02_ID_PROFESSOR = DoBanco(dr("EE02_ID_PROFESSOR"), eTipoValor.CHAVE)
            EE06_ID_EQUIPE_ESCOLA = DoBanco(dr("EE06_ID_EQUIPE_ESCOLA"), eTipoValor.CHAVE)
        End If
    End Sub

    Public Function ObterTabela(CodigoTurma As Integer) As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select EE04_EQUIPE_PROFESSOR.EE04_ID_EQUIPE_PROFESSOR as CODIGO, EE02_PROFESSOR.EE02_NM_NOME as DESCRICAO ")
        strSQL.Append(" from EE04_EQUIPE_PROFESSOR")
        strSQL.Append(" Join EE02_PROFESSOR On EE04_EQUIPE_PROFESSOR.EE02_ID_PROFESSOR = EE02_PROFESSOR.EE02_ID_PROFESSOR")
        strSQL.Append(" And EE04_EQUIPE_PROFESSOR.EE06_ID_EQUIPE_ESCOLA =" & CodigoTurma)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        Return dt
    End Function

    Public Function Pesquisar(CodigoTurma As Integer,
                             Optional ByVal Sort As String = "",
                             Optional ByVal IdProfessor As Integer = 0,
                             Optional ByVal NomeProfessor As String = "",
                             Optional ByVal Matricula As String = ""
                            ) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder


        strSQL.Append(" select * ")
        strSQL.Append(" from EE04_EQUIPE_PROFESSOR")
        strSQL.Append(" Join EE02_PROFESSOR On EE04_EQUIPE_PROFESSOR.EE02_ID_PROFESSOR = EE02_PROFESSOR.EE02_ID_PROFESSOR")
        strSQL.Append(" And EE04_EQUIPE_PROFESSOR.EE06_ID_EQUIPE_ESCOLA =" & CodigoTurma)


        If IdProfessor > 0 Then
            strSQL.Append(" and EE02_ID_PROFESSOR = " & IdProfessor)
        End If

        If NomeProfessor <> "" Then
            strSQL.Append(" and upper(EE02_NM_NOME) like '%" & NomeProfessor.ToUpper & "%'")
        End If

        If Matricula <> "" Then
            strSQL.Append(" and upper(EE02_NR_MATRICULA) like '%" & Matricula.ToUpper & "%'")
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "EE02_NM_NOME", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Friend Function Excluir(Codigo As Object) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE04_EQUIPE_PROFESSOR")
        strSQL.Append(" where EE04_ID_EQUIPE_PROFESSOR = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE04_EQUIPE_PROFESSOR")
        strSQL.Append(" where EE02_ID_PROFESSOR = " & CodigoProfessor)
        strSQL.Append(" and EE06_ID_EQUIPE_ESCOLA = " & CodigoEquipeEscola)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
            dr("EE02_ID_PROFESSOR") = ProBanco(EE02_ID_PROFESSOR, eTipoValor.CHAVE)
            dr("EE06_ID_EQUIPE_ESCOLA") = ProBanco(EE06_ID_EQUIPE_ESCOLA, eTipoValor.CHAVE)
            cnn.SalvarDataTable(dr)

        End If

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub
End Class
