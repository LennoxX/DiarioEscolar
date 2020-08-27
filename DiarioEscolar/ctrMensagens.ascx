﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrMensagens.ascx.vb" Inherits="DiarioEscolar.ctrMensagens" %>
<div class="content">
    <div id="divErro" class="alert alert-danger alert-dismissable" style="display: none; z-index: 999;">
        <i class="fa fa-ban"></i>
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
        <b>Erro!</b> <span id="spnErro"></span>
    </div>
    <div class="alert alert-info alert-dismissable" style="display: none; z-index: 999;">
        <i class="fa fa-info"></i>
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
        <b>Informação!</b> Info alert preview. This alert is dismissable.
    </div>
    <div id="divAlerta" class="alert alert-warning alert-dismissable" style="display: none; z-index: 999;">
        <i class="fa fa-warning"></i>
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
        <b>Atenção!</b> <span id="spnAlerta"></span>
    </div>
    <div id="divSucesso" class="alert alert-success alert-dismissable" style="display: none; z-index: 999;">
        <i class="fa fa-check"></i>
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
        <b>Sucesso!</b> <span id="spnSucesso"></span>
    </div>

    <div class="centro">
        <div id="divConfirmacao" class="alert-message block-message warning" data-alert="alert" style="width: 415px; padding: 10px 10px 10px 10px; display: none;">
            <a class="close" href="#">×</a>
            <p><strong>Atenção:</strong> <span id="spnConfirmacao"></span></p>
            <div class="alert-actions">
                <a class="btn small" href="javascript:__doPostBack('', '');">Sim</a> <a class="btn small" href="javascript:return(false);">Não</a>
            </div>
        </div>
    </div>
</div>
