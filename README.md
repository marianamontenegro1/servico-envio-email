# Projeto servico-envio-email
Serviço responsável por enviar emails de teste. Este serviço é executado de 5 em 5 minutos.
As configurações básicas para envio do email foram feitas no _appsettings.Development.Json_, segue abaixo um exemplo dos dados do arquivo:

``` 
{
  "EmailSettings": {
    "Mail": "<SeuEmail>",
    "DisplayName": "<Nome>",
    "Password": "<SenhaDoEmail>",
    "Host": "smtp-mail.outlook.com",
    "Port": 587
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

* Mail - É o ID de email do qual você deseja enviar um email.
* DisplayName - É o nome que aparece no destinatário.
* Host - É o nome que identifica o seu servidor de Email
* Port - É a porta usada

No meu projeto usei email do outlook, portanto configurei o host para _smtp-mail.outlook.com_. Caso queira usar Gmail o host deverá alterar a configuração para _smtp.gmail.com_

## Comandos básicos para gerênciar o serviço
Para executar os comandos, é necessário abrir o CMD como administrador e navegar até o diretório onde está seu projeto.

* **PUBLICAR**

```dotnet publish --output <<PathBin>>\<<Executavel>>```

* **INSTALAR**

```sc.exe create <<nomeServico>> binpath=<<PathBin>>\<<Executavel>>```

* **INICIAR**

```sc.exe start <<nomeServico>> ```

* **PARAR**

```sc.exe stop <<nomeServico>> ```

* **EXCLUIR**

```sc.exe delete <<nomeServico>> ```

____

### Fonte de pesquisa:

<https://docs.microsoft.com/pt-br/dotnet/core/extensions/windows-service>

<https://imasters.com.br/dotnet/construindo-um-windows-service-ou-linux-daemon-com-worker-service-net-core-parte-1>

<https://www.macoratti.net/20/08/aspnc_email1.htm>
