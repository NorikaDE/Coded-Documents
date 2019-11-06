# Coded-Documents
Write easily document per code. Create a formatted markdown document in your program and much more.

## Build
[![Build Status](https://dev.azure.com/NorikaDE/Coded-Documentation/_apis/build/status/NorikaDE.Coded-Documents?branchName=master)](https://dev.azure.com/NorikaDE/Coded-Documentation/_build/latest?definitionId=2&branchName=master)
[![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/NorikaDE/Coded-Documents/2)](https://dev.azure.com/NorikaDE/Coded-Documents/_build?definitionId=2)
[![Azure DevOps tests (compact)](https://img.shields.io/azure-devops/tests/NorikaDE/Coded-Documents/2?compact_message)](https://dev.azure.com/NorikaDE/Coded-Documents/_build?definitionId=2)
[![CodeFactor](https://www.codefactor.io/repository/github/norikade/coded-documents/badge/master)](https://www.codefactor.io/repository/github/norikade/coded-documents/overview/master)

## Example | Markdown
For creating a markdown document with a markdown table you could use following code:

```cs
PrintableDocument<IMarkdownDocument> document = new PrintableDocument<IMarkdownDocument>();

IPrintableDocument markdownDocument = document.Create("My Markdown");
            
IPrintableDocumentChapter chapter = markdownDocument.AddNewChapter("My MarkdownTable");

IPrintableParagraphTable table = chapter.AddNewContent<IPrintableParagraphTable>()
  .WithHeaders("A", "B")
    .WithRow("1", "2")
    .WithRow("3", "4");

document.Save("readme.md", markdownDocument);
```
The code above creates a file "readme.md" in the current working directory with the following content:

------------------------
# My Markdown
## My MarkdownTable
| A | B |
|---|---|
| 1 | 2 |
| 3 | 4 |

------------------------
